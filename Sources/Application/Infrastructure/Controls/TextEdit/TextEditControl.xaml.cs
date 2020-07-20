using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;

namespace Mmu.Wb.TextBuddy.Infrastructure.Controls.TextEdit
{
    public partial class TextEditControl
    {
        public static readonly DependencyProperty CommandsProperty = DependencyProperty.Register(nameof(Commands), typeof(CommandsViewData), typeof(TextEditControl));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextEditControl));

        public TextEditControl()
        {
            InitializeComponent();
        }

        public CommandsViewData Commands
        {
            get => (CommandsViewData)GetValue(CommandsProperty);
            set => SetValue(CommandsProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }
}