namespace Minesweeper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ConsoleMinesweeper;
    using GameEngine;
    [TestClass]
    public class ComsoleMinesweeperTests
    {
        [TestMethod]
        public void GetUIElementTest()
        {
            var fieldVisualisator = new FieldVisualator();
            for (int i = 0; i < 8; i++)
            {
                var symbol = fieldVisualisator.GetUIElement(i);
                Assert.AreEqual(i.ToString(), symbol);
            }
        }        
    }
}
