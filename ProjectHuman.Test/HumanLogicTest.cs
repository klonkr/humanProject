using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectHuman.DB.Domain;
using ProjectHuman.Lib.BusinessLogic;


namespace ProjectHuman.Test
{
    [TestClass]
    public class HumanLogicTest
    {
        [TestMethod]
        public void CreateHumanTest()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(hl => hl.Create<Human>(new Human())).Returns(true);

            var test = new HumanLogic(mock.Object);

            //Act
            var testTheMethod = test.CreateHuman("Anton", "Cornett", DateTime.Now);

            //Assert
            Assert.IsTrue(testTheMethod);
        }

        [TestMethod]
        public void CheckNameContainsCorrectCharactersElseNullTest()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            var test = new HumanLogic(mock.Object);

            //Act
            var something = test.CheckNameContainsCorrectCharactersElseNull("Testname");
            var shouldFail = test.CheckNameContainsCorrectCharactersElseNull("!2aoe");

            //Assert
            Assert.IsNotNull(something);
            Assert.AreEqual("Testname", "Testname", "Something failed");

            Assert.IsNull(shouldFail);
        }

        [TestMethod]
        public void GetAllHumansTest()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(hl => hl.Read<Human>()).Returns(new List<Human>());

            var test = new HumanLogic(mock.Object);

            //Act
            var listofHumans = test.GetAllHumans();

            //Assert
            Assert.IsInstanceOfType(listofHumans, typeof(List<Human>));
        }

        [TestMethod]
        public void GeneratePersonNumber()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            var test = new HumanLogic(mock.Object);

            //Act
            var something = test.GeneratePersonNumber(DateTime.Now);

            //Assert
            Assert.AreEqual(something.Substring(0, 6), DateTime.Now.ToString("yyMMdd") );
        }

        [TestMethod]
        public void UpdateHumanTest()
        {
            //Arrange
            Human human = new Human
            {
                FirstName = "Anton",
                LastName = "Cornett"
            };

            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.Update(human)).Returns(true);

            var logic = new HumanLogic(mock.Object);

            //Act
            var something = logic.UpdateHuman(human);

            //Assert
            Assert.IsTrue(something);
        }
    }
}