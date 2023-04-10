//Created By ThatDevConnor
//TODO:
//Delete subfolder files
//Copy subfolder files

using System;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Console_Toolkit
{
    class Program
    {
        //Sets all necassary varibles
        public static string directoryLocation = "Desktop";
        public static string ipv6;
        public static string ipv4;
        public static string computerName;
        public static string[] copiedFiles = new string[] { };

        //Array of avalible locations
        public static string[] possibleLocations = new string[]
            {"Desktop", "MyDocuments", "MyPictures", "MyMusic", "Startup", "StartMenu"};

        //Runs at the beginning of the program
        static void Main()
        {
            //Sets up the Console design
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "Terminal";
            Console.ForegroundColor = ConsoleColor.White;

            Menu();
        }

        //Determins the base folder path
        static string FolderBase()
        {
            string basePath = "";

            if (directoryLocation == "Startup")
            {
                basePath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            }
            else if (directoryLocation == "StartMenu")
            {
                basePath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            }
            else if (directoryLocation == "MyMusic")
            {
                basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            }
            else if (directoryLocation == "MyPictures")
            {
                basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            else if (directoryLocation == "MyDocuments")
            {
                basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else if (directoryLocation == "Desktop")
            {
                basePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            return basePath;
        }

        //Creates the menu
        static void Menu()
        {
            //Sets up the Menu frame
            Console.WriteLine("==========================");
            Console.WriteLine("           MENU           ");
            Console.WriteLine("==========================\n");

            //Runs the command line
            Console.Write("Console >  ");

            //Gets user input on the acion to take
            string input = Console.ReadLine();

            //If a certain text is written then we run the function
            if (input == "Program.Close()")
            {
                Console.Write("\nRunning Program.Close()...\n\nExitCode > ");
                string closeInput = Console.ReadLine();
                //Get the exitcode for when we quit the program
                int newExitCode = Int32.Parse(closeInput);
                QuitApplication(newExitCode);
            }

            //Just runs menu again
            else if (input == "Program.Start()")
            {
                Console.WriteLine("");
                Console.Clear();
                Menu();
            }

            //Detects that we want to play with directories
            else if (input == "System Directory")
            {
                Console.WriteLine("\nAccessinng System Directory...");
                Thread.Sleep(2647);
                Directories();
            }

            //Detects that we want to play with directories
            else if (input == "System File")
            {
                Console.WriteLine("\nAccessinng System File...");
                Thread.Sleep(2647);
                Files();
            }

            //Runs the IP
            else if (input == "System IP")
            {
                Console.WriteLine("\nAccessinng System IP...");
                Thread.Sleep(2647);
                IP();
            }

            //Runs the IP
            else if (input == "Program.FBrute()")
            {
                Console.WriteLine("\nLaunching Fake Bruteforce...");
                Thread.Sleep(1325);
                FBrute();
            }

            //Runs the Ceaser
            else if (input == "Program.Decrypt()")
            {
                Console.WriteLine("\nLaunching Ceaser Decrpyt...");
                Thread.Sleep(1325);
                Decrypt();
            }

            //Runs the email function
            else if (input == "Program.Email()")
            {
                //Gets user input for the 'port'
                Console.Write("\nConnecting to Ethernet...\n\nPort > ");
                string portInput = Console.ReadLine();
                int portNumber = Int32.Parse(portInput);
                SendEmailToMe(portNumber);
            }

            //Displays the help menu
            else if (input == "Program.Help()")
            {
                Help();
            }

            else
            {
                Help();
            }
        }

        //This runs when Help() is typed or invaild command
        public static void Help()
        {
            //Our help menu
            Console.Clear();
            Console.WriteLine("            《《 HELP 》》");
            Console.WriteLine("     Program");
            Console.WriteLine("        Close() - Closes Program");
            Console.WriteLine("        Help() - Opens this menu");
            Console.WriteLine("        Email() - Sends email");
            Console.WriteLine("        FBrute() - Trial bruteforce");
            Console.WriteLine("        Decrpyt() - Ceaser Decrypt Program");
            Console.WriteLine("     System");
            Console.WriteLine("        Directory - Takes you to 'Directory Menu'");
            Console.WriteLine("           cd - Changes folder location");
            Console.WriteLine("        File - Takes you to 'File Menu'");
            Console.WriteLine("           write - Creates a document");
            Console.WriteLine("           delete - Deletes a certain document");
            Console.WriteLine("           copy - Copies a file or entire directory");
            Console.WriteLine("        IP - Takes you to 'IP Menu'");
            Console.WriteLine("           get - Retrieve the IP info");
            Console.WriteLine("           email - Emails the IP info");
            Console.WriteLine("           show - Displays the IP info");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ReadLine();
            Console.Clear();
            Menu();
        }

        //Directory cmds
        static void Directories()
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("      DIRECTORY MENU      ");
            Console.WriteLine("==========================");

            //Runs the command line
            Console.Write("Directory.{0} >  ", directoryLocation);

            //Gets user input on the acion to take
            string input = Console.ReadLine();

            //if input is 'cd' than change the directory location
            if (input == "cd")
            {
                Console.Write("\nPossible Locations (");

                //Displays possible locations
                int length = possibleLocations.Length;
                int currentIndex = 1;
                foreach (string i in possibleLocations)
                {
                    if (currentIndex != length)
                    {
                        Console.Write(i + ", ");
                    }

                    if (currentIndex == length)
                    {
                        Console.Write(i);
                    }

                    currentIndex++;
                }
                Console.Write(")\n");

                Console.Write("\nNew Location > ");
                string newLocation = Console.ReadLine();
                foreach (string location in possibleLocations)
                {
                    if (newLocation == location)
                    {
                        directoryLocation = newLocation;
                        Console.WriteLine("\nChanging Directory to {0}", newLocation);
                        Directories();
                    }
                }
                Console.WriteLine("\nThat location is not avalible");
                Console.ReadLine();
                Directories();
            }

            //Brings us back to main menu
            else if (input == "back")
            {
                Console.Clear();
                Menu();
            }

            //Runs this function again is none command is vaild
            else
            {
                Console.Clear();
                Console.WriteLine("\nInvald Command");
                Directories();
            }
        }

        //File cmds
        static void Files()
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("         FILE MENU        ");
            Console.WriteLine("==========================");

            //Runs the command line
            Console.Write("File.{0} >  ", directoryLocation);

            //Gets user input on the acion to take
            string input = Console.ReadLine();

            //if input is 'write' than get user input for a new document
            if (input == "write")
            {
                CreateText();
            }

            //If delete then run delete function
            else if (input == "delete")
            {
                DeletFile();
            }

            //Runs the copy function
            else if (input == "copy")
            {
                CopyFile();
            }

            //Brings us back to main menu
            else if (input == "back")
            {
                Console.Clear();
                Menu();
            }

            //Runs this function again is none command is vaild
            else
            {
                Console.Clear();
                Console.WriteLine("\nInvald Command");
                Files();
            }
        }

        //IP Theif
        static void IP()
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("          IP MENU         ");
            Console.WriteLine("==========================");

            //Runs the command line
            Console.Write("Directory.{0} >  ", directoryLocation);

            //Gets user input on the acion to take
            string input = Console.ReadLine();

            //if input is 'get' than retrieve computer ip
            if (input == "get")
            {
                //Gets the Computer name
                computerName = Dns.GetHostName();

                //Stores all ips of computer to access
                IPAddress[] ipaddress = Dns.GetHostAddresses(computerName);

                //Gets the IPv4
                foreach (IPAddress ip4 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                {
                    ipv4 = ip4.ToString();
                }

                //Gets the IPv6
                foreach (IPAddress ip6 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
                {
                    ipv6 = ip6.ToString();
                }

                //Runs the IP again
                Thread.Sleep(500);
                Console.Clear();
                IP();
            }

            //Emails the info to me
            else if (input == "email")
            {
                //Gather info for email
                Console.Write("Send To > ");
                MailAddress to = new MailAddress(Console.ReadLine());
                MailAddress from = new MailAddress(email);
                Console.Write("Owner of Computer > ");
                string computer = Console.ReadLine();

                //Deals with attachments -> Later


                //Sends email
                MailMessage mail = new MailMessage(from, to);

                // Set email subject
                mail.Subject = computer + "'s Computer Info";
                // Set email body
                DateTime now = DateTime.Now;
                mail.Body = "IPv4: " + ipv4 + "\nIPv6: " + ipv6 + "\nComputer Name: " + computerName + "\nAccessed: " + now;

                // SMTP server address
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                // User and password for ESMTP authentication
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(
                email, password);

                // Most mordern SMTP servers require SSL/TLS connection now.
                smtp.EnableSsl = true;

                //Send mail
                smtp.Send(mail);

                Console.WriteLine("\nEmail Recived");
                Console.WriteLine("\nRunning Program.Start()...\n");
                Thread.Sleep(500);
                Console.Clear();
                Menu();
            }

            //Shows IP
            else if (input == "show")
            {
                Console.WriteLine("Computer Name: " + computerName + "\nIPv4: " + ipv4 + "\nIPv6: " + ipv6);
                Console.ReadLine();
                IP();
            }

            //Runs this function again is none command is vaild
            else
            {
                Console.Clear();
                Console.WriteLine("\nInvald Command");
                IP();
            }
        }

        //creates a text file
        static void CreateText()
        {
            //sets the base path for file creating and fullPath to use
            string basePath = "";
            string fullPath;

            //Figures out which special folder to use
            basePath = FolderBase();


            //Gets the info
            Console.Write("\nTitle > ");
            string name = Console.ReadLine();
            Console.Write("\nText > ");
            string text = Console.ReadLine();
            Console.Write("\nType > ");
            string type = Console.ReadLine();

            //Set the location of the document
            fullPath = basePath + @"\" + name + "." + type;

            using (StreamWriter sw = File.CreateText(fullPath))
            {
                sw.WriteLine(text);
            }

            Console.WriteLine("\nFile.{0} > Created File", directoryLocation);
            Console.ReadLine();
            Files();
        }

        //Delete file function
        static void DeletFile()
        {
            Console.Clear();

            Console.WriteLine
               ("TYPE NAME INCLUING .---\n" +
                "IT IS CASE SENSTIVE\n" +
                "IF THE FILE IS DOES NOT EXSIT IT WILL DO NOTHING AND RETURN TO FILE MENU\n");

            //sets the base path for file creating and fullPath to use
            string basePath = "";
            string fullPath;

            //Figures out which special folder to use
            basePath = FolderBase();


            //Gets the info
            Console.Write("\nFile > ");
            string name = Console.ReadLine();

            string fileName = "";
            string fileExt = "";

            //Set the location of the document
            fullPath = basePath + @"\" + name;

            if (name != "")
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    Console.WriteLine("\nFile.{0} > Deleted File", directoryLocation);
                    Console.ReadLine();
                    Files();
                }

                else
                {
                    Console.WriteLine("\nFile.{0} > File could not be found", directoryLocation);
                    Console.ReadLine();
                    Files();
                }
            }

            else
            {
                string[] allFiles;

                allFiles = Directory.GetFiles(basePath);

                foreach (string file in allFiles)
                {
                    File.Delete(file);
                }

                Console.WriteLine("\nFile.{0} > Deleted Files", directoryLocation);
                Console.ReadLine();
                Files();
            }
        }

        //Copys the selected files to an array
        static void CopyFile()
        {
            string fileName = "";
            string fileExt = "";

            //sets the base path for file creating and fullPath to use
            string basePath = "";
            string fullPath;

            //Figures out which special folder to use
            basePath = FolderBase();

            if (!Directory.Exists(@"D:\Copied Files\"))
            {
                Directory.CreateDirectory(@"D:\Copied Files\");
            }

            //Gets the info
            Console.Write("\nLEAVE BLANK FOR ENTIRE FOLDER\nFile > ");
            string name = Console.ReadLine();

            //Set the location of the document
            fullPath = basePath + @"\" + name;

            if (name != "")
            {
                fileName = name.Split('.').First();
                fileExt = name.Split('.').Last();
                string newFullPath = @"D:\Copied Files\" + fileName + "_Copied." + fileExt;

                File.Copy(fullPath, newFullPath);

                Console.WriteLine("\nFile.{0} > Copied File", directoryLocation);
                Console.ReadLine();
                Files();
            }

            if (name == "")
            {
                string[] allFiles;

                allFiles = Directory.GetFiles(basePath);

                foreach (string file in allFiles)
                {
                    string newFile = file.Replace(basePath, "");

                    fileName = newFile.Split('.').First();
                    fileExt = newFile.Split('.').Last();
                    string newFullPath = @"D:\Copied Files\" + fileName + "_Copied." + fileExt;
                    if (!File.Exists(newFullPath))
                    {
                        File.Copy(file, newFullPath);
                    }
                }

                Console.WriteLine("\nFile.{0} > Copied Files", directoryLocation);
                Console.ReadLine();
                Files();
            }
        }

        //Emails user inputed message
        static void SendEmailToMe(int portNumber)
        {

            //Gather info for email
            Console.Write("Send To > ");
            MailAddress to = new MailAddress(Console.ReadLine());
            MailAddress from = new MailAddress(email);
            Console.Write("Subject > ");
            string subject = Console.ReadLine();
            Console.Write("Body > ");
            string body = Console.ReadLine();

            //Deals with attachments -> Later


            //Sends email
            MailMessage mail = new MailMessage(from, to);

            // Set email subject
            mail.Subject = subject;
            // Set email body
            mail.Body = body;

            // SMTP server address
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;

            // User and password for ESMTP authentication
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(
            email, password);

            // Most mordern SMTP servers require SSL/TLS connection now.
            smtp.EnableSsl = true;

            //Send mail
            smtp.Send(mail);

            Console.WriteLine("\nEmail Recived");
            Console.WriteLine("\nRunning Program.Start()...\n");
            Thread.Sleep(500);
            Console.Clear();
            Menu();
        }

        //Fake Bruteforce game
        static void FBrute()
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("          FBRUTE          ");
            Console.WriteLine("==========================\n");
            Console.Write("Enter a 4-6 digit password > ");
            int realPass = Convert.ToInt32(Console.ReadLine());

            int triePass = 0001;

            while (triePass <= 999999)
            {
                if (triePass != realPass)
                {
                    Console.WriteLine("{0} > Incorrect", triePass);
                    triePass++;
                }
                else
                {
                    Console.WriteLine("{0} > Correct", triePass);
                    break;
                }
            }
            Console.Read();
            Console.Clear();
            Main();
        }

        //Launches decrpyt
        static void Decrypt()
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("          DECRYPT         ");
            Console.WriteLine("==========================\n");
            Console.WriteLine("Launching...");
            Thread.Sleep(3233);
            string exeLocation = Process.GetCurrentProcess().MainModule.FileName;
            string exeLocate = exeLocation.Replace("Terminal.exe", "");
            string decrpytLocation = exeLocate + @"Ceaser Decrpyt\Ceaser Decrypt.exe";

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = decrpytLocation;
            start.WindowStyle = ProcessWindowStyle.Normal;
            start.CreateNoWindow = false;
            Console.Clear();
            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();
            }

            Console.Read();
            Console.Clear();
            Main();
        }

        //Ends process
        static void QuitApplication(int exitCode)
        {
            Environment.Exit(exitCode);
        }
    }
}
