using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DialogueSystemEditor.Helpers
{
    public static class BinaryFormatterHelper
    {
        public static void SaveToBinaryFile(object obj, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, obj);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public static T LoadFromBinaryFile<T>(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and
                // assign the reference to the local variable.
                return (T)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
