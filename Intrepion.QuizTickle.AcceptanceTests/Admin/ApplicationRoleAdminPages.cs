﻿using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Intrepion.QuizTickle.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class ApplicationRoleAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "Application Roles" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application Role List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application Role Creation");
        await Page.GetByTestId("applicationRoleAdminEditName").FillAsync("a applicationRole");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application Role Modification");
        await Page.GetByTestId("applicationRoleAdminEditName").FillAsync("some applicationRole");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application Role Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Application Role List");
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
