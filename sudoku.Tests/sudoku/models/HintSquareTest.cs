using System;
using NUnit.Framework;
using usantatecla.utils;

namespace usantatecla.sudoku.models {

    public class HintSquareTest {

        private Square _hintSquare;

        [SetUp]
        public void Setup()
        {
            this._hintSquare = new HintSquare(Number.ONE);
        }

        [Test]
        public void GivenHintSquare_WhenCanAssign_ThenKO(){
            Assert.IsFalse(_hintSquare.CanAssign());
        }

        [Test]
        public void GivenHintSquare_WhenIsEmpty_ThenKO(){
            Assert.IsFalse(_hintSquare.IsEmpty());
        }

        [Test]
        public void GivenHintSquare_WhenToString_ThenStringCorrect(){
            Assert.AreEqual(_hintSquare.Number, Number.ONE);
        }
    }
}
