using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Wb.TextBuddy.Areas.Lists.ViewServices;

namespace Mmu.Wb.TextBuddy.Areas.Lists.Views
{
    public class CommandContainer : IViewModelCommandContainer<ListFunctionsViewModel>
    {
        private readonly IListFunctionsService _listFunctionsService;
        private ListFunctionsViewModel _context;

        public CommandContainer(IListFunctionsService listFunctionsService)
        {
            _listFunctionsService = listFunctionsService;
        }

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand SortListCommand =>
            new ViewModelCommand(
                "Sort",
                new RelayCommand(
                    () =>
                    {
                        _context.Text = _listFunctionsService.SortList(_context.Text);
                    },
                    () => !string.IsNullOrEmpty(_context.Text)));

        private ViewModelCommand ToCommaSeparatedListCommand =>
            new ViewModelCommand(
                "To , list",
                new RelayCommand(
                    () =>
                    {
                        _context.Text = _listFunctionsService.TransformToCommaSeparatedList(_context.Text);
                    },
                    () => !string.IsNullOrEmpty(_context.Text)));

        public Task InitializeAsync(ListFunctionsViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData(
                ToCommaSeparatedListCommand,
                SortListCommand
            );

            return Task.CompletedTask;
        }
    }
}