using System;
using System.IO;
using NUnit.Framework;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console {

    public class LineTest {

        [Test]
        public void GivenLine_WhenDisplay_ThenWriteConsole(){
            var output = new StringWriter();
            System.Console.SetOut(output);

            var result = new StringWriter();
            result.Write(output.ToString());

            Line.HORIZONTAL_FIRST.Display();
            result.WriteLine(Line.HORIZONTAL_FIRST.GetDescription());
            Assert.AreEqual(output.ToString(), result.ToString());

            output.Flush();
            output.Close();
        }
    }
}
