using Microsoft.AspNetCore.Mvc;

namespace Apwd.GestorLine.Api.Controllers.System
{
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
                appVersion = "20250327-001",
                lastFeatureUpdate = "GestorLine.Api",
                localDateTime = DateTime.Now.ToString()
            };
        }
    }
}
