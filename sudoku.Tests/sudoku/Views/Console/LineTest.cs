using System;
using System.IO;
using NUnit.Framework;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console {

    public class LineTest : ConsoleViewTest {

        [Test]
        public void GivenLine_WhenGetDescription_ThenWriteConsole(){
            ColorConsole.Instance().WriteLine(Line.HORIZONTAL_FIRST.GetDescription());

            result.WriteLine("   ╔═══════════╦═══════════╦═══════════╗");
            Assert.AreEqual(output.ToString(), result.ToString());
        }
    }
}
