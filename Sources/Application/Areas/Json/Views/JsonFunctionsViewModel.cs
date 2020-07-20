using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Wb.TextBuddy.Areas.Json.Views
{
    [PublicAPI]
    public class JsonFunctionsViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;

        private string _text;

        public JsonFunctionsViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public CommandsViewData Commands => _commandContainer.Commands;

        public string HeadingDescription { get; } = "JSON Functions";
        public string NavigationDescription { get; } = "JSON";
        public int NavigationSequence { get; } = 1;

        public string Text
        {
            get => _text;
            set
            {
                if (_text == value)
                {
                    return;
                }

                _text = value;
                OnPropertyChanged();
            }
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}