using System;
using System.IO;
using NUnit.Framework;
using Moq;
using usantatecla.utils;

namespace usantatecla.sudoku.models {

    public class NumberTest {

        [Test]
        public void GivenNumberExtensions_WhenToNumberWithInteger_ThenNumber(){
            Assert.AreEqual(NumberExtensions.ToNumber(1), Number.ONE);
        }

        [Test]
        public void GivenNumberExtensions_WhenToNumberWithChar_ThenNumber(){
            Assert.AreEqual(NumberExtensions.ToNumber('1'), Number.ONE);
        }
    }
}
