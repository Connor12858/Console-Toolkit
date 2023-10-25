using System;
using System.Collections.Generic;
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
        public static string AddPaths(string[] paths)
        {
            return Path.Combine(paths);
        }

        // Adds a timestamp to the end of a file name
        public static string TimeStamp(string name)
        {
            string[] parts = name.Split('.');
            parts[0] += "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
            return string.Join(".", parts);
        }

        // Creates a text file and write to it
        public static void CreateFile(string path, string[] contents)
        {
            Console.WriteLine(path);
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                foreach (var item in contents)
                {
                    sw.WriteLine(item);
                }
            }
        }

        // Checks if the file exists
        public static bool FileExists(string path)
        {
            return System.IO.File.Exists(path);
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
                    ToolkitMethods.ColorWriteLine(file.FullName, ConsoleColor.Cyan);
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

        // Get all the files in a directory with recursion
        public static List<FileInfo> AllFilesInFolder(DirectoryInfo directory)
        {
            List<FileInfo> files = new List<FileInfo>();

            foreach(FileInfo file in directory.GetFiles())
            {
                files.Add(file);
            }

            foreach(DirectoryInfo directoryInfo in directory.GetDirectories())
            {
                files.AddRange(AllFilesInFolder(directoryInfo));
            }

            return files;
        }

        // Send an array of information of a file provided
        // Will be expanded on overall as needed
        public static Dictionary<string, string> FileInformation(FileInfo file)
        {
            // Create a list to store the information
            Dictionary<string, string> info = new Dictionary<string, string>();

            // Add the information 
            info.Add("Creation Time", file.CreationTime.ToString());
            info.Add("Name", file.Name.ToString());
            info.Add("Path", file.FullName.ToString());
            info.Add("Last Write", file.LastWriteTime.ToString());
            info.Add("Extension", file.Extension.ToString());

            // Send it back
            return info;
        }
    }
}
