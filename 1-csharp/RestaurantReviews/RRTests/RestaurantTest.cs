using Xunit;
using RRModels;
using System;
namespace RRTests
{
    public class RestaurantTest
    {
        [Fact]
        public void CityShouldSetValidData(){
            //arange
            string city = "San Francisco";
            Restaurant test = new Restaurant();
            
            //act
            test.City = city;

            //assert
            Assert.Equal(city, test.City);
        }
        /*[Theory]
        [InlineData("2345678i")]
        [InlineData("gsdfgdsfgmdfogm")]*/
        [Theory]
        [InlineData("2345678i")]
        [InlineData("beufkjsdhfkjs1")]
        public void CityShouldNotSetInvalidData(string input){
            //Arrange
            Restaurant test = new Restaurant();

            //Act and Assert
            Assert.Throws<Exception>(() => test.City = input);
        }
    }
}