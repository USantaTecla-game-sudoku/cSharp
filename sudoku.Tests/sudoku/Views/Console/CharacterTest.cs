using System;
using System.IO;
using Moq;
using NUnit.Framework;
using Microsoft.QualityTools.Testing.Fakes;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console {

    public class CharacterTest {

        [Test]
        public void GivenChar_WhenDisplay_ThenWriteConsole(){
            var output = new StringWriter();
            Console.SetOut(output);

            var result = new StringWriter();
            result.Write(output.ToString());

            Character.DOUBLE_VERTICAL_BAR.Display();

            result.Write(Character.DOUBLE_VERTICAL_BAR.GetDescription());
            Assert.AreEqual(output.ToString(), result.ToString());

            output.Flush();
            output.Close();
        }
    }
}
