namespace Minesweeper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ConsoleMinesweeper;
    using GameEngine;
    using GameEngine.Board.Field;
    using GameEngine.Board;
    using GameEngine.State;
    using GameEngine.Statistic;

    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoardConstructorShouldThrowAnExceptionIfFirstParameterIsSmallerThan1()
        {
            var board = new Board(0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoardConstructorShouldThrowAnExceptionIfSecondParameterIsSmallerThan1()
        {
            var board = new Board(3, -4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoardBuilderConstructorShouldThrowAnExceptionIfAnyParameterIsSmallerThan1()
        {
            var boardBuilder = new Board(-3, -4);
        }

        [TestMethod]
        public void BoardBuilderBoardGenerateShoudProperlyUpdadeMines()
        {
            BoardBuilder builder = new BoardBuilder(10, 10);
            var board = builder.Generate(10);
            int countOfMine = 0;
            foreach (var row in board)
            {
                foreach (var field in row)
                {
                    if (field.IsMine)
                    {
                        countOfMine++;
                    }
                }
            }

            Assert.AreEqual(10, countOfMine);
        }
    }

    [TestClass]
    public class StateTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StateConstructorShoudThrowAnExceptionIfNullParameter()
        {
            var state = new StartState(null);
        }
    }

    [TestClass]
    public class FieldTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ContentPropertyShoudThrowAnExpetionWhenContentIsEqualOrSmallerThanMineContent()
        {
            var field = new Field(Field.MineContent - 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ContentPropertyShoudThrowAnExceptionWhenParameterIsLargerThanEight()
        {
            var field = new Field(9);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FieldWrapperConstructorShoudTrhowAnExceptionIfArguemntIsNull()
        {
            var fieldWrapper = new FieldWrapper(null);
        }
    }

    [TestClass]
    public class FilePlayerMementoStorageTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FilePlayerMementoConstructorShoudTrhowAnExceptionIfArguemntIsNull()
        {
            var fieldWrapper = new FieldWrapper(null);
        }
    }

    [TestClass]
    public class GetOIElementTests
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

    [TestClass]
    public class StatisticStorageTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StatisticStorageConstructorShoudTrhowAnExceptionIfArguemntsAreNull()
        {
            var fieldWrapper = new StatisticStorage(null, null);
        }

    }

    [TestClass]
    public class CommandFactoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CommandFactoryConstructorShoudTrhowAnExceptionIfArguemntsAreNull()
        {
            var fieldWrapper = new CommandFactory(null);
        }

    }
}
