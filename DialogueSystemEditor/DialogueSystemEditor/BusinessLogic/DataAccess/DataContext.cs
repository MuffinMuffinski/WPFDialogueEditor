using DialogueSystemEditor.Helpers;
using DialogueSystemEditor.Model.DataLayer;

namespace DialogueSystemEditor.BusinessLogic.DataAccess
{
    public static class DataContext
    {
        public static Dialogue LoadFromFile(string _fileName)
        {
            return BinaryFormatterHelper.LoadFromBinaryFile<Dialogue>(_fileName);
        }

        public static void SafeToFile(Dialogue _dialogue, string _fileName)
        {
            BinaryFormatterHelper.SaveToBinaryFile(_dialogue, _fileName);
        }
    }
}
