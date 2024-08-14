using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RateLimit.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;


namespace RateLimit.ApiServices;
public class ApiService{

   
    public static Dictionary<string,int> GetEndpointsWithAttribute()
    {
        var endpoints = new Dictionary<string,int>();
        var controllers = Assembly.GetEntryAssembly().GetTypes()
            .Where(t => typeof(ControllerBase).IsAssignableFrom(t));
        // Console.WriteLine($"No of Controller Base:{controllerTypes.Count()}");

        foreach (var type in controllers)
        {
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            foreach (var method in methods)
            {
                // for Getting Rate Limiter Attribute
                var attribute=method.GetCustomAttributes(typeof(RateLimiter), true);
                var hasAttribute = attribute.Any();
                if (hasAttribute)
                {
                    //    For Getting Endpoints
                    var x=method.GetCustomAttributes(typeof(HttpMethodAttribute),true);
                    string template=x.Cast<HttpMethodAttribute>().FirstOrDefault().Name??x.Cast<HttpMethodAttribute>().FirstOrDefault().Template;
                    string endpoint=$"{type.Name.Split("Controller").FirstOrDefault()}/{template}";
                    // Console.WriteLine($"{type.Name.Split("Controller").FirstOrDefault()}/{template}");
                    int time=attribute.Cast<RateLimiter>().FirstOrDefault().GetTime();
                    endpoints.Add(endpoint,time);
                    
                    
                }
            }
        }

        return endpoints;
    }


}