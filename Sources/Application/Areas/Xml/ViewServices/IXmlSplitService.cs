using System.Threading.Tasks;

namespace Mmu.Wb.TextBuddy.Areas.Xml.ViewServices
{
    public interface IXmlSplitService
    {
        Task SplitToPropAndProjAsync(string xmlFilePath, string propertyReferenceId);
    }
}