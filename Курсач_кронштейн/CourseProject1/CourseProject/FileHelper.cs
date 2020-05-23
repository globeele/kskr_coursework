using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CourseProject
{
    static class FileHelper
    {
        //Считывание из файла узлов
        static public List<Node> ReadFileNodes()
        {
            Node node;
            List<Node> nodes = new List<Node>();
            StreamReader file = new StreamReader("4n.txt");
            while (!file.EndOfStream)
            {
                string s = file.ReadLine();
                s = s.TrimStart();
                s = s.TrimEnd();
                List<string> ss = s.Split().ToList<string>();
                for (int i = 0; i < ss.Count; i++)
                    if (ss[i] == "")
                    {
                        ss.RemoveAt(i);
                        i--;
                    }
                if (ss.Count == 5)
                    node = new Node(Convert.ToInt32(ss[0]), Convert.ToSingle(ss[1]), Convert.ToSingle(ss[2]), Convert.ToBoolean(ss[4]));
                else
                    node = new Node(Convert.ToInt32(ss[0]), Convert.ToSingle(ss[1]), Convert.ToSingle(ss[2]), false);
                nodes.Add(node);
            }
            return (nodes);
        }

        //Считывание из файла элементов
        static public List<Element> ReadFileElements(List<Node> nodes)
        {
            Element element;
            List<Element> elements = new List<Element>();
            StreamReader file = new StreamReader("4e.txt");
            while (!file.EndOfStream)
            {
                string s = file.ReadLine();
                s = s.TrimStart();
                s = s.TrimEnd();
                List<string> ss = s.Split().ToList<string>();
                for (int i = 0; i < ss.Count; i++)
                    if (ss[i] == "")
                    {
                        ss.RemoveAt(i);
                        i--;
                    }
                element = new Element(Convert.ToInt32(ss[0]), nodes[Convert.ToInt32(ss[6]) - 1], nodes[Convert.ToInt32(ss[7]) - 1], nodes[Convert.ToInt32(ss[8]) - 1]);
                elements.Add(element);
            }
            return (elements);
        }
    }
}
