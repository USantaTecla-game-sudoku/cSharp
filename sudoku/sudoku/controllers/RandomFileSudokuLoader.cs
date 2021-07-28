using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace usantatecla.sudoku.controllers
{
    public class RandomFileSudokuLoader : ISudokuLoader
    {
        private const string RESOURCES_FOLDER = "Resources";
        private const string FILE_NAME = "SudokuTemplates.txt";

        private IRandomValueGenerator _random;

        public RandomFileSudokuLoader(IRandomValueGenerator random)
        {
            this._random = random;
        }

        public string Load() => ReadRandomTemplate();

        public int GetTemplateCount() => ReadAllTemplates().Count();

        private string ReadRandomTemplate()
        {
            var templates = ReadAllTemplates();
            var randomLine = _random.Next(templates.Count());
            return templates[randomLine];
        }

        protected List<string> ReadAllTemplates()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RESOURCES_FOLDER, FILE_NAME);
            
            return File.ReadLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();
        }

        
    }
}