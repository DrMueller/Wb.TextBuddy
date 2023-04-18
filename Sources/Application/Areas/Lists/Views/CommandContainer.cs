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


        private ViewModelCommand ToCommaSeparatedAndApostropheListCommand =>
            new ViewModelCommand(
                "To apo , list",
                new RelayCommand(
                    () =>
                    {
                        _context.Text = _listFunctionsService.TransformToCommaSeparatedAndApostrophedList(_context.Text);
                    },
                    () => !string.IsNullOrEmpty(_context.Text)));


        private ViewModelCommand AnalyzePerformance =>
            new ViewModelCommand(
                "Analyze Performance",
                new RelayCommand(
                    () =>
                    {
                        _context.Text = _listFunctionsService.AnalyzePerformance(_context.Text);
                    },
                    () => !string.IsNullOrEmpty(_context.Text)));

        private ViewModelCommand FormatNpmDependencies =>
           new ViewModelCommand(
               "Format NPM",
               new RelayCommand(
                   () =>
                   {
                       _context.Text = _listFunctionsService.FormatNpmDpenendecies(_context.Text);
                   },
                   () => !string.IsNullOrEmpty(_context.Text)));

        private ViewModelCommand FormDbSets =>
            new ViewModelCommand(
                "Format DbSets",
                new RelayCommand(
                    () =>
                    {
                        _context.Text = _listFunctionsService.FormatDbSets(_context.Text);
                    },
                    () => !string.IsNullOrEmpty(_context.Text)));


        public Task InitializeAsync(ListFunctionsViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData(
                ToCommaSeparatedListCommand,
                ToCommaSeparatedAndApostropheListCommand,
                SortListCommand,
                AnalyzePerformance,
                FormatNpmDependencies,
                FormDbSets
            );

            return Task.CompletedTask;
        }
    }
}