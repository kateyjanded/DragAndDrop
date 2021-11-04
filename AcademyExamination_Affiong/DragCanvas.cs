using AcademyExamination_Affiong.ViewModel;
using AcademyExamination_Affiong.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AcademyExamination_Affiong
{
    public class DragCanvas: Canvas
    {
        public DragCanvas(MainWindowViewModel mainWindowViewModel)
        {
            mainWindowViewModel.DraWLineEvent += MainWindowViewModel_DraWLineEvent;
            mainWindowViewModel.ToggleEvent += MainWindowViewModel_ToggleEvent;
            mainWindowViewModel.Savexml += MainWindowViewModel_Savexml;
            Background = Brushes.LightCyan;
            
        }
        AdornerLayer AdornerLayer;
        public Tools tools = Tools.Shape;
        public Toggle toggle = Toggle.None;
        public Line line;
        public Point currentpoint;
        public string File;
        public DragThumb OldThumb { get; set; }
        private DragThumb selectedThumb;
        public DragThumb SelectedThumb
        {
            get { return selectedThumb; }
            set { selectedThumb = value;
                OnSelectedChanged();
            }
        }

        private void OnSelectedChanged()
        {
            //if (OldThumb != null)
            //{
            //    AdornerLayer.Remove(AdornerLayer.GetAdorners(OldThumb)[0]);
            //    SetZIndex(OldThumb, 0);
            //}
            //if (SelectedThumb != null)
            //{
            //    AdornerLayer = AdornerLayer.GetAdornerLayer(SelectedThumb);
            //    AdornerLayer.Add(new SimpleAdorner(SelectedThumb));
            //    SetZIndex(SelectedThumb, Children.Count);
            //}
        }

        private void MainWindowViewModel_ToggleEvent()
        {
            GetSelectedItems();
        }
        private void GetSelectedItems()
        {
            if (toggle == Toggle.ToggleOn)
            {
                toggle = Toggle.ToggleOf;
            }
            else
            {
                toggle = Toggle.ToggleOn;
            }
        }
        private void MainWindowViewModel_DraWLineEvent()
        {
            GetConnectedShape();
        }
        protected override void OnPreviewDrop(DragEventArgs e)
        {
            var data = e.Data.GetData("shapes");
            var obj = data as Shape;
            var position = e.GetPosition(this);
            DragThumb drag = new DragThumb(obj);
            CreateMethods(ref drag);
            SetTop(drag, position.Y);
            SetLeft(drag, position.X);
            Children.Add(drag);
            SetSelectedThumb(drag);
        }
        public void SetSelectedThumb(DragThumb thumb)
        {
            OldThumb = SelectedThumb;
            SelectedThumb = thumb;
        }
        public void CreateMethods(ref DragThumb thumb)
        {
            thumb.DragDelta += Drag_DragDelta;
            thumb.PreviewMouseLeftButtonDown += Drag_PreviewMouseLeftButtonDown;
            thumb.DragCompleted += Drag_DragCompleted;
        }
        private void MainWindowViewModel_Savexml()
        {
            List<DragThumb> thumbs = Children.OfType<DragThumb>().ToList();
            XmlReader reader = new XmlReader();
            reader.Writer(thumbs);
        }
        private void Drag_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (tools == Tools.Line)
            {
                var ptx = e.HorizontalChange + line.X1;
                var pty = e.VerticalChange + line.Y1;
                currentpoint.X = ptx;
                currentpoint.Y = pty;
                line.X2 = ptx;
                line.Y2 = pty;
                var newline = new Line() { StrokeThickness = 1, Stroke = Brushes.Black, X1 = line.X1, X2 = line.X2, Y1 = line.Y1, Y2 = line.Y2 };
                Children.Remove(line);
                line = newline;
                var send = sender as DragThumb;
                send.StartLines.Add(line);
                AddEndLine(line, send);
            }
        }
        public void AddEndLine(Line newline, DragThumb startthumb)
        {
            DragThumb thumb = null;
            List<DragThumb> thumbs = Children.OfType<DragThumb>().ToList();
            foreach (var item in thumbs)
            {
                Point pt = new Point(GetLeft(item), GetTop(item));
                if (toggle == Toggle.ToggleOn)
                {
                    if (pt.X <= currentpoint.X && item.Shape.Width + pt.X >= currentpoint.X && pt.Y <= currentpoint.Y && item.Shape.Height + pt.Y >= currentpoint.Y)
                    {
                        if (startthumb.Shape.GetType() == item.Shape.GetType())
                        {
                            AddLineToCanvas(ref thumb, line, item);
                        }
                        else
                        {
                            MessageBox.Show("Please Click On the Toggle Button to Connect dissimilar shapes", "Error!!!", MessageBoxButton.OK);
                        }
                    }
                }
                else if (toggle == Toggle.ToggleOf)
                {
                    if (pt.X <= currentpoint.X && item.Shape.Width + pt.X >= currentpoint.X && pt.Y <= currentpoint.Y && item.Shape.Height + pt.Y >= currentpoint.Y)
                    {
                        if (startthumb.Shape.GetType() != item.Shape.GetType())
                        {
                            AddLineToCanvas(ref thumb, line, item);
                        }
                        else
                        {
                            MessageBox.Show("Please Click On the Toggle Button to Connect similar shapes", "Error!!!", MessageBoxButton.OK);
                        }
                    }
                }
                else
                {
                    if (pt.X <= currentpoint.X && item.Shape.Width + pt.X >= currentpoint.X && pt.Y <= currentpoint.Y && item.Shape.Height + pt.Y >= currentpoint.Y)
                    {
                        AddLineToCanvas(ref thumb, line, item);
                    }
                }
            }
            if (thumb == null)
            {
                startthumb.StartLines.Remove(line);
            }
        }
        private void AddLineToCanvas(ref DragThumb thumb, Line line, DragThumb item)
        {
            thumb = item;
            item.EndLines.Add(line);
            Children.Add(line);
            SetZIndex(line, -1);
        }
        private void Drag_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var thumb = sender as DragThumb;
            if (tools == Tools.Line)
            {
                line = new Line() { Stroke = Brushes.Black, StrokeThickness = 1 };
            }
            currentpoint = e.GetPosition(this);
            SetSelectedThumb(thumb);
        }
        private void Drag_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var thumb = sender as DragThumb;
            if (tools != Tools.Line)
            {
                var positionX = GetLeft(thumb);
                var positionY = GetTop(thumb);
                Point xy = new Point(positionX, positionY);
                Point pt = new Point(e.HorizontalChange, e.VerticalChange);
                SetTop(thumb, positionY + e.VerticalChange);
                SetLeft(thumb, positionX + e.HorizontalChange);
                SetBoundaries(thumb);
                List<Line> lines = Children.OfType<Line>().ToList();
                MoveStartLine(thumb, xy, lines);
                MoveEndLine(ref thumb, pt, lines);
            }
            else
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    Children.Remove(line);
                    line.X1 = currentpoint.X;
                    line.Y1 = currentpoint.Y;
                    line.X2 = line.X1 + e.HorizontalChange;
                    line.Y2 = line.Y1 + e.VerticalChange;
                    Children.Add(line);
                }
            }
            SetSelectedThumb(thumb);
        }
        public void MoveStartLine(DragThumb thumb, Point pt, List<Line> lines)
        {
            foreach (var item in thumb.StartLines)
            {
                item.X1 = GetLeft(thumb) + thumb.Shape.Width/2;
                item.Y1 = GetTop(thumb) + thumb.Shape.Height / 2;
            }
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            OldThumb = SelectedThumb;
            SelectedThumb = null;
        }
        public void MoveEndLine(ref DragThumb thumb, Point pt, List<Line> lines)
        {
            foreach (var item in thumb.EndLines)
            {
                item.X2 = GetLeft(thumb) + thumb.Shape.Width / 2;
                item.Y2 = GetTop(thumb) + thumb.Shape.Height / 2;
            }
        }
        private void GetConnectedShape()
        {
            if (tools == Tools.Line)
            {
                tools = Tools.Shape;
            }
            else
            {
                tools = Tools.Line;
            }
        }
        public void SetBoundaries(DragThumb thumb)
        {
            if (GetLeft(thumb) <= 0)
            {
                SetLeft(thumb, 0);
            }
            if (GetTop(thumb) <= 0)
            {
                SetTop(thumb, 0);
            }
            if (GetLeft(thumb) + thumb.Shape.Width >= RenderSize.Width)
            {
                SetLeft(thumb, RenderSize.Width - thumb.Shape.Width);
            }
            if (GetTop(thumb) + thumb.Shape.Height >= RenderSize.Height)
            {
                SetTop(thumb, RenderSize.Height - thumb.Shape.Height);
            }
        }
    }
}