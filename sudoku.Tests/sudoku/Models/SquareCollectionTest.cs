using NUnit.Framework;
using usantatecla.utils;

namespace usantatecla.sudoku.models {

    public class SquareCollectionTest {

        [Test]
        public void GivenSquareCollection_WhenCanAssignWithNumberRepeat_ThenKO(){
            SquareCollection squareCollection = new SquareCollection(new Square[] { new HintSquare(Number.ONE), new PlayableSquare() });
            Assert.IsFalse(squareCollection.CanAssign(Number.ONE));
        }

        [Test]
        public void GivenSquareCollection_WhenCanAssignWithNumberNotRepeat_ThenOK(){
            SquareCollection squareCollection = new SquareCollection(new Square[] { new HintSquare(Number.ONE), new PlayableSquare() });
            Assert.IsTrue(squareCollection.CanAssign(Number.TWO));
        }

        [Test]
        public void GivenSquareCollection_WhenIsCompletedWithNotCompleted_ThenKO(){
            SquareCollection squareCollection = new SquareCollection(new Square[] { new HintSquare(Number.ONE), new PlayableSquare() });
            Assert.IsFalse(squareCollection.IsCompleted());
        }

        [Test]
        public void GivenSquareCollection_WhenIsCompletedWithCompleted_ThenOK(){
            SquareCollection squareCollection = new SquareCollection(new Square[] { new HintSquare(Number.ONE), new HintSquare(Number.TWO) });
            Assert.IsTrue(squareCollection.IsCompleted());
        }
    }
}
