using Hospital.Core.Domain.Models;
using Hospital.Core.Tests.Fixtures;

namespace Hospital.Core.Tests;

public class UnitTest : IClassFixture<TestDataFixture>
{
    private readonly TestDataFixture _fixture;

    public UnitTest(TestDataFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void DoctorsWithExperienceMoreThan10()
    {
        List<Guid> expectedIds = [
            Guid.Parse("d0000000-0000-0000-0000-000000000000"),
            Guid.Parse("d0000000-0000-0000-0000-000000000001"),
            Guid.Parse("d0000000-0000-0000-0000-000000000002"),
            Guid.Parse("d0000000-0000-0000-0000-000000000003"),
            Guid.Parse("d0000000-0000-0000-0000-000000000004"),
            Guid.Parse("d0000000-0000-0000-0000-000000000005"),
            Guid.Parse("d0000000-0000-0000-0000-000000000008"),
        ];

        var resultIds = _fixture.Doctors
            .Where(d => d.Expirience >= 10)
            .OrderBy(d => d.Id)
            .Select(d => d.Id)
            .ToArray();
        System.Console.WriteLine(resultIds);


        Assert.Equal(expectedIds, resultIds);
    }
}
