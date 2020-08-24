using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Wb.TextBuddy.Areas.Markdown.ViewServices;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.Views
{
    public class CommandContainer : IViewModelCommandContainer<MarkdownFunctionsViewModel>
    {
        private readonly IMarkdownFunctionsService _markdownFunctionsService;
        private MarkdownFunctionsViewModel _context;

        public CommandContainer(IMarkdownFunctionsService markdownFunctionsService)
        {
            _markdownFunctionsService = markdownFunctionsService;
        }

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand CleanTableCommand =>
            new ViewModelCommand(
                "Clean Table",
                new RelayCommand(
                    () =>
                    {
                    },
                    () => !string.IsNullOrEmpty(_context.Text)));

        public Task InitializeAsync(MarkdownFunctionsViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData();

            return Task.CompletedTask;
        }
    }
}