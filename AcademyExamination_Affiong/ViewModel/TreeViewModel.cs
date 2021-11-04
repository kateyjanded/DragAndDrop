using DataAcessLibrary.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace AcademyExamination_Affiong.ViewModel
{
    public class TreeViewModel
    {
        public TreeViewModel()
        {
            Items = new ObservableCollection<TreeViewItem>();
        }
        public SoftwareAcademy xmlNode { get; set; }
        private string file;

        public string File
        {
            get { return file; }
            set
            {
                file = value;
                GetObjects();
            }
        }
        public void PopulateTreeview()
        {
            XmlDocument xdc = new XmlDocument();
            xdc.Load(File);
            TreeViewItem treeviewItemRoot = new TreeViewItem();
            treeviewItemRoot.Header = "Software Academy";
            Items.Add(treeviewItemRoot);
            TreeViewItem tNode = new TreeViewItem();
            tNode = Items[0];
            addTreeNode(xdc.DocumentElement, tNode);
        }
        private void addTreeNode(XmlNode xmlNode, TreeViewItem treeNode)
        {
            XmlNode xNode;
            TreeViewItem tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes)
            {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                {
                    xNode = xmlNode.ChildNodes[x];
                    var item = new TreeViewItem();
                    item.Header = xNode.LocalName;
                    if (item.Header.ToString() == "#text")
                    {
                        item.Header = xNode.Value;
                    }
                    treeNode.Items.Add(item);
                    tNode = treeNode.Items[x] as TreeViewItem;
                    addTreeNode(xNode, tNode);
                }
            }
        }
        private TreeViewItem selectedElement;

        public TreeViewItem SelectedElement
        {
            get { return selectedElement; }
            set { selectedElement = value;
                OnSelectedChange();
            }
        }
        private void OnSelectedChange()
        {
            if (SelectedElement.Header != null)
            {
                Shape shape = null;
                Type t = typeof(Brushes);
                Brush b = null;
                if (SelectedElement.Header.ToString() == "Circle")
                {
                    var circle = new Circles();
                    circle.Height = xmlNode.Shapes.Circle[0].Properties.Height;
                    circle.Width = xmlNode.Shapes.Circle[0].Properties.Width;
                    b= (Brush)t.GetProperty(xmlNode.Shapes.Circle[0].Properties.Color).GetValue(null, null);
                    shape = circle;
                }
                else if (SelectedElement.Header.ToString() == "Triangle")
                {
                    var circle = new Triangles();
                    circle.Height = xmlNode.Shapes.Triangle[0].Properties.Height;
                    circle.Width = xmlNode.Shapes.Triangle[0].Properties.Width;
                    b = (Brush)t.GetProperty(xmlNode.Shapes.Triangle[0].Properties.Color).GetValue(null, null);
                    shape = circle;
                }
                else
                {
                    var circle = new Squares();
                    circle.Height = xmlNode.Shapes.Square[0].Properties.Height;
                    circle.Width = xmlNode.Shapes.Square[0].Properties.Width;
                    b = (Brush)t.GetProperty(xmlNode.Shapes.Square[0].Properties.Color).GetValue(null, null);
                    shape = circle; 
                }
                if (shape != null)
                {
                    shape.Fill = b;
                    shape.Stretch = Stretch.Fill;
                    DataObject obj = new DataObject();
                    obj.SetData("shapes", shape);
                    DragDrop.DoDragDrop(SelectedElement, obj, DragDropEffects.Move);
                }
            }
        }
        public ObservableCollection<TreeViewItem> Items  { get; set; }

        public void GetObjects()
        {
            XmlReader read = new XmlReader(File);
            xmlNode = read.ReadFile();
            PopulateTreeview();
        }
    }
}
