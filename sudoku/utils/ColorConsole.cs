using System;

namespace usantatecla.utils
{
    public class ColorConsole {

        public virtual string Read(string title) {

            var result = string.Empty;

            this.Write(title);
            try
            {
                result = System.Console.ReadLine();
            }
            catch (Exception ex) { Write(ex.Message); }

            return result;
        }

        public virtual void Write(string message) {
            this.Write(message, ConsoleColor.White);
        }

        public virtual void Write(int number)
        {
            this.Write(number.ToString());
        }

        public void Write(Enum enumertion) {
            this.Write(enumertion.GetDescription());
        }

        public void Write(Enum enumertion, ConsoleColor color)
        {
            this.Write(enumertion.GetDescription(), color);
        }


        public void WriteLine(Enum enumertion) {
            this.WriteLine(enumertion.GetDescription());
        }

        public virtual void WriteLine(string message)
        {
            this.WriteLine(message, ConsoleColor.White);
        }

        public virtual void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
        }

        public virtual void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

    }
}
