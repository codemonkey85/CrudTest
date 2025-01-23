namespace CrudTest.ApiEndpoints;

public static class PeopleEndpoints
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        var apiGroup = app.MapGroup("people");

        apiGroup.MapGet("/", GetPeople);
        apiGroup.MapGet("/{id:int}", GetPersonById);
        apiGroup.MapPost("/", CreatePerson);
        apiGroup.MapPut("/{id:int}", UpdatePerson);
        apiGroup.MapDelete("/{id:int}", DeletePerson);

        return app;
    }

    private static async Task<List<Person>> GetPeople(AppDbContext dbContext) =>
        await dbContext.People
            .AsNoTracking()
            .ToListAsync();

    private static async Task CreatePerson(AppDbContext dbContext, PersonDto person)
    {
        dbContext.Add(new Person { Name = person.Name, Age = person.Age });
        await dbContext.SaveChangesAsync();
    }

    private static async Task<Person?> GetPersonById(AppDbContext dbContext, int id) =>
        await dbContext.People
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

    private static async Task<Person?> UpdatePerson(AppDbContext dbContext, int id, PersonDto person)
    {
        var updatedResults = await dbContext.People
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Name, person.Name)
                .SetProperty(p => p.Age, person.Age));

        return updatedResults == 1
            ? await dbContext.People
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id)
            : null;
    }

    private static async Task<bool> DeletePerson(AppDbContext dbContext, int id)
    {
        var deletedCount = await dbContext.People
            .Where(person => person.Id == id)
            .ExecuteDeleteAsync();

        return deletedCount == 1;
    }
}
