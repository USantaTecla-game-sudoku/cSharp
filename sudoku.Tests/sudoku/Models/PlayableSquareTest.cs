using System;
using NUnit.Framework;

namespace usantatecla.sudoku.models {

    public class PlayableSquareTest {

        [Test]
        public void GivenHintSquare_WhenCanAssign_ThenOK(){
            var playableSquare = new PlayableSquare(Number.ONE);
            Assert.IsTrue(playableSquare.CanAssign());
        }

        [Test]
        public void GivenHintSquare_WhenIsEmptyWithEmpty_ThenOK(){
            var playableSquare = new PlayableSquare();
            Assert.IsTrue(playableSquare.IsEmpty());
        }

        [Test]
        public void GivenHintSquare_WhenIsEmptyWithFill_ThenKO(){
            var playableSquare = new PlayableSquare(Number.ONE);
            Assert.IsFalse(playableSquare.IsEmpty());
        }

        [Test]
        public void GivenHintSquare_WhenGetColor_ThenCyan(){
            var playableSquare = new PlayableSquare(Number.ONE);
            Assert.AreEqual(playableSquare.GetColor(), ConsoleColor.White);
        }

        [Test]
        public void GivenHintSquare_WhenAssing_ThenAssignCorrect(){
            var playableSquare = new PlayableSquare();
            playableSquare.assing(Number.ONE);
            Assert.AreEqual(playableSquare.ToString(), "1");
        }
    }
}
