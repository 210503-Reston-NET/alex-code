using Xunit;
using RRModels;
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
        [Theory]
        [InlineData("2345678i")]
        [InlineData(null)]

        public void CityShouldNotSetInvalidData(string input){
            //Arrange
            RestaurantTest test = new RestaurantTest();

            //Act and Assert
            Assert.Throws<Exception>(() => test.City = input);
        }
    }
}