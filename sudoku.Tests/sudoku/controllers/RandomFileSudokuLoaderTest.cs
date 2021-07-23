using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using usantatecla.sudoku.controllers;


namespace usantatecla.sudoku.controllers
{
    public class RandomFileSudokuLoaderTest
    {
        private static Random _random;
        private RandomFileSudokuLoader _sut;

        [SetUp]
        public void Setup() {
            _random = new Random();
            _sut = new RandomFileSudokuLoader();
        }


        [Test]
        public void Given_RandomFileSudokuLoader_WhenLoad_ThenSudokuTemplateHasValidFormat()
        {
            string template = _sut.Load();

            var pattern = @"[.123456789]{81}";
            var regex = new Regex(pattern);
            var formatValidator = regex.Match(template);

            Assert.True(formatValidator.Success);
        }

        [Test]
        public void Given_RandomFileSudokuLoader_WhenLoad1000times_ThenHasLoadAllTemplates()
        {
            var loadedTemplates = Load1000Templates();

            var expected = _sut.GetTemplateCount();

            Assert.AreEqual(loadedTemplates.Distinct().Count(), expected);
        }


        private List<string> Load1000Templates() {

            var readedTemplates = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                var template = _sut.Load();
                readedTemplates.Add(template);
            }
            return readedTemplates;
        }


    }
}