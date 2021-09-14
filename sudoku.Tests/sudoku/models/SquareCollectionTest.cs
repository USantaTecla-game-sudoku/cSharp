using NUnit.Framework;

namespace usantatecla.sudoku.models {

    public class SquareCollectionTest {

        private SquareCollection _squareCollection;

        [SetUp]
        public void Setup()
        {
            this._squareCollection = new SquareCollection(
                new Square[] { 
                    new HintSquare(Number.ONE), 
                    new PlayableSquare() }
                );
        }

        [Test]
        public void GivenSquareCollection_WhenCanAssignWithNumberRepeat_ThenKO(){
            Assert.IsFalse(_squareCollection.CanAssign(Number.ONE));
        }

        [Test]
        public void GivenSquareCollection_WhenCanAssignWithNumberNotRepeat_ThenOK(){
            Assert.IsTrue(_squareCollection.CanAssign(Number.TWO));
        }

    }
}