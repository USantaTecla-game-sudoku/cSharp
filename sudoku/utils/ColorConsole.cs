using System;

namespace usantatecla.utils
{
    public class ColorConsole {

        private static ColorConsole _console;

        public static ColorConsole Instance() {
            if (ColorConsole._console == null)
                ColorConsole._console = new ColorConsole();

            return ColorConsole._console;
        }

        public string Read(string title) {

            var result = string.Empty;

            this.Write(title);
            try
            {
                result = System.Console.ReadLine();
            }
            catch (Exception ex) { Write(ex.Message); }

            return result;
        }

        public void Write(string message) {
            this.Write(message, ConsoleColor.White);
        }

        public void NewLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string message)
        {
            this.WriteLine(message, ConsoleColor.White);
        }

        public void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
        }

        public void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

    }
}
