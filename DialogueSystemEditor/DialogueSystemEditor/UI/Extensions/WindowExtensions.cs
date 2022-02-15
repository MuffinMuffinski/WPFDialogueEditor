using DialogueSystemEditor.Configuration;
using DialogueSystemEditor.UI.WindowStateHandling;
using System;
using System.Windows;

namespace DialogueSystemEditor.UI.Extensions
{
    public static class WindowExtensions
    {
        public static void RestoreState(this Window window)
        {
            if (string.IsNullOrWhiteSpace(window.Name))
                throw new InvalidOperationException("Window.Name cannot be null or whitespace!");

            ApplicationSettings appSettings = ApplicationSettings.This;

            WindowStateSettings windowStateSettings = ApplicationSettings.DefaultWindowStateSettings;
            if (appSettings.WindowStates.ContainsKey(window.Name))
            {
                windowStateSettings = appSettings.WindowStates[window.Name];
            }
            
            window.Top = windowStateSettings.Top;
            window.Left = windowStateSettings.Left;
            window.Width = windowStateSettings.Width;
            window.Height = windowStateSettings.Height;
            window.WindowState = windowStateSettings.IsMaximized ? WindowState.Maximized : WindowState.Normal;
        }

        public static void SaveState(this Window window)
        {
            if (string.IsNullOrWhiteSpace(window.Name))
                throw new InvalidOperationException("Window.Name cannot be null or whitespace!");

            ApplicationSettings appSettings = ApplicationSettings.This;


            WindowStateSettings windowStateSettings = new WindowStateSettings();
            windowStateSettings.Top = window.Top;
            windowStateSettings.Left = window.Left;
            windowStateSettings.Height = window.Height;
            windowStateSettings.Width = window.Width;
            windowStateSettings.IsMaximized = window.WindowState == WindowState.Maximized;

            appSettings.WindowStates[window.Name] = windowStateSettings;
            appSettings.Save();
        }
    }
}
