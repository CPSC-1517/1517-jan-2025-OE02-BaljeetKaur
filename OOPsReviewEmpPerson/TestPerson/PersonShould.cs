using OOPsReview;
using FluentAssertions;

namespace TestPerson
{
    public class Person_Should
    {
        [Fact]
        public void Create_An_Instance_Using_The_Default_Constructor()
        {
            // Arrange
            string expextedFirstName = "Unknown";
            string expextedLastName = "Unknown";

            //Act
            //sut : subject under testing
            Person sut = new Person();
            // Assert
           // Assert.Equal(expextedFirstName, sut.FirstName);

            sut.FirstName.Should().Be(expextedFirstName);
            sut.LastName.Should().Be(expextedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPostions.Count().Should().Be(0);
        }

        [Fact]

        public void Create_An_Instance_Using_The_Greedy_Constructor()
        {
            // Arrange
            string expectedFirstName = "Baljeet" ;
            string expectedLastName = "Kaur";
            ResidentAddress expectedAddress = new ResidentAddress(222, "Maple St", "Edmonton", "AB", "T6Y7U8");

            //Act
            //sut : subject under testing
            Person sut = new Person("Baljeet","Kaur", expectedAddress );
            // Assert
            // Assert.Equal(expextedFirstName, sut.FirstName);

            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAddress);


        }
    }
}