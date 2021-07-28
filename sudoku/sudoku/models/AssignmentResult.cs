using System;
using System.ComponentModel;


namespace usantatecla.sudoku.models
{
	public enum AssignmentResult {

        [Description("")]
        SUCCESS,

        [Description("\n * Number has already been assigned at this column.")]
        NUMBER_ALREADY_EXISTS_IN_COLUMN,

        [Description("\n * Number has already been assigned at this row.")]
        NUMBER_ALREADY_EXISTS_IN_ROW,

        [Description("\n * Number has already been assigned at this box.")]
        NUMBER_ALREADY_EXISTS_IN_BOX,

        [Description("\n * This square has a fixed value")]
        NOT_PLAYABLE_SQUARE,
    }
}
