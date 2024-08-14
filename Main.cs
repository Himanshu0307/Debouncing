using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RateLimit.Attributes;
using Microsoft.AspNetCore.Mvc;
using RateLimit.Model;
using System.Security.Policy;
using RateLimit.ApiServices;
using Microsoft.AspNetCore.Http;

namespace RateLimit
{
    public class MainClass
    {

        public static Dictionary<string, Node> endpoint = new Dictionary<string, Node>();

        public  static void Main(string[] args){
            // Get All End points
            Dictionary<string,int> api=ApiService.GetEndpointsWithAttribute();
            // Prepare DS
            foreach(var x in api){
                endpoint.Add(x.Key,new Node(1));
            }
            bool success=endpoint["Api/a"].AddRequest("ABC");
            Console.WriteLine("Result:"+success);
            success=success && (endpoint["Api/b"].AddRequest("ABC"));
            Console.WriteLine("Result:"+success);
        }
        
       
        
        
    }
}
