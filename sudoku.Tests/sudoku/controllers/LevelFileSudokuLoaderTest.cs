using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using usantatecla.sudoku.controllers;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class LevelFileSudokuLoaderTest
    {
        private const string TEMPLATE_ZERO = "53..7....6..195....98....6.8...6...34..8.3..17...2...6.6....28....419..5....8..79";
        private const string TEMPLATE_ONE = "142.9...57..4...898.5....242....48...3...126..8..72941.5.2.6....28..941..797.853.";
        private const string TEMPLATE_TWO = "7...2.48.2.6..8..55..9........15.....2.....6.....67........6..36..5..1.4.93.4...7";

        //private Mock<LevelGenerator> _mocked;
        //private FileSudokuLoader _sut;

        [SetUp]
        public void Setup() {
            //_mocked = new Mock<LevelGenerator>();
            //_sut = new FileSudokuLoader(_mocked.Object);
        }

        [Test]
        public void Given_LevelFileSudokuLoader_WhenLoad_ThenLoadTemplate()
        {
            Board board = new Board();
            ResumeController controller = new ResumeController(board);

            FileSudokuLoader loader = new FileSudokuLoader(new LevelGenerator(board));

            var loadedTemplate = loader.Load();
            Assert.AreEqual(TEMPLATE_ZERO, loadedTemplate);

            controller.Resume(true);

            loadedTemplate = loader.Load();
            Assert.AreEqual(TEMPLATE_ONE, loadedTemplate);

            controller.Resume(true);

            loadedTemplate = loader.Load();
            Assert.AreEqual(TEMPLATE_TWO, loadedTemplate);

            controller.Resume(true);

            loadedTemplate = loader.Load();
            Assert.AreEqual(TEMPLATE_ZERO, loadedTemplate);
        }

    }

}
