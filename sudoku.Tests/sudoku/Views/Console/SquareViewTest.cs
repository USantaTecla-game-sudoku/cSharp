using System;
using System.IO;
using Moq;
using NUnit.Framework;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console {

    public class SquareViewTest {

        [Test]
        public void GivenSquare_WhenDisplay_ThenWriteConsole(){
            var output = new StringWriter();
            System.Console.SetOut(output);

            var result = new StringWriter();
            result.Write(output.ToString());

            new SquareView(new HintSquare(Number.ONE)).Display();
            new SquareView(new PlayableSquare(Number.FIVE)).Display();

            result.Write(Number.ONE.GetDescription());
            result.Write(Number.FIVE.GetDescription());
            Assert.AreEqual(output.ToString(), result.ToString());

            output.Flush();
            output.Close();
        }
    }
}
