using System;
using NUnit.Framework;
using usantatecla.utils;

namespace usantatecla.sudoku.models {

    public class HintSquareTest {

        [Test]
        public void GivenHintSquare_WhenCanAssign_ThenKO(){
            var hintSquare = new HintSquare(Number.ONE);
            Assert.IsFalse(hintSquare.CanAssign());
        }

        [Test]
        public void GivenHintSquare_WhenIsEmpty_ThenKO(){
            var hintSquare = new HintSquare(Number.ONE);
            Assert.IsFalse(hintSquare.IsEmpty());
        }

        [Test]
        public void GivenHintSquare_WhenGetColor_ThenCyan(){
            var hintSquare = new HintSquare(Number.ONE);
            Assert.AreEqual(hintSquare.GetColor(), ConsoleColor.Cyan);
        }

        [Test]
        public void GivenHintSquare_WhenToString_ThenStringCorrect(){
            var hintSquare = new HintSquare(Number.ONE);
            Assert.AreEqual(hintSquare.ToString(), "1");
        }
    }
}
