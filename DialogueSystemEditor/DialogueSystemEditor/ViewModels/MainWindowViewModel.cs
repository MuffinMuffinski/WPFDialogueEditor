using DialogueSystemEditor.Commands;
using DialogueSystemEditor.Configuration;
using DialogueSystemEditor.Model.DataLayer;
using DialogueSystemEditor.UI.Windows;
using Microsoft.Win32;
using System.Windows;

namespace DialogueSystemEditor.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand OpenOptionsCommand => new RelayCommand(
            (o) =>
            {
                new OptionsWindow().ShowDialog();
            });
        public RelayCommand NewCommand => new RelayCommand(NewDialogue, CanCreate);

        public RelayCommand SaveCommand => new RelayCommand(SaveFile, CanSave);

        public RelayCommand OpenCommand => new RelayCommand(OpenFile, CanOpen);

        public RelayCommand ExitCommand => new RelayCommand((o) => { 
            Application.Current.Shutdown();
        });

        public RelayCommand NewRootElementCommand => new RelayCommand(NewRootElement, CanCreateRootElement);

        public RelayCommand NewElementCommand => new RelayCommand(NewElement, CanCreateElement);

        public RelayCommand DeleteElementCommand => new RelayCommand(DeleteElement, CanDeleteElement);

        public ApplicationSettings ApplicationSettings => ApplicationSettings.This;

        private void DeleteElement(object obj)
        {
            if (this.SelectedDialoguePart.Parent == null)
            {
                this.Dialogue.TopElements.Remove(this.SelectedDialoguePart);
            }
            else
            {
                this.SelectedDialoguePart.Parent.Children.Remove(this.SelectedDialoguePart);
            }
        }

        private bool CanDeleteElement(object arg)
        {
            return CanCreateElement(arg);
        }

        private void NewElement(object obj)
        {
            var newElement = new DialoguePart()
            {
                ContentPreview = "NEW SUB ELEMENT",
                Parent = this.SelectedDialoguePart
            };
            this.SelectedDialoguePart.Children.Add(newElement);
        }

        private bool CanCreateElement(object arg)
        {
            return this.SelectedDialoguePart != null;
        }

        private void NewRootElement(object obj)
        {
            this.Dialogue.TopElements.Add(new DialoguePart() { ContentPreview = "NEW ROOT ELEMENT" });
            OnPropertyChanged("Dialogue");
        }

        private bool CanCreateRootElement(object arg)
        {
            return Dialogue != null;
        }

        private void OpenFile(object obj)
        {
            string filename = string.Empty;
            if (obj != null)
            {
                filename = obj.ToString();
            }
            else
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Binary file (*.bin) | *.bin";
                if (openFile.ShowDialog() == true)
                {
                    filename = openFile.FileName;
                }
            }

            this.Dialogue = BusinessLogic.DataAccess.DataContext.LoadFromFile(filename);
            ApplicationSettings appSettings = ApplicationSettings.This;
            appSettings.LastOpened.Add(filename);
            appSettings.Save();
        }


        private bool CanOpen(object arg)
        {
            return CanCreate(arg);
        }


        private bool m_isSaved;

        private DialoguePart _selectedDialoguePart;

        public DialoguePart SelectedDialoguePart
        {
            get { return _selectedDialoguePart; }
            set 
            {
                if (value != SelectedDialoguePart)
                {
                    _selectedDialoguePart = value;
                    OnPropertyChanged();
                }
            }
        }


        private Dialogue _dialogue;

        public Dialogue Dialogue
        {
            get { return _dialogue; }
            set 
            {
                if (value != Dialogue)
                {
                    _dialogue = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool CanCreate(object arg)
        {
            return Dialogue == null || Dialogue != null && m_isSaved;
        }

        private void NewDialogue(object obj)
        {
            Dialogue = new Dialogue();
            
        }

        private void SaveFile(object _parameter)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Binary file (*.bin) | *.bin";
            if (saveFile.ShowDialog() == true)
            {
                BusinessLogic.DataAccess.DataContext.SafeToFile(Dialogue, saveFile.FileName);
            }
            m_isSaved = true;
        }

        private bool CanSave(object _parameter)
        {
            return Dialogue != null;
        }


    }
}
