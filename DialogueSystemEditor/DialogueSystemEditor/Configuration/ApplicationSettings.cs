using DialogueSystemEditor.UI.WindowStateHandling;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace DialogueSystemEditor.Configuration
{
    public class ApplicationSettings
    {
        [JsonIgnore]
        public static string AppConfigFolder => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            Assembly.GetExecutingAssembly().GetName().Name);
        [JsonIgnore]
        public static string AppConfigFilename => Path.Combine(AppConfigFolder, "settings.json");
        public static WindowStateSettings DefaultWindowStateSettings = new WindowStateSettings()
        {
            Height = 720d,
            Width = 1080d,
            Top = 30d,
            Left = 30d,
            IsMaximized = false
        };

        [JsonProperty("useCustomMainWindowStateSettings")]
        public bool UseCustomMainWindowStateSettings { get; set; }

        [JsonProperty("lastOpened")]
        public ObservableCollection<string> LastOpened { get; set; }
        [JsonProperty("WindowStateSettings")]
        public Dictionary<string, WindowStateSettings> WindowStates { get; set; }

        public static ApplicationSettings This
        { 
            get 
            {
                if (_instance == null)
                    _instance = Load();
                return _instance;
            } 
        }
        private static ApplicationSettings _instance;

        private static ApplicationSettings Load()
        {
            if (File.Exists(AppConfigFilename))
            {
                var json = File.ReadAllText(AppConfigFilename);
                return JsonConvert.DeserializeObject<ApplicationSettings>(json);
            }
            else
            {
                return new ApplicationSettings()
                {
                    LastOpened = new ObservableCollection<string>(),
                    WindowStates = new Dictionary<string, WindowStateSettings>()
                    {
                        { "_MAINWINDOW", DefaultWindowStateSettings } 
                    }
                };
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this);
            Directory.CreateDirectory(AppConfigFolder);
            File.WriteAllText(AppConfigFilename, json);
        }
    }
}
