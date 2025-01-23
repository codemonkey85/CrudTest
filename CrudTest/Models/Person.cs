namespace CrudTest.Models;

public class Person
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }
}
