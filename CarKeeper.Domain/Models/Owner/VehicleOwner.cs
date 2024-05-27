namespace CarKeeper.Domain.Models.Owner;

public class VehicleOwner
{
    public VehicleOwner(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }
    public string Email { get; set; }
}
