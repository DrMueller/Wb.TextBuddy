using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Wb.TextBuddy.Areas.Xml.Views
{
    /// <summary>
    ///     Interaction logic for XmlFunctionsView.xaml
    /// </summary>
    public partial class XmlFunctionsView : UserControl, IViewMap<XmlFunctionsViewModel>
    {
        public XmlFunctionsView()
        {
            InitializeComponent();
        }
    }
}