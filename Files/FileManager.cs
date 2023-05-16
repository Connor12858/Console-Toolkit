using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace Console_Toolkit.Files
{
    internal class FileManager
    {
        // Read all the lines from a file
        public static string[] ReadFromFile(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }

        // Check if a folder exists
        public static bool FolderDoesExist(string path)
        {
            return Directory.Exists(path);
        }

        // Get the special directory from a string
        public static string SpecialDirectory(string directory)
        {
            Environment.SpecialFolder specialFolder = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), directory);
            return Environment.GetFolderPath(specialFolder);
        }
        
        // Add to directories together
        public static string AddDirectory(string[] paths)
        {
            return Path.Combine(paths);
        }

        // Save text to a file
        public static void CreateTextFile (string path, string text)
        {
            
        }
        public static void CreateTextFile(string path, string[] text)
        {

        }
    }
}
