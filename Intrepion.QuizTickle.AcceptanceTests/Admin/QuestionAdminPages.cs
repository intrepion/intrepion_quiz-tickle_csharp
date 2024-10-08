﻿using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Intrepion.QuizTickle.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class QuestionAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        await Expect(Page).ToHaveTitleAsync("Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Questions" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Question List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Question Creation");

        await Page.GetByTestId("questionAdminEditText").FillAsync("a question");
        // CreatePropertyCodePlaceholder
        // await Page.GetByTestId("questionAdminEditName").FillAsync("a question");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Question Modification");

        await Page.GetByTestId("questionAdminEditText").FillAsync("some question");
        // ModifyPropertyCodePlaceholder
        // await Page.GetByTestId("questionAdminEditName").FillAsync("some question");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Question Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Question List");
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
