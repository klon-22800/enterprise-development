using Hospital.Core.Domain.Models;
using Hospital.Core.Tests.Fixtures;
using System.Linq;

namespace Hospital.Core.Tests;

public class UnitTest1 : IClassFixture<TestDataFixture>
{
    private readonly TestDataFixture _fixture;

    public UnitTest1(TestDataFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Doctors_With_Experience_10_Or_More_Should_Be_Displayed()
    {
        var result = _fixture.Doctors
            .Where(d => d.Expirience >= 10)
            .Select(d => $"Доктор: {d.Surname} {d.Name} {d.Patronymic}, Стаж: {d.Expirience} лет, Специализация: {d.Specialization.Name}")
            .ToList();

        Assert.NotEmpty(result);

        result.ForEach(Console.WriteLine);
    }
}
