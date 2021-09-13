using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class FileSudokuLoader : ISudokuLoader
    {
        private const string RESOURCES_FOLDER = "Resources";
        private const string FILE_NAME = "SudokuTemplates.txt";

        private IValueGenerator _generator;

        public FileSudokuLoader() : this(new RandomGenerator()) { }

        public FileSudokuLoader(IValueGenerator _generator)
        {
            this._generator = _generator;
        }

        public string Load() => ReadRandomTemplate();

        public int GetTemplateCount() => ReadAllTemplates().Count();

        private string ReadRandomTemplate()
        {
            var templates = ReadAllTemplates();
            var randomLine = _generator.Next(templates.Count());
            return templates[randomLine];
        }

        protected List<string> ReadAllTemplates()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RESOURCES_FOLDER, FILE_NAME);

            return File.ReadLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();
        }



        class RandomGenerator : IValueGenerator
        {
            private Random _random;

            public RandomGenerator()
            {
                this._random = new Random();
            }

            public virtual int Next(int max) => _random.Next(max);
        }
    }

    public class LevelGenerator : IValueGenerator{
        private Board _board;
        public LevelGenerator(Board board){
            this._board = board;
        }

        public virtual int Next(int max){
            int nextValue = this._board._level;
            if(nextValue < max){
                return nextValue;
            }
            this._board._level = 0;
            return 0;
        }
    }
}
