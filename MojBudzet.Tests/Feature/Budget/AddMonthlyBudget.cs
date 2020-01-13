using Bogus;
using FluentAssertions;
using Flurl.Http;
using LiteDB;
using MojBudzet.BussinessLayer.Application.Budget;
using MojBudzet.Tests;
using System;
using System.Net;
using System.Net.Http;
using Xbehave;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using MojBudzet.BussinessLayer.Infrastructure.Budget;
using System.Collections.Generic;

namespace MojBudget.Tests.Feature.Budget
{
    public class AddMonthlyBudget : IClassFixture<InMemoryDatabaseWebApplicationFactory<MojBudzet.Startup>>
    {
        private readonly FlurlClient flurlClient;
        private readonly IServiceProvider serviceProvider;
        
        private readonly DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
        private readonly DateTime EndDate = new DateTime(DateTime.Now.Year, 12, 31);

        private readonly string monthlyBudgetEndpoint = "/api/MonthlyBudget";
        private readonly string identifierFormat = "MM/yy";

        public AddMonthlyBudget(InMemoryDatabaseWebApplicationFactory<MojBudzet.Startup> factory)
        {
            this.serviceProvider = factory.Services;
            this.flurlClient = new FlurlClient(factory.CreateDefaultClient());
        }

        [Scenario(DisplayName ="Poprawne dodanie miesięcznego budżetu")]
        public void Correct_Add(AddMonthlyBudgetCommand testCommand, HttpResponseMessage responseMessage)
        {
            "Zakładając, że nie istnieje budżet miesięczny."
                .x(() => { });

            "Kiedy użytkownik zażada dodania nowego miesięcznego budżetu."
                .x(async () =>
                {
                    testCommand = new Faker<AddMonthlyBudgetCommand>("pl")
                    .RuleFor(command => command.Month, (faker, command) => faker.Date.Between(this.startDate, this.EndDate))
                    .Generate();

                    responseMessage = await this.flurlClient
                        .AllowAnyHttpStatus()
                        .Request(this.monthlyBudgetEndpoint)
                        .PostJsonAsync(testCommand);
                });

            "Wtedy zostanie on utworzony i zapisany."
                .x(() =>
                {
                    responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
                    responseMessage.Headers.Location.Should().Be($"{this.monthlyBudgetEndpoint}/{testCommand.Month.ToString(this.identifierFormat)}");
                });
        }

        [Scenario(DisplayName = "Nieudane dodanie miesięcznego budżetu - istnieje już budżet miesieczny")]
        public void Monthly_Budget_Exists(AddMonthlyBudgetCommand testCommand, HttpResponseMessage responseMessage)
        {
            "Zakładając, że już istnieje budżet miesięczny."
                .x(() =>
                {
                    testCommand = new Faker<AddMonthlyBudgetCommand>("pl")
                    .RuleFor(command => command.Month, (faker, command) => faker.Date.Between(this.startDate, this.EndDate))
                    .Generate();
                    
                    var liteDatabase = this.serviceProvider.GetService<LiteDatabase>();
                    liteDatabase.GetCollection<MonthlyBudgetDocument>().Insert(new MonthlyBudgetDocument
                    {
                        Id = testCommand.Month.ToString(this.identifierFormat),
                        Month = testCommand.Month,
                        Expenses = new List<ExpenseDocument>()
                    });
                });

            "Kiedy użytkownik zażada dodania nowego miesięcznego budżetu."
                .x(async () =>
                {
                    responseMessage = await this.flurlClient
                        .AllowAnyHttpStatus()
                        .Request(this.monthlyBudgetEndpoint)
                        .PostJsonAsync(testCommand);
                });

            "Wtedy zostanie nie zostanie on utworzony."
                .x(() =>
                {
                    responseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                });
        }
    }
}
