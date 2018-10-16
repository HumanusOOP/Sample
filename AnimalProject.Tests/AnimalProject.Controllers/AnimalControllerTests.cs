using System;
using System.Collections.Generic;
using System.Net;
using AnimalProject.Controllers;
using AnimalProject.Domain.Models;
using AnimalProject.Domain.Models.Interfaces;
using AnimalProject.Domain.Repositories.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AnimalProject.Tests.AnimalProject.Controllers
{
    public class Calculator
    {
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        [Fact]
        public void Multiply_TwoPositiveValuesProvided_ExpectedProductIsReturned()
        {
            //Arrange
            var expectedReturnProduct = 100;
            var sut = new Calculator();

            //Act
            var actualProduct = sut.Multiply(10, 10);

            //Assert
            Assert.Equal(expectedReturnProduct, actualProduct);
        }
    }

    public class AnimalsControllerTests
    {
        [Fact]
        public void GetAllAnimals_RepositoryIsSetup_ExpectedAnimalsReturned()
        {
            //Arrange
            var expectedList = new List<IAnimal>
            {
                new Cat { Age = 5, Name = "Trasan" },
                new Giraffe { Age = 8, Name = "Långben" },
                new Sparrow { Name = "Fjäder" },
                new Sparrow { Name = "Flygarn" }
            };

            var expectedStatusCode = 200;
            var expectedNumber = expectedList.Count;

            var fakeRepository = A.Fake<IAnimalRepository>();
            A.CallTo(() => fakeRepository.GetAllAnimals()).Returns(expectedList);
            var sut = new AnimalsController(fakeRepository);

            //Act
            var result = sut.GetAllAnimals();
            var okObjectResult = (OkObjectResult) result;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(expectedStatusCode, okObjectResult.StatusCode);
            Assert.True(okObjectResult.Value is List<IAnimal>);
            Assert.Equal(expectedNumber, ((List<IAnimal>) okObjectResult.Value).Count);
        }

        [Fact]
        public void GetAllAnimals_RepositoryGetAllAnimalsThrowsException_ExpectedAnimalsReturned()
        {
            //Arrange
            var expectedMessage = "expectedExceptionMessage";
            var expectedStatusCode = (int)HttpStatusCode.InternalServerError;

            var fakeRepository = A.Fake<IAnimalRepository>();
            A.CallTo(() => fakeRepository.GetAllAnimals()).Throws(new Exception(expectedMessage));
            var sut = new AnimalsController(fakeRepository);

            //Act
            var result = sut.GetAllAnimals();
            var okObjectResult = (StatusCodeResult) result;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(expectedStatusCode, okObjectResult.StatusCode);
        }

        [Fact]
        public void GetAllAnimals_GetAllAnimalsReturnsNull_ExpectedAnimalsReturned()
        {
            //Arrange
            var expectedStatusCode = 200;

            var fakeRepository = A.Fake<IAnimalRepository>();
            A.CallTo(() => fakeRepository.GetAllAnimals()).Returns(null);
            var sut = new AnimalsController(fakeRepository);

            //Act
            var result = sut.GetAllAnimals();
            var okObjectResult = (OkObjectResult) result;

            //Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(expectedStatusCode, okObjectResult.StatusCode);
            Assert.True(okObjectResult.Value is List<IAnimal>);
        }
    }
}
