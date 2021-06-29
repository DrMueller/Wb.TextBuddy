using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Wb.TextBuddy.Areas.Xml.Views
{
    public class XmlFunctionsViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        public CommandsViewData Commands => _commandContainer.Commands;

        public XmlFunctionsViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public string HeadingDescription => "XML";
        public string NavigationDescription => "XML";
        public int NavigationSequence => 4;

        public string XmlFilePath { get; set; }
        public string PropertyReferenceId { get; set; }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}