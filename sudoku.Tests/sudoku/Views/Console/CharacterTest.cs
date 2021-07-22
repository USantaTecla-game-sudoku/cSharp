using System;
using System.IO;
using Moq;
using NUnit.Framework;
using Microsoft.QualityTools.Testing.Fakes;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console {

    public class CharacterTest : ConsoleViewTest{

        [Test]
        public void GivenChar_WhenGetDescription_ThenWriteConsole(){
            ColorConsole.Instance().Write(Character.DOUBLE_VERTICAL_BAR.GetDescription());

            result.Write("║");
            Assert.AreEqual(output.ToString(), result.ToString());
        }
    }
}
