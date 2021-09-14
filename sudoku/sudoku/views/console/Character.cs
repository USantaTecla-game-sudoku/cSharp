using System;
using System.ComponentModel;
using System.Reflection;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class Character : Enumeration
    {
        public static Character WHITE_SPACE = new Character(0, " ");
        public static Character DOUBLE_VERTICAL = new Character(1, "║");
        public static Character SIMPLE_VERTICAL = new Character(2, "|");
        public static Character NEW_LINE = new Character(3, "\r\n");

		public Character(int id, string value) : base(id, value){}
    }
}