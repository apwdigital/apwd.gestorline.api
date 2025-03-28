using Apwd.GestorLine.Domain.Models.v1.Financial;
using Apwd.GestorLine.Services.Contracts.v1.Financial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apwd.GestorLine.Api.Controllers.Financial;

[ApiController]
[Route("api/v1/financial")]
[Authorize]
[ApiConventionType(typeof(DefaultApiConventions))]
public class FinancialController : ControllerBase
{
    private readonly IFinancialService _financialService;
    public FinancialController(IFinancialService financialService)
    {
        _financialService = financialService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FinancialGetRequest request)
    {
        if (request.CompanyCode == null) return BadRequest();

        var financialDataList = await _financialService.GetAsync(request);
        return Ok(financialDataList);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(string id)
    {
        var financialData = await _financialService.GetById(id);

        if (financialData != null)
            return Ok(financialData);
        else
            return NotFound();
    }

    [HttpPut("{id:guid}")]
    public async Task<int> Update(string id, FinancialPutRequest request)
    {
        var objToUpdate = await _financialService.GetById(id);

        if (objToUpdate != null && objToUpdate.CompanyCode != null)
            return await _financialService.Update(request);
        else
            return 404;
    }

    [HttpGet("info/{CompanyCode}")]
    public async Task<FinancialGetInfoResponse> GetInfo(string CompanyCode)
       => await _financialService.GetInfoAsync(CompanyCode);

    [HttpPost("info")]
    public async Task<FinancialGetInfoResponse> AddInfo(FinancialInfoPostRequest request)
       => await _financialService.AddInfoAsync(request);

    [HttpPost]
    public async Task<FinancialResponse> Add(FinancialPostRequest request)
        => await _financialService.Add(request);
}
