using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Intrepion.QuizTickle.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class QuizAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        await Expect(Page).ToHaveTitleAsync("Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Quizzes" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Quiz List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Quiz Creation");

        await Page.GetByTestId("quizAdminEditName").FillAsync("a quiz");
        // CreatePropertyCodePlaceholder
        // await Page.GetByTestId("quizAdminEditName").FillAsync("a quiz");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Quiz Modification");

        await Page.GetByTestId("quizAdminEditName").FillAsync("some quiz");
        // ModifyPropertyCodePlaceholder
        // await Page.GetByTestId("quizAdminEditName").FillAsync("some quiz");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Quiz Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Quiz List");
    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("http://localhost:5085");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Log in");
        await Page.GetByTestId("loginEmail").FillAsync("Admin1@Intrepion.QuizTickle.com");
        await Page.GetByTestId("loginPassword").FillAsync("Admin1@Intrepion.QuizTickle.com");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
    }
}
