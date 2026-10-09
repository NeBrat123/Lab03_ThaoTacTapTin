using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ChuDe3.XmlFileDemo
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
                var inputPath = Path.Combine(dataDirectory, "books-input.xml");
                var writerPath = Path.Combine(dataDirectory, "books-writer-output.xml");
                var serializedPath = Path.Combine(dataDirectory, "books-serialized.xml");

                ReadWithXPath(inputPath);
                WriteWithXmlWriter(writerPath);
                SerializeBooks(serializedPath);

                if (!File.Exists(writerPath) || !File.Exists(serializedPath)) throw new InvalidOperationException("Không tạo được các tệp XML đầu ra.");
                if (Array.IndexOf(args, "--self-test") >= 0) Console.WriteLine("XML_DEMO_OK");
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return 1;
            }
        }

        private static void ReadWithXPath(string path)
        {
            var document = new XmlDocument();
            document.Load(path);
            var nodes = document.DocumentElement.SelectNodes("/catalog/book");
            Console.WriteLine("Danh sách sách đọc bằng XmlDocument/XPath:");
            foreach (XmlNode node in nodes)
            {
                var isbn = node.Attributes["ISBN"].Value;
                var title = node.SelectSingleNode("title").InnerText;
                var firstName = node.SelectSingleNode("author/first-name").InnerText;
                var lastName = node.SelectSingleNode("author/last-name").InnerText;
                var price = node.SelectSingleNode("price").InnerText;
                Console.WriteLine("{0,-12} {1} - {2} {3} - {4}", isbn, title, firstName, lastName, price);
            }
        }

        private static void WriteWithXmlWriter(string path)
        {
            var settings = new XmlWriterSettings { Encoding = new UTF8Encoding(false), Indent = true };
            using (var writer = XmlWriter.Create(path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"book.xsl\"");
                writer.WriteDocType("book", null, null, "<!ENTITY h \"hardcover\">");
                writer.WriteComment("This is a book sample XML");
                writer.WriteStartElement("book");
                writer.WriteAttributeString("ISBN", "9831123212");
                writer.WriteAttributeString("yearpublished", "2002");
                writer.WriteElementString("author", "Mahesh Chand");
                writer.WriteElementString("title", "Visual C# Programming");
                writer.WriteElementString("price", "44.95");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void SerializeBooks(string path)
        {
            var books = new List<Book>
            {
                new Book { ISBN = "9831123212", Title = "A Programmer's Guide to ADO .Net using C#", Author = "Mahesh Chand", Price = 44.99m, YearPublished = 2002 },
                new Book { ISBN = "9781484234", Title = "Pro Entity Framework Core 2", Author = "Adam Freeman", Price = 45.09m, YearPublished = 2019 }
            };
            var serializer = new XmlSerializer(typeof(List<Book>));
            using (var stream = new StreamWriter(path, false, new UTF8Encoding(false))) serializer.Serialize(stream, books);
        }
    }
}
