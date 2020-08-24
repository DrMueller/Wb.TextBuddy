using Mmu.Wb.TextBuddy.Areas.Markdown.ViewServices.Servants;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.ViewServices.Implementation
{
    public class MarkdownFunctionsService : IMarkdownFunctionsService
    {
        private readonly ITableFactory _tableFactory;

        public MarkdownFunctionsService(ITableFactory tableFactory)
        {
            _tableFactory = tableFactory;
        }

        public string CleanTable(string markdown)
        {
            var table = _tableFactory.Parse(markdown);

            return table.ToMarkdown();
        }
    }
}