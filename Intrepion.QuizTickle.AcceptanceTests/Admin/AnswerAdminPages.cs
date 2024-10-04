using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace ApplicationNamePlaceholder.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class AnswerAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        await Expect(Page).ToHaveTitleAsync("Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Answers" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Answer List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Answer Creation");

        await Page.GetByTestId("answerAdminEditOrdering").FillAsync("1");
        await Page.GetByTestId("answerAdminEditText").FillAsync("a answer");
        // CreatePropertyCodePlaceholder
        // await Page.GetByTestId("answerAdminEditName").FillAsync("a answer");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Answer Modification");

        await Page.GetByTestId("answerAdminEditOrdering").FillAsync("2");
        // ModifyPropertyCodePlaceholder
        // await Page.GetByTestId("answerAdminEditName").FillAsync("some answer");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Answer Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Answer List");
    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("http://localhost:5085");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Log in");
        await Page.GetByTestId("loginEmail").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByTestId("loginPassword").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
    }
}
