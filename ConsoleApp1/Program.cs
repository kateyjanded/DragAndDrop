using DataAcessLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Node<T>
    {
        public T Value { get; set; }
        public int ChildrenCount
        {
            get
            {
                return Children.Count;
            }
        }

        public List<Node<T>> Children;
        public Node(T value, Node<T> node): this(value)
        {
            
        }
        public Node(T value)
        {
            Value = value;
            Children = new List<Node<T>>();
        }
    }
    public class Tree<T>
    {
        public Node<T> Root;
        public Tree(Node<T> root)
        {
            Root = root;
        }

        public void AddChild(Node<T> child, Node<T> parent)
        {
            parent.Children.Add(child);
        }
    }

    public class Program
    {
       
        static void Main(string[] args)
        {
            Read(@"C:\Users\affiong.asuquo\Desktop\academyexamfile3.txt");
            Console.ReadKey();
        }


        public static void Read(string FileName)
        {

            XmlSerializer deserializer = new XmlSerializer(typeof(SoftwareAcademy), new XmlRootAttribute("SoftwareAcademyExamination"));
            TextReader reader = new StreamReader(FileName);
            object obj = deserializer.Deserialize(reader);
            SoftwareAcademy XmlData = (SoftwareAcademy)obj;
            reader.Close();
            //using (XmlReader reader = XmlReader.Create(FileName))
            //{
            //    while (reader.Read())
            //    {
            //        if (true)
            //        {

            //        }
            //        if (reader.IsStartElement())
            //        {
            //            //return only when you have START tag  
            //            switch (reader.Name.ToString())
            //            {
            //                case "Height":
            //                    Console.WriteLine("Name of the Element is : " + reader.ReadString());
            //                    break;
            //                case "Width":
            //                    Console.WriteLine("Your Location is : " + reader.ReadString());
            //                    break;
                               
            //            }
            //        }
            //    }
            }
            //Console.ReadKey();
            //XmlDocument xdc = new XmlDocument();
            //xdc.Load(FileName);
            //XmlNode xmlNode = xdc.DocumentElement;
            //Tree<string> treenode = new Tree<string>(new Node<string>(xmlNode.LocalName));
            //AddTreeNode(xmlNode, treenode.Root, treenode);
              
            //if (xmlNode.HasChildNodes)
            //{
            //    XmlNodeList xmlNodeList = xmlNode.ChildNodes;
            //}
            //foreach (var item in xmlNodeList)
            //{
            //    XmlElement xmlElement = (XmlElement)item;
            //    Console.WriteLine(xmlElement.ToString());
            //}
            }

        //private static void AddTreeNode(XmlNode xmlNode, Node<string> treeNode, Tree<string> tree)
        //{
        //    XmlNode xml;
        //    if (xmlNode.HasChildNodes)
        //    {
                
        //        XmlNodeList xNodeList = xmlNode.ChildNodes;
        //        for (int i = 0; i < xNodeList.Count; i++)
        //        {
        //            Queue<XmlNode> queue = new Queue<XmlNode>();
        //            xml = xmlNode.ChildNodes[i];
        //            queue.Enqueue(xml);
        //            while (queue.Count>0)
        //            {
        //                var child = new Node<string>(queue.Dequeue().LocalName);
        //                tree.AddChild(child, tree.Root);
        //                tree.Root = child;
        //                XmlNodeList xn = xml.ChildNodes;
        //                for (int j = 0; j < xn.Count; i++)
        //                {
        //                    var mn = xml.ChildNodes[j];
        //                    queue.Enqueue(mn);
        //                }
        //            }
        //        }
                
        //    }
        //}
    }
    


