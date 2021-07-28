using System.ComponentModel;

namespace usantatecla.sudoku.views
{
    public enum Message {

        [Description("\n   -------------- SUDOKU ---------------\n")]
        START,

        [Description("\nSelect coordinate to assign: ")]
        ASSIGNMENT,

        [Description("\nYou win!!! :-)")]
        WINNER,

        [Description("\nDo you want to continue? (y/n): ")]
        RESUME,

        [Description("\n * Not a valid format:\n\tAssign: [A..I][1..9]+[1..9]\n\tRemove: [A..I][1..9]-")]
        ERROR_FORMAT,

    }
}
