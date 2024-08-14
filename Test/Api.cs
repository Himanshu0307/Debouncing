using Microsoft.AspNetCore.Mvc;
using RateLimit.Attributes;
namespace RateLimit.ApiEndpoint
{
    public class ApiController:ControllerBase
    {

        [HttpPost("a")]
        [RateLimiter(5)]
        public void getWeather(){
            
        }

        [HttpGet("b")]
        [RateLimiter(10)]
        public void getWeathers(){
            
        }

    }
    
}