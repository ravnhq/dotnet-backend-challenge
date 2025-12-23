namespace BackendChallenge.DTOs;

public class AddStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }

    public AddStudentDto(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }
}
