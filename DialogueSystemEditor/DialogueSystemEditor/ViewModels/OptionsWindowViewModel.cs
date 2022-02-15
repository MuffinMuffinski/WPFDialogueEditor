using DialogueSystemEditor.Commands;
using DialogueSystemEditor.Configuration;

namespace DialogueSystemEditor.ViewModels
{
    public class OptionsWindowViewModel : BaseViewModel
    {
        public RelayCommand SaveAndCloseCommand => new RelayCommand(
            (o) => { _appSettings.Save(); });
        public RelayCommand RemoveLastUsedCommand => new RelayCommand(
            (o) => 
            {
                if (!string.IsNullOrEmpty(SelectedLastOpened))
                {
                    _appSettings.LastOpened.Remove(SelectedLastOpened);
                }
            });

        private ApplicationSettings _appSettings;

        public ApplicationSettings ApplicationSettings
        {
            get { return _appSettings; }
            set
            {
                if (value != ApplicationSettings)
                { 
                    _appSettings = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedLastOpened;

        public string SelectedLastOpened
        {
            get { return _selectedLastOpened; }
            set 
            { 
                if (value != SelectedLastOpened)
                {
                    _selectedLastOpened = value;
                    OnPropertyChanged();
                }
            }
        }


        public OptionsWindowViewModel()
        {

            ApplicationSettings = ApplicationSettings.This;
        }
    }
}
