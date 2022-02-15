using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DialogueSystemEditor.Model.DataLayer
{
    [Serializable]
    public class DialoguePart 
    {
        public string Content { get; set; }
        public string ContentPreview { get; set; }
        public ObservableCollection<DialoguePart> Children { get; set; } = new ObservableCollection<DialoguePart>();
        public DialoguePart Parent { get; set; }
    }
}