using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mmu.Wb.TextBuddy.Areas.Xml.ViewServices.Implementation
{
    public class XmlSplitService : IXmlSplitService
    {
        public Task SplitToPropAndProjAsync(string xmlFilePath, string propertyReferenceId)
        {
            var doc = XDocument.Load(xmlFilePath);
            var propertyRefElement = doc.Descendants().Single(f => f.Value == propertyReferenceId);
            var propertyElement = propertyRefElement.Parent;
            var unitReferenceId = propertyElement.Descendants().Single(f => f.Name == "unitReferenceId").Value;
            var unitElement = doc.Descendants().Single(f => f.Name == "unit" && f.Element("referenceId").Value == unitReferenceId);
            var projectElement = unitElement.Parent.Parent;

            var xsd = XNamespace.Get("http://www.w3.org/2001/XMLSchema");
            var xsi = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");

            var newDoc = new XElement(
                "export",
                new XAttribute(XNamespace.Xmlns + "xsd", xsd),
                new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                new XAttribute(xsi + "noNamespaceSchemaLocation", "https://swissrets.ch/dist/v2.3.0/schema.xsd"));

            newDoc.Add(new XElement("projects", projectElement));
            newDoc.Add(new XElement("properties", propertyElement));

            newDoc.Save(@"C:\Users\mlm\Desktop\NewFile.xml");

            return Task.CompletedTask;
        }
    }
}