using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Wb.TextBuddy.Areas.Xml.ViewServices;

namespace Mmu.Wb.TextBuddy.Areas.Xml.Views
{
    public class CommandContainer : IViewModelCommandContainer<XmlFunctionsViewModel>
    {
        private readonly IInformationPublisher _informationPublisher;
        private readonly IXmlSplitService _xmlSplitService;
        private XmlFunctionsViewModel _context;

        public CommandContainer(IXmlSplitService xmlSplitService, IInformationPublisher informationPublisher)
        {
            _xmlSplitService = xmlSplitService;
            _informationPublisher = informationPublisher;
        }

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand SplitXmlCommand =>
            new ViewModelCommand(
                "Split XML",
                new AsyncRelayCommand(
                    async () =>
                    {
                        _informationPublisher.Publish(InformationEntry.CreateInfo("Transforming..", true));
                        await _xmlSplitService.SplitToPropAndProjAsync(_context.XmlFilePath, _context.PropertyReferenceId);
                        _informationPublisher.Publish(InformationEntry.CreateSuccess("Transforming done", false, 5));
                    },
                    () => !string.IsNullOrEmpty(_context.XmlFilePath) && !string.IsNullOrEmpty(_context.PropertyReferenceId)));

        public Task InitializeAsync(XmlFunctionsViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(SplitXmlCommand);

            return Task.CompletedTask;
        }
    }
}