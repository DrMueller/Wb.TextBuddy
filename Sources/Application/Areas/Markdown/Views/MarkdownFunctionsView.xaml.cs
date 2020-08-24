using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.Views
{
    public partial class MarkdownFunctionsView : UserControl, IViewMap<MarkdownFunctionsViewModel>
    {
        public MarkdownFunctionsView()
        {
            InitializeComponent();
        }
    }
}