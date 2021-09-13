using System.ComponentModel;
using usantatecla.utils;

namespace usantatecla.sudoku.views
{
    public class Message : Enumeration
    {
        public static Message START = new Message(0, "\n   -------------- SUDOKU ---------------\n");
        public static Message ASSIGNMENT = new Message(1, "\nSelect a square to assign: ");
        public static Message WINNER = new Message(2, "\nYou win!!! :-)");
        public static Message RESUME = new Message(3, "\nDo you want to continue? (y/n): ");
        public static Message ERROR_FORMAT = new Message(4, "\n * Not a valid format:\n\tAssign: [A..I][1..9]+[1..9]\n\tRemove: [A..I][1..9]-");

        public Message(int id, string value) : base(id, value){}

    }
}
