using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogueSystemEditor.Model.DataLayer
{
    [Serializable]
    public class Dialogue
    {
        public string DialogueName { get; set; }
        public ObservableCollection<DialoguePart> TopElements { get; set; } = new ObservableCollection<DialoguePart>();
    }
}
