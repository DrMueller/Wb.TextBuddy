using Mmu.Wb.TextBuddy.Areas.Markdown.Models.Tables;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.ViewServices.Servants
{
    public interface ITableFactory
    {
        Table Parse(string markdown);
    }
}