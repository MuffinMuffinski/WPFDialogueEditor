using DialogueSystemEditor.UI.Extensions;
using System.Windows;

namespace DialogueSystemEditor.UI.Windows
{
    /// <summary>
    /// Interaktionslogik für OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
            this.RestoreState();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void _OPTIONSWINDOW_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.SaveState();
        }
    }
}
