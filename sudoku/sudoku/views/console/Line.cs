using usantatecla.utils;
using System.ComponentModel;

namespace usantatecla.sudoku.views.console
{
    public enum Line {
        [Description("   ╔═══════════╦═══════════╦═══════════╗")]
        HORIZONTAL_FIRST,
        [Description("   ║───|───|───║───|───|───║───|───|───║")]
        HORIZONTAL_SIMPLE,
        [Description("   ╠═══════════╬═══════════╬═══════════╣")]
        HORIZONTAL_DOUBLE,
        [Description("   ╚═══════════╩═══════════╩═══════════╝")]
        HORIZONTAL_LAST,
        [Description("     A   B   C   D   E   F   G   H   I  ")]
        HORIZONTAL_LETTER,
    }

}
