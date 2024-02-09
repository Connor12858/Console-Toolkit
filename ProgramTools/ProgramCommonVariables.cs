using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Drawing;

namespace Console_Toolkit
{
    class ProgramCommonVariables
    {
        public static readonly string HelpFilePath = "..\\..\\ProgramFiles\\HelpMenu.txt";
        public static readonly int HelpMenuLength = 12;
        public static readonly string[] mangerList = { "File", "Network", "Program", "Game"};
        public static readonly ReadOnlyDictionary<ConsoleColor, Color> ColorMapper = new ReadOnlyDictionary<ConsoleColor, Color>(new Dictionary<ConsoleColor, Color>
        {
            [ConsoleColor.Black] = Color.FromArgb(0x000000),
            [ConsoleColor.DarkBlue] = Color.FromArgb(0x00008B),
            [ConsoleColor.DarkGreen] = Color.FromArgb(0x006400),
            [ConsoleColor.DarkCyan] = Color.FromArgb(0x008B8B),
            [ConsoleColor.DarkRed] = Color.FromArgb(0x8B0000),
            [ConsoleColor.DarkMagenta] = Color.FromArgb(0x8B008B),
            [ConsoleColor.DarkYellow] = Color.FromArgb(0x808000),
            [ConsoleColor.Gray] = Color.FromArgb(0x808080),
            [ConsoleColor.DarkGray] = Color.FromArgb(0xA9A9A9),
            [ConsoleColor.Blue] = Color.FromArgb(0x0000FF),
            [ConsoleColor.Green] = Color.FromArgb(0x008000),
            [ConsoleColor.Cyan] = Color.FromArgb(0x00FFFF),
            [ConsoleColor.Red] = Color.FromArgb(0xFF0000),
            [ConsoleColor.Magenta] = Color.FromArgb(0xFF00FF),
            [ConsoleColor.Yellow] = Color.FromArgb(0xFFFF00),
            [ConsoleColor.White] = Color.FromArgb(0xFFFFFF)
        });
    }
}
