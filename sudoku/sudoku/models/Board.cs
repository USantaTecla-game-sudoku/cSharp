using System.Diagnostics;
using System.Linq;

namespace usantatecla.sudoku.models
{
    public class Board
    {
        public readonly static int SIZE = 9;
        public readonly static int SIZE_BOX = SIZE / 3;
        public readonly static string EMPTY_NUMBER_LOAD = ".";
        public readonly static string EMPTY_NUMBER_ASSIGN = " ";

        private readonly Square[][] _squares;

        public Board()
        {
            this._squares = new Square[SIZE][];
            for (int i = 0; i < SIZE; i++)
            {
                _squares[i] = new Square[SIZE];
            }
        }

        public virtual void Load(string sudoku)
        {
            Debug.Assert(!string.IsNullOrEmpty(sudoku));
            Debug.Assert(sudoku.Length == SIZE * SIZE);

            for (int row = SIZE - 1; row >= 0; row--)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    var value = sudoku.Substring(col + row * SIZE, 1);
                    _squares[SIZE - 1 - row][col] = (value == EMPTY_NUMBER_LOAD)
                        ? new PlayableSquare()
                        : new HintSquare(value.ToNumber());
                }
            }
        }

        public virtual void Assign(Assignment assignment)
        {
            var square = (PlayableSquare)(this.GetSquare(assignment));
            square.Assign(assignment.Number);
        }

        public virtual AssignmentResult CanAssign(Assignment assignment)
        {
            if (!this.GetSquare(assignment).CanAssign())
                return AssignmentResult.NOT_PLAYABLE_SQUARE;

            if (!this.GetRow(assignment).CanAssign(assignment.Number))
                return AssignmentResult.NUMBER_ALREADY_EXISTS_IN_ROW;

            if (!this.GetColumn(assignment).CanAssign(assignment.Number))
                return AssignmentResult.NUMBER_ALREADY_EXISTS_IN_COLUMN;

            if (!this.GetBox(assignment).CanAssign(assignment.Number))
                return AssignmentResult.NUMBER_ALREADY_EXISTS_IN_BOX;

            return AssignmentResult.SUCCESS;

        }

        public virtual Square[][] GetSquares() => this._squares;

        public virtual bool HasSudoku()
        {
            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    if (this._squares[row][col].IsEmpty())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private SquareCollection GetRow(Assignment assignment)
        {
            return new SquareCollection(this._squares[assignment.Coordinate.Row]);
        }

        private SquareCollection GetColumn(Assignment assignment)
        {
            Square[] squaresColum = new Square[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                squaresColum[i] = this._squares[i][assignment.Coordinate.Column];
            }
            return new SquareCollection(squaresColum);
        }

        private SquareCollection GetBox(Assignment assignment)
        {
            Square[] squaresBox = new Square[SIZE];
            int initIndexRow = SIZE_BOX * ((assignment.Coordinate.Row) / SIZE_BOX);
            int initIndexColumn = SIZE_BOX * ((assignment.Coordinate.Column) / SIZE_BOX);
            int index = 0;
            for (int row = initIndexRow; row < initIndexRow + SIZE_BOX; row++)
            {
                for (int col = initIndexColumn; col < initIndexColumn + SIZE_BOX; col++)
                {
                    squaresBox[index] = this._squares[row][col];
                    index++;
                }
            }
            return new SquareCollection(squaresBox);
        }

        private Square GetSquare(Assignment assignment)
        {
            return this._squares[assignment.Coordinate.Row][assignment.Coordinate.Column];
        }

    }

}
