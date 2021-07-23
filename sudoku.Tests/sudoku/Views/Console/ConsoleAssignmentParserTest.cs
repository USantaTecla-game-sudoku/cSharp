using System;
using NUnit.Framework;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.views.console
{
    public class ConsoleAssignmentParserTest : ConsoleViewTest{

        [Test]
        public void GivenString_WhenParse_ThenReturnAssignement(){
            string value = "C1+5";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            Assignment assignment = assignmentParse.Parse();
            Assert.AreEqual(Number.FIVE, assignment.Number);
            Assert.AreEqual(2, assignment.Coordinate.Column);
            Assert.AreEqual(0, assignment.Coordinate.Row);
        }

        [Test]
        public void GivenString_WhenHasAddFormat_ThenReturnFalseHasError(){
            string value = "I1+5";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            Assert.IsFalse(assignmentParse.HasError());
        }

        [Test]
        public void GivenString_WhenHasDeleteFormat_ThenReturnFalseHasError(){
            string value = "A1-";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            Assert.IsFalse(assignmentParse.HasError());
        }

        [Test]
        public void GivenString_WhenHasBadColumn_ThenReturnTrueHasError(){
            string value = "J1+5";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            Assert.IsTrue(assignmentParse.HasError());
        }

        [Test]
        public void GivenString_WhenHasBadRow_ThenReturnTrueHasError(){
            string value = "A0+3";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            Assert.IsTrue(assignmentParse.HasError());
        }

        [Test]
        public void GivenString_WhenHasBadOperation_ThenReturnTrueHasError(){
            string value = "I9*5";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            Assert.IsTrue(assignmentParse.HasError());
        }

        [Test]
        public void GivenString_WhenHasBadNumber_ThenReturnTrueHasError(){
            string value = "I5+0";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            Assert.IsTrue(assignmentParse.HasError());
            value = "I5+10";
            assignmentParse = new ConsoleAssignmentParser(value);
            Assert.IsTrue(assignmentParse.HasError());
            value = "I5+";
            assignmentParse = new ConsoleAssignmentParser(value);
            Assert.IsTrue(assignmentParse.HasError());
        }

        [Test]
        public void GivenString_WhenHasBadColumn_ThenDisplayError(){
            string value = "J1+5";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            assignmentParse.DisplayError();
            result.WriteLine("Wrong square");
            Assert.AreEqual(output.ToString(), result.ToString());
        }

        [Test]
        public void GivenString_WhenHasBadRow_ThenDisplayError(){
            string value = "A0+3";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            assignmentParse.DisplayError();
            result.WriteLine("Wrong square");
            Assert.AreEqual(output.ToString(), result.ToString());
        }

        [Test]
        public void GivenString_WhenHasBadOperation_ThenDisplayError(){
            string value = "I9*5";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            assignmentParse.DisplayError();
            result.WriteLine("Not a valid operator {+ -}");
            Assert.AreEqual(output.ToString(), result.ToString());
        }

        [Test]
        public void GivenString_WhenHasBadNumber_ThenDisplayError(){
            string value = "I5+0";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            assignmentParse.DisplayError();
            result.WriteLine("Not a valid number {1..9}");
            Assert.AreEqual(output.ToString(), result.ToString());
        }
    }
}
