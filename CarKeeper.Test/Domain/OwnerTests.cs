using CarKeeper.Domain.Models.Owner;

namespace CarKeeper.Test.Domain;

public class OwnerTests
{
    [Fact]
    public void CanCreateOwner()
    {
        //Arrange and Act
        var owner = new VehicleOwner("John Doe", "John.doe@example.com");

        //Assert
        Assert.Equal("John Doe", owner.Name);
        Assert.Equal("John.doe@example.com", owner.Email);
    }
}
