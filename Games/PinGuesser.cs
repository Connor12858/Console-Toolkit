using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Console_Toolkit.Games
{
    class PinGuesser
    {
        // Variables needed for the game
        static string pin;
        static List<string> log = new List<string>();
        static Random random = new Random();
        static bool done = false;

        public static void Start()
        {
            Console.Clear();

            done = false;

            // Set the pin to 4 digits with no repeats
            List<int> nums = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                int num = random.Next(1, 10);
                while(nums.Contains(num))
                {
                    num = random.Next(1, 10);
                }
                nums.Add(num);
            }
            pin = string.Join("", nums);
            log.Clear();

            // Add the titles
            log.Add("1 | 2 | 3 | 4  C M W");
            log.Add("--------------------");

            // Add the first guess outline
            log.Add("X | X | X | X");

            // 
            Output();
            Input();
        }

        // Get input for the new guess
        private static void Input()
        {
            // Keep track of the spot
            int count = 0;

            // Repeat for each spot
            while (count < 4)
            {
                // Get the input
                ConsoleKeyInfo inp = Console.ReadKey();

                // Check for input
                // Remove a key
                if (inp.Key == ConsoleKey.Backspace && count >= 1)
                {
                    string msg = log[log.Count - 1];
                    msg = msg.Remove((count - 1) * 4, 1).Insert((count - 1) * 4, "X");
                    log[log.Count - 1] = msg;

                    if (count > 0)
                    {
                        count--;
                    }
                }
                // Input the guess if a number
                else
                {
                    if (char.IsDigit(inp.KeyChar))
                    {
                        string msg = log[log.Count - 1];
                        msg = msg.Remove(count * 4, 1).Insert(count * 4, Convert.ToString(inp.KeyChar));
                        log[log.Count - 1] = msg;
                        count++;
                    }
                }
                Output();
            }

            Check();
        }

        private static void Check()
        {
            // counters for rights, wrongs, and misplace
            int rights = 0;
            int wrongs = 0;
            int misplace = 0;
            string msg = "";

            // Check for rights, wrongs, and misplace
            for (int i = 0; i < 4; i++)
            {
                // Get the input
                msg = log[log.Count -1];
                
                // Check for conditions
                if (msg[i * 4] == pin[i])
                {
                    rights++;
                } else if (pin.Contains(msg[i * 4]))
                {
                    misplace++;
                } 
                else
                {
                    wrongs++;
                }

            }

            // Check if its correct
            if(rights == 4)
            {
                log.Add("Correct");
                done = true;
                Output();
                Console.ReadKey();
            }

            // Add the results and create a new line for the next input
            msg += "  " + Convert.ToString(rights) + " " + Convert.ToString(misplace) + " " + Convert.ToString(wrongs);
            log[log.Count - 1] = msg;
            log.Add("X | X | X | X");

            // Only continue when not done
            if (!done)
            {
                Input();
            }
        }

        // Output the log
        private static void Output ()
        {
            Console.Clear();
            foreach (string s in log) Console.WriteLine(s);
        }
    }
}
