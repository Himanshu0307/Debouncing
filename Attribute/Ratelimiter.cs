using System;
namespace RateLimit.Attributes
{
    [System.AttributeUsage(AttributeTargets.Method)]
    public class RateLimiter:System.Attribute   
    {

        private int time;

        public RateLimiter(int time){
            this.time=time;
        }

        public int GetTime(){
            return time;
        }

    }
    
}