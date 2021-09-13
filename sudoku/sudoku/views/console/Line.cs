using usantatecla.utils;
using System.ComponentModel;

namespace usantatecla.sudoku.views.console
{
    public class Line : Enumeration
    {
        public static Line FIRST = new Line(0, "   ╔═══════════╦═══════════╦═══════════╗");
        public static Line SIMPLE = new Line(1, "   ║───┼───┼───║───┼───┼───║───┼───┼───║");
        public static Line DOUBLE = new Line(2, "   ╠═══════════╬═══════════╬═══════════╣");
        public static Line LAST = new Line(3, "   ╚═══════════╩═══════════╩═══════════╝");
        public static Line LETTER = new Line(4, "     A   B   C   D   E   F   G   H   I  ");

        public Line(int id, string value) : base(id, value){}
    }

}
