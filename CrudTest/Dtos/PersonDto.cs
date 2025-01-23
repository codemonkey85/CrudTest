namespace CrudTest.Dtos;

// ReSharper disable once ClassNeverInstantiated.Local
[SuppressMessage("ReSharper", "UnusedMember.Local"),
 SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local"),
 SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
public class PersonDto
{
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }
}
