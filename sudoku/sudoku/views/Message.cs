using System.ComponentModel;

namespace usantatecla.sudoku.views
{
    public enum Message {
        [Description("--- SUDOKU ---")]
        START,
        [Description("Select coordinate to assign: ")]
        ASSIGNMENT,
        [Description("You win!!! :-)")]
        WINNER,
        [Description("Do you want to continue? (y/n): ")]
        RESUME,
        [Description(" * Wrong square")]
        ERROR_COORDINATE,
        [Description(" * This square has a fixed value")]
        ERROR_COORDINATE_HINT,
        [Description(" * Not a valid number {1..9}")]
        ERROR_NUMBER,
        [Description(" * Not a valid operator {+ -}")]
        ERROR_OPERATOR,
        [Description(" * Number ? has already been assigned at this column.")]
        ERROR_REPEAT_IN_COLUMN,
        [Description(" * Number ? has already been assigned at this row.")]
        ERROR_REPEAT_IN_ROW,
        [Description(" * Number ? has already been assigned at this box.")]
        ERROR_REPEAT_IN_BOX,
    }
}
