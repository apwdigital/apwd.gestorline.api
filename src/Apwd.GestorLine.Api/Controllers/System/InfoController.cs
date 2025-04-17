using Microsoft.AspNetCore.Mvc;

namespace Apwd.GestorLine.Api.Controllers.System;

[ApiController]
[Route("api/v1/systeminfo")]
public class InfoController : ControllerBase
{
    [HttpGet]
    public async Task<dynamic> Get()
    {
        await Task.Delay(1);
        return new
        {
            appVersion = "20250417-001",
            lastFeatureUpdate = "Apwd.GestorLine.Api",
            localDateTime = DateTime.Now.ToString()
        };
    }
}
