using System;
using System.IO;
using NUnit.Framework;
using Moq;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{

    public class ConsoleViewTest{

        //internal StringWriter output;
        //internal StringWriter result;
        public Mock<ColorConsole> mock;

        [SetUp]
        public void SetUp(){

            //this.output = new StringWriter();
            //System.Console.SetOut(output);

            //this.result = new StringWriter();
            //result.Write(output.ToString());

            mock = new Mock<ColorConsole>();
        }

        [TearDown]
        public void TearDown(){
            //output.Flush();
            //output.Close();

            //result.Flush();
            //result.Close();
        }
    }

}
