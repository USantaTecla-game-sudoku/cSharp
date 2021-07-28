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
        DOUBLE_VERTICAL,

        [Description("|")]
        SIMPLE_VERTICAL,

        [Description("\r\n")]
        NEW_LINE,
    }

}
