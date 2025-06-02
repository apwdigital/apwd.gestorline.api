using Apwd.GestorLine.Domain.Models.v1.BusinessOverview;
using Apwd.GestorLine.Domain.Models.v1.Filters;
using Apwd.GestorLine.Services.Contracts.v1.BusinessOverview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apwd.GestorLine.Api.Controllers.BusinessOverview.v1;

[ApiController]
[Route("api/v1/businessoverview")]
[Authorize]
public class BusinessOverviewController : ControllerBase
{

    private readonly IMonthlyDataService _monthlyDataService;
    public BusinessOverviewController(
        IMonthlyDataService monthlyDataService)
    {
        _monthlyDataService = monthlyDataService;
    }

    [HttpGet("monthly/{companyCode}/{yearMonthCode}")]
    public async Task<IActionResult> GetMonthly(string companyCode, int yearMonthCode)
    {
        var monthlyData = await _monthlyDataService.GetByFilter(new SearchFilter(companyCode, yearMonthCode));
        return Ok(monthlyData);
    }

    [HttpPost("monthly")]
    public async Task<IActionResult> AddMonthly(MonthlyDataPostRequest request)
    {
        var monthlyData = await _monthlyDataService.Add(request);
        return Ok(monthlyData);
    }

    [HttpPut("monthly/{id:guid}")]
    public async Task<IActionResult> UpdateMonthly(string id, MonthlyDataRequest request)
    {
        var objToUpdate = await _monthlyDataService.GetById(id);

        if (objToUpdate == null) return NotFound();

        return Ok(await _monthlyDataService.Update(request));
    }
}