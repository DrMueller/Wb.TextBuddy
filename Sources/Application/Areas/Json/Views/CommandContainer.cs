using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Wb.TextBuddy.Areas.Json.ViewServices;

namespace Mmu.Wb.TextBuddy.Areas.Json.Views
{
    public class CommandContainer : IViewModelCommandContainer<JsonFunctionsViewModel>
    {
        private readonly IJsonFunctionsService _jsonFunctions;
        private JsonFunctionsViewModel _context;

        public CommandContainer(IJsonFunctionsService jsonFunctions)
        {
            _jsonFunctions = jsonFunctions;
        }

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand PrettifyJson =>
            new ViewModelCommand(
                "Prettify",
                new RelayCommand(
                    () =>
                    {
                        _context.Text = _jsonFunctions.PrettifyJson(_context.Text);
                    },
                    () => !string.IsNullOrEmpty(_context.Text)));

        public Task InitializeAsync(JsonFunctionsViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(PrettifyJson);

            return Task.CompletedTask;
        }
    }
}