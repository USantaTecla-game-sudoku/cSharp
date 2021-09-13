using System;
using System.ComponentModel;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
	public class AssignmentResult : Enumeration
    {
        public static AssignmentResult SUCCESS = new AssignmentResult(0, "");
        public static AssignmentResult NUMBER_ALREADY_EXISTS_IN_COLUMN = new AssignmentResult(1, "\n * Number has already been assigned at this column.");
        public static AssignmentResult NUMBER_ALREADY_EXISTS_IN_ROW = new AssignmentResult(2, "\n * Number has already been assigned at this row.");
        public static AssignmentResult NUMBER_ALREADY_EXISTS_IN_BOX = new AssignmentResult(3, "\n * Number has already been assigned at this box.");
        public static AssignmentResult NOT_PLAYABLE_SQUARE = new AssignmentResult(4, "\n * This square has a fixed value");

        public AssignmentResult(int id, string value) : base(id, value){}

    }
}
