using DialogueSystemEditor.Configuration;
using DialogueSystemEditor.Model.DataLayer;
using DialogueSystemEditor.Properties;
using DialogueSystemEditor.UI.Extensions;
using DialogueSystemEditor.ViewModels;
using System.Windows;

namespace DialogueSystemEditor
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Settings m_settings = new Settings();

        public MainWindow()
        {
            InitializeComponent();
            this.RestoreState();
        }
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MainWindowViewModel viewModel = (MainWindowViewModel)this.DataContext;
            viewModel.SelectedDialoguePart = (DialoguePart)e.NewValue; 
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (ApplicationSettings.This.UseCustomMainWindowStateSettings)
                return;
            this.SaveState();
        }
    }
}
