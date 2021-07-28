using System;
using NUnit.Framework;
using usantatecla.utils;

namespace usantatecla.sudoku.models {

    public class PlayableSquareTest {

        private PlayableSquare _playableSquare;

        [SetUp]
        public void Setup()
        {
            this._playableSquare = new PlayableSquare();
        }

        [Test]
        public void GivenHintSquare_WhenCanAssign_ThenOK(){
            _playableSquare = new PlayableSquare(Number.ONE);
            Assert.IsTrue(_playableSquare.CanAssign());
        }

        [Test]
        public void GivenHintSquare_WhenIsEmptyWithEmpty_ThenOK(){
            Assert.IsTrue(_playableSquare.IsEmpty());
        }

        [Test]
        public void GivenHintSquare_WhenIsEmptyWithFill_ThenKO(){
            _playableSquare = new PlayableSquare(Number.ONE);
            Assert.IsFalse(_playableSquare.IsEmpty());
        }

        [Test]
        public void GivenHintSquare_WhenGetColor_ThenCyan(){
            _playableSquare = new PlayableSquare(Number.ONE);
            Assert.AreEqual(_playableSquare.GetColor(), ConsoleColor.White);
        }

        [Test]
        public void GivenHintSquare_WhenAssing_ThenAssignCorrect(){
            _playableSquare.Assign(Number.ONE);
            Assert.AreEqual(_playableSquare.Number.GetDescription(), "1");
        }
    }
}
