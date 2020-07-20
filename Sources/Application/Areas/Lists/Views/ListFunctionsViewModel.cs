using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Wb.TextBuddy.Areas.Lists.Views
{
    public class ListFunctionsViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;

        private string _text;

        public ListFunctionsViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public CommandsViewData Commands => _commandContainer.Commands;

        public string HeadingDescription { get; } = "List Functions";
        public string NavigationDescription { get; } = "Lists";
        public int NavigationSequence { get; } = 2;

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