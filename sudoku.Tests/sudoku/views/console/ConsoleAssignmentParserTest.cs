using System;
using System.IO;
using Moq;
using NUnit.Framework;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.views.console
{
    public class ConsoleAssignmentParserTest : ConsoleViewTest
    {

        // private const string ERROR_FORMAT_MESSAGE = "\n * Not a valid format:\n\tAssign: [A..I][1..9]+[1..9]\n\tRemove: [A..I][1..9]-";

        [Test]
        public void GivenString_WhenParse_ThenReturnAssignement()
        {
            string value = "C1+5";
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(value);
            Assignment assignment = assignmentParse.Parse();
            Assert.AreEqual(Number.FIVE, assignment.Number);
            Assert.AreEqual(2, assignment.Coordinate.Column);
            Assert.AreEqual(0, assignment.Coordinate.Row);
        }

        [Test]
        public void GivenString_WhenHasAddFormat_ThenReturnFalseHasError()
        {
            CheckUserInputDontRaisesError("I1+5");
        }

        [Test]
        public void GivenString_WhenHasDeleteFormat_ThenReturnFalseHasError()
        {
            CheckUserInputDontRaisesError("A1-");
        }

        [Test]
        public void GivenString_WhenHasBadColumn_ThenReturnTrueHasError()
        {
            CheckUserInputRaisesError("J1+5");
        }

        [Test]
        public void GivenString_WhenHasBadRow_ThenReturnTrueHasError()
        {
            CheckUserInputRaisesError("A0+3");
        }

        [Test]
        public void GivenString_WhenHasBadOperation_ThenReturnTrueHasError()
        {
            CheckUserInputRaisesError("I9*5");
        }

        [Test]
        public void GivenString_WhenHasBadNumber_ThenReturnTrueHasError()
        {
            CheckUserInputRaisesError("I5+0");
            CheckUserInputRaisesError("I5+10");
            CheckUserInputRaisesError("I5+");
        }

        [Test]
        public void GivenString_WhenHasBadColumn_ThenDisplayError()
        {
            CheckUserInputRaisesErrorMessage("J1+5", Message.ERROR_FORMAT);
        }

        [Test]
        public void GivenString_WhenHasBadRow_ThenDisplayError()
        {
            CheckUserInputRaisesErrorMessage("A0+3", Message.ERROR_FORMAT);
        }

        [Test]
        public void GivenString_WhenHasBadOperation_ThenDisplayError()
        {
            CheckUserInputRaisesErrorMessage("I9*5", Message.ERROR_FORMAT);
        }

        [Test]
        public void GivenString_WhenHasBadNumber_ThenDisplayError()
        {
            CheckUserInputRaisesErrorMessage("I5+0", Message.ERROR_FORMAT);
        }

         [Test]
        public void GivenString_WhenHasWhiteSpaces_ThenDisplayError()
        {
            CheckUserInputRaisesErrorMessage(" h9+4", Message.ERROR_FORMAT);
        }

        private void CheckUserInputRaisesErrorMessage(string userInput, Message expectedErrorMessage)
        {
            var assignmentParse = new ConsoleAssignmentParser(userInput);
            assignmentParse._colorConsole = mock.Object;
            assignmentParse.DisplayError();

            mock.Verify(v => v.WriteLine(expectedErrorMessage.ToString()), Times.Once());
        }

        private void CheckUserInputRaisesError(string userInput) {
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(userInput);
            Assert.IsTrue(assignmentParse.HasError());
        }

        private void CheckUserInputDontRaisesError(string userInput)
        {
            ConsoleAssignmentParser assignmentParse = new ConsoleAssignmentParser(userInput);
            Assert.IsFalse(assignmentParse.HasError());
        }
    }
}
