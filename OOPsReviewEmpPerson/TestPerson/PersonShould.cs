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
            sut.EmploymentPositions.Count().Should().Be(0);
        }

        [Fact]

        public void Create_An_Instance_Using_The_Greedy_Constructor()
        {
            // Arrange
            string expectedFirstName = "Baljeet" ;
            string expectedLastName = "Kaur";
            ResidentAddress expectedAddress = new ResidentAddress(222, "Maple St", "Edmonton", "AB", "T6Y7U8");
            Employment one = new Employment("PG I", SupervisoryLevel.TeamMember,DateTime.Parse("2013/10/04"), 6.4);
            Employment two = new Employment("PG II", SupervisoryLevel.TeamMember, DateTime.Parse("2015/10/04"), 4.4);
            List<Employment> employmentpositions = new List<Employment>();
            employmentpositions.Add(one);
            employmentpositions.Add(two);
            int expectedEmploymentCount = employmentpositions.Count();
            //Act
            //sut : subject under testing
            Person sut = new Person("Baljeet","Kaur", expectedAddress, employmentpositions );
            // Assert
            // Assert.Equal(expextedFirstName, sut.FirstName);

            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAddress);
            sut.EmploymentPositions.Count.Should().Be(expectedEmploymentCount);


        }

        [Fact]

        public void Return_the_Full_Name()
        {
            // Arrange
            string expectedFullName  = "Kaur, Baljeet";
            ResidentAddress expectedAddress = new ResidentAddress(222, "Maple St", "Edmonton", "AB", "T6Y7U8");
            Employment one = new Employment("PG I", SupervisoryLevel.TeamMember, DateTime.Parse("2013/10/04"), 6.4);
            Employment two = new Employment("PG II", SupervisoryLevel.TeamMember, DateTime.Parse("2015/10/04"), 4.4);
            List<Employment> employmentpositions = new List<Employment>();
            employmentpositions.Add(one);
            employmentpositions.Add(two);
            int expectedEmploymentCount = employmentpositions.Count();
            //Act
            //sut : subject under testing
            Person sut = new Person("Baljeet", "Kaur", expectedAddress, employmentpositions);
            string fullName = sut.FullName;

            
            // Assert
            // Assert.Equal(expextedFirstName, sut.FirstName);

           
            sut.Address.Should().Be(expectedAddress);
            sut.EmploymentPositions.Count.Should().Be(expectedEmploymentCount);
            sut.FullName.Should().Be(expectedFullName);

        }
    }
}