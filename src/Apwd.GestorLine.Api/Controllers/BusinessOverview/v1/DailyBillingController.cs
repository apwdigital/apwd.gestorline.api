using Apwd.GestorLine.Domain.Models.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.Filters;
using Apwd.GestorLine.Services.Contracts.v1.BusinessOverview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Apwd.GestorLine.Api.Controllers.BusinessOverview.v1;

[ApiController]
[Route("api/v1/dailybilling")]
[Authorize]
public class DailyBillingController : ControllerBase
{
    private readonly IDailyBillingService _dailyBillingService;
    private readonly ILogger<DailyBillingController> _logger;

    public DailyBillingController(
        IDailyBillingService dailyBillingService,
        ILogger<DailyBillingController> logger
        )
    {
        _dailyBillingService = dailyBillingService;
        _logger = logger;
    }

    [HttpPost("hourlybilling")]
    public async Task<string> AddHourlyBilling(HourlyBillingIntagrationModel model)
    {
        string message = "OK";
        _logger.LogInformation($"[dailybilling.CreatedAt]: {model.CreatedAt} | {model.GrossAmount}]");

        try
        {
            var date = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            var dayOfWeek = FirstCharSubstring(new CultureInfo("pt-BR").DateTimeFormat.GetDayName(date.DayOfWeek));
            _logger.LogInformation($"[start hourlybilling with date]: {date}");

            SearchFilter filter = new SearchFilter();
            filter.StartDate = model.CreatedAt;
            filter.CompanyCode = model.CompanyCode;
            filter.YearMonthCode = model.DailyBillingCode;

            DailyBillingResponse dailyBilling = await _dailyBillingService.GetByCode(filter);


            if (dailyBilling != null)
            {
                dailyBilling.HourlyBillings.Add(new HourlyBillingModel()
                {
                    CreatedAt = model.CreatedAt,
                    GrossAmount = model.GrossAmount
                });

                // TODO
                DailyBillingPutRequest dailyBillingPostRequest = new DailyBillingPutRequest
                {
                    Id = dailyBilling.Id,
                    CompanyCode = dailyBilling.CompanyCode,
                    Code = dailyBilling.Code,
                    DayOfWeek = dayOfWeek,
                    GoalGrossAmount = dailyBilling.GoalGrossAmount,
                    GrossAmount = model.GrossAmount,
                    WorkDay = dailyBilling.WorkDay,
                    HourlyBillings = dailyBilling.HourlyBillings
                };

                await _dailyBillingService.Update(dailyBillingPostRequest);
            }
            else
                message = "Não foi possível efetuar a atualização do faturamento (data não cadastrada)";
        }
        catch (Exception ex)
        {
            message = $"Não foi possível adicionar o faturamento {ex.Message.ToString().Substring(0, 150)}";
        }
        return message;
    }

    public static string FirstCharSubstring(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        return $"{input[0].ToString().ToUpper()}{input.Substring(1)}";
    }
}