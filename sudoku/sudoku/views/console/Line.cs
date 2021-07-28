using usantatecla.utils;
using System.ComponentModel;

namespace usantatecla.sudoku.views.console
{
    public enum Line {
        [Description("   ╔═══════════╦═══════════╦═══════════╗")]
        FIRST,

        [Description("   ║───┼───┼───║───┼───┼───║───┼───┼───║")]
        SIMPLE,

        [Description("   ╠═══════════╬═══════════╬═══════════╣")]
        DOUBLE,

        [Description("   ╚═══════════╩═══════════╩═══════════╝")]
        LAST,

        [Description("     A   B   C   D   E   F   G   H   I  ")]
        LETTER,

    }

}
