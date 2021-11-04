using AcademyExamination_Affiong.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace AcademyExamination_Affiong
{
    public class SimpleAdorner: Adorner
    {
        Thumb Topright, topleft, bottomright, bottomleft;
        VisualCollection VisualChildren;
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Rect rect = new Rect(AdornedElement.DesiredSize);
            Pen pen = new Pen(new SolidColorBrush(Colors.Gray), 1.5);
            drawingContext.DrawRectangle(null, pen, rect);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            base.ArrangeOverride(finalSize);
            double width = AdornedElement.DesiredSize.Width;
            double height = AdornedElement.DesiredSize.Height;

            double adornerwidth = DesiredSize.Width;
            double adornerheight = DesiredSize.Height;

            topleft.Arrange(new Rect(-5, -5, 10, 10));
            Topright.Arrange(new Rect(width - adornerwidth / 2, -adornerheight / 2, adornerwidth, adornerheight));
            bottomleft.Arrange(new Rect(-adornerwidth / 2, height - adornerheight / 2, adornerwidth, adornerheight));
            bottomright.Arrange(new Rect(width - adornerwidth / 2, height - adornerheight / 2, adornerwidth, adornerheight));
            return finalSize;
        }
        protected override int VisualChildrenCount
        {
            get
            {
                return VisualChildren.Count;
            }
        }
        protected override Visual GetVisualChild(int index)
        {
            return VisualChildren[index];
        }

        public SimpleAdorner(DragThumb adornedElement) : base(adornedElement)
        {
            VisualChildren = new VisualCollection(this);
            BuilAdornerCorners(ref topleft, Cursors.SizeNWSE);
            BuilAdornerCorners(ref Topright, Cursors.SizeNESW);
            BuilAdornerCorners(ref bottomleft, Cursors.SizeNESW);
            BuilAdornerCorners(ref bottomright, Cursors.SizeNWSE);

            topleft.DragDelta += Topleft_DragDelta;
            Topright.DragDelta += Topright_DragDelta;
            bottomleft.DragDelta += Bottomleft_DragDelta;
            bottomright.DragDelta += Bottomright_DragDelta;
        }

        private void Bottomright_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var adornedelement = AdornedElement as DragThumb;
            Thumb toprightcorner = sender as Thumb;
            if (adornedelement != null && toprightcorner != null)
            {
                EnforceSize(adornedelement);
            }
            double oldWidth = adornedelement.Width;
            double oldHeight = adornedelement.Height;

            double newWidth = Math.Max(adornedelement.Width + e.HorizontalChange, bottomright.DesiredSize.Width);
            double newHeight = Math.Max(e.VerticalChange + adornedelement.Height, bottomright.DesiredSize.Height);

            adornedelement.Width = newWidth;
            adornedelement.Height = newHeight;
            adornedelement.Shape.Width = newWidth;
            adornedelement.Shape.Height = newHeight;
        }

        private void EnforceSize(DragThumb adornedelement)
        {

            if (adornedelement.Width.Equals(Double.NaN))
            {
                adornedelement.Width = adornedelement.DesiredSize.Width;
            }
            if (adornedelement.Height.Equals(Double.NaN))
            {
                adornedelement.Height = adornedelement.DesiredSize.Height;
            }
            var parent = adornedelement.Parent as FrameworkElement;

            if (parent != null)
            {
                adornedelement.MaxHeight = parent.ActualHeight;
                adornedelement.MaxWidth = parent.ActualWidth;
            }
        }

        private void Bottomleft_DragDelta(object sender, DragDeltaEventArgs e)
        {
            {
                var adornedElement = AdornedElement as DragThumb;
                Thumb topRightCorner = sender as Thumb;
                if (adornedElement != null && topRightCorner != null)
                {
                    EnforceSize(adornedElement);

                    double oldWidth = adornedElement.Width;
                    double oldHeight = adornedElement.Height;

                    double newWidth = Math.Max(adornedElement.Width - e.HorizontalChange, topRightCorner.DesiredSize.Width);
                    double newHeight = Math.Max(adornedElement.Height + e.VerticalChange, topRightCorner.DesiredSize.Height);

                    double oldLeft = Canvas.GetLeft(adornedElement);
                    double newLeft = oldLeft - (newWidth - oldWidth);
                    adornedElement.Width = newWidth;
                    Canvas.SetLeft(adornedElement, newLeft);
                    adornedElement.Shape.Width = newWidth;
                    if (Canvas.GetLeft(adornedElement) <= 0)
                    {
                        Canvas.SetLeft(adornedElement, 0);
                        adornedElement.Width = oldWidth;
                        adornedElement.Shape.Width = adornedElement.Width;
                    }
                    adornedElement.Height = newHeight;
                    adornedElement.Shape.Height = newHeight;
                    if (Canvas.GetTop(adornedElement) <= 0)
                    {
                        Canvas.SetTop(adornedElement, 0);
                        adornedElement.Height = oldHeight;
                        adornedElement.Shape.Height = adornedElement.Height;
                    }
                }
            }
        }
        private void Topright_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var adornedElement = AdornedElement as DragThumb;
            Thumb topRightCorner = sender as Thumb;
            if (adornedElement != null && topRightCorner != null)
            {
                EnforceSize(adornedElement);

                double oldWidth = adornedElement.Width;
                double oldHeight = adornedElement.Height;

                double newWidth = adornedElement.Width + e.HorizontalChange;
                double newHeight = adornedElement.Height - e.VerticalChange;
                adornedElement.Width = newWidth;

                double oldTop = Canvas.GetTop(adornedElement);
                double newTop = oldTop - (newHeight - oldHeight);
                adornedElement.Height = newHeight;
                Canvas.SetTop(adornedElement, newTop);
                adornedElement.Shape.Width = newWidth;
                adornedElement.Shape.Height = newHeight;
                if (Canvas.GetTop(adornedElement) <= 0)
                {
                    Canvas.SetTop(adornedElement, 0);
                    adornedElement.Height = oldHeight;
                    adornedElement.Shape.Height = adornedElement.Height;
                }
            }
        }


        private void Topleft_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var adornedElement = AdornedElement as DragThumb;
            Thumb topLeftCorner = sender as Thumb;

            if (adornedElement != null && topLeftCorner != null)
            {
                EnforceSize(adornedElement);

                double oldWidth = adornedElement.Width;
                double oldHeight = adornedElement.Height;

                double newWidth = adornedElement.Width - e.HorizontalChange;
                double newHeight = adornedElement.Height - e.VerticalChange;

                double oldLeft = Canvas.GetLeft(adornedElement);
                double newLeft = oldLeft - (newWidth - oldWidth);
                adornedElement.Width = newWidth;
                Canvas.SetLeft(adornedElement, newLeft);
                adornedElement.Shape.Width = newWidth;
                if (Canvas.GetLeft(adornedElement) <= 0)
                {
                    Canvas.SetLeft(adornedElement, 0);
                    adornedElement.Width = oldWidth;
                    adornedElement.Shape.Width = adornedElement.Width;
                }
                double oldTop = Canvas.GetTop(adornedElement);

                double newTop = oldTop - (newHeight - oldHeight);
                adornedElement.Height = newHeight;
                Canvas.SetTop(adornedElement, newTop);
                adornedElement.Shape.Height = newHeight;
                if (Canvas.GetTop(adornedElement) <= 0)
                {
                    Canvas.SetTop(adornedElement, 0);
                    adornedElement.Height = oldHeight;
                    adornedElement.Shape.Height = adornedElement.Height;
                }
            }
        }
        private void BuilAdornerCorners(ref Thumb topleft, Cursor sizeNWSE)
        {
            if (topleft != null)
            {
                return;
            }
            topleft = new Thumb() { Cursor = sizeNWSE, Height = 10, Width = 10, Opacity = 0.5 };
            VisualChildren.Add(topleft);
        }
    }
}
