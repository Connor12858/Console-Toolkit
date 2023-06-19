using System;
using System.IO;

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

        //Check line count from a file
        public static int LineCount(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines.Length;
        }

        // Delete all files in a folder and sub folder, returns delete count
        public static int DeleteFolderFiles(DirectoryInfo directory, string ext)
        {
            int count = 0;
            // Delete the files
            foreach (FileInfo file in directory.GetFiles())
            {
                if (ext == ".*" || file.Extension == ext)
                {
                    Console.WriteLine(file.FullName);
                    file.Delete();
                    count++;
                }
            }

            // DO it again for all sub directories - recursive :D
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                count += DeleteFolderFiles(dir, ext);
            }

            return count;
        }
    }
}
