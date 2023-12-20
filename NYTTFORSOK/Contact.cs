

namespace NYTTFORSOK;

public class Contact
{
    public string FirstName { get; set; } = null!;
     public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;

    public Contact(string firstName, string lastName, string email, string phoneNumber, string adress)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = adress;
    }
}
