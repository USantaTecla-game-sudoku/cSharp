using System;
using System.ComponentModel;
using System.Reflection;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public enum Character {
        [Description(" ")]
        WHITE_SPACE,
        [Description("║")]
        DOUBLE_VERTICAL_BAR,
        [Description("|")]
        SIMPLE_VERTICAL_BAR,
    }

}
