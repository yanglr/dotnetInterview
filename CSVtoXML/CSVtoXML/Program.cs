using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CSVtoXML
{
    class Program
    {
        private static void AddContentForEachLine(string line, ref XElement xmlTree)
        {
            var currentTree = new XElement("Item");
            string[] slices = line.Split(",");

            for (int i = 0; i < slices.Count(); i++)
                currentTree.Add(new XElement($"Column{i}", slices[i].ToString()));

            xmlTree.Add(currentTree);
        }

        static void Main(string[] args)
        {
            var basePath = Environment.CurrentDirectory;
            var lines = File.ReadAllLines(Path.Combine(basePath, "../../..", @"input.csv"));

            var xmlTree = new XElement("Root");

            foreach (var line in lines)
            {
                AddContentForEachLine(line, ref xmlTree);
            }

            xmlTree.Save(Path.Combine(basePath, "../../..", @"output.xml"));
        }
    }
}
