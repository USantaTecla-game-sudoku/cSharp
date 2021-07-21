using System;
using System.IO;
using NUnit.Framework;
using Moq;
using usantatecla.utils;

namespace usantatecla.sudoku.models {

    public class NumberTest {

        [Test]
        public void GivenNumber_WhenDisplay_ThenWriteConsole(){
            var output = new StringWriter();
            System.Console.SetOut(output);
            var result = new StringWriter();
            result.Write(output.ToString());

            Number.EIGHT.Display();

            result.Write(Number.EIGHT.GetDescription());
            Assert.AreEqual(output.ToString(), result.ToString());

            output.Flush();
            output.Close();
        }

        [Test]
        public void GivenInt_WhenNeedNumber_ThenParse(){
            Assert.AreEqual(1.ToNumber(), Number.ONE);
            Assert.AreEqual(9.ToNumber(), Number.NINE);
        }
    }
}
