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
        private Random _random;

        public RandomFileSudokuLoader()
        {
            this._random = new Random();
        }

        public string Load()
        {
            return ReadRandomTemplate();
        }

        public int GetTemplateCount() => ReadAllTemplates().Count();


        private string ReadRandomTemplate()
        {
            var templates = ReadAllTemplates();
            var randomLine = GetRandom(templates.Count());
            return templates[randomLine];
        }

        private List<string> ReadAllTemplates()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RESOURCES_FOLDER, FILE_NAME);
            
            return File.ReadLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

        }

        private int GetRandom(int max) => _random.Next(max);
 
    }
}