namespace Application.FunctionalTests.User.Commands;

using Application.User.Commands.CreateUser;
using FluentAssertions;
using FluentValidation;
using static Testing;

public class CreateUserTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateUserCommand();

        await FluentActions
            .Invoking(() => SendAsync(command))
            .Should()
            .ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateUser()
    {
        var command = new CreateUserCommand
        {
            Name = "Janderley Sousa",
            Username = "jsousa",
            Password = "1234"
        };

        var result = await SendAsync(command);

        result.Succeeded.Should().BeTrue();
    }
}
