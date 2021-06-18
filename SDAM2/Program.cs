using System.IO;
using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace SDAM2
{
    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            WindowManager window = new WindowManager();
            window.Initialize();
        }
    }
}



