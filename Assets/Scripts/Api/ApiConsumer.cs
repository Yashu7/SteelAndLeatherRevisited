using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Net;
public static class ApiConsumer 
{
   private static string ApiAddress = "http://192.168.0.105:711/api/";
   private static string ApiAddressAlternative = "http://192.168.0.103:711/api/";
   

   public static readonly HttpClient client = new HttpClient();
   public async static Task<IEnumerable<HighPointsModel>> GetAllHighPoints()
   {
       try
       {
           using(client)
           {
           client.BaseAddress = new Uri(ApiAddress);
           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
           HttpResponseMessage response = await client.GetAsync("highpoints");  
           
                if (response.IsSuccessStatusCode)  
                 return response.Content.ReadAsAsync<IEnumerable<HighPointsModel>>().Result;  
                return null;  
           }
       }
       catch
       {
           return null;
       }
   }
   public  static string InsertHighScore(HighPointsModel playerScore)
   {
      
        try
        {
          using(client)
          {
                client.BaseAddress = new Uri(ApiAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                client.DefaultRequestHeaders.Add("User-Agent", "web api client");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                ServicePointManager.SecurityProtocol =   SecurityProtocolType.Tls;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                HttpResponseMessage response;
                try
                {
                     response =  client.PostAsJsonAsync("highpoints",playerScore).Result;
                }
                catch (System.Exception)
                {
                    client.BaseAddress = new Uri(ApiAddressAlternative);
                     response =  client.PostAsJsonAsync("highpoints",playerScore).Result;
                }
                 
                     
           
           
           return response.ToString();
          }
        }
        catch(Exception ex)
        {
            return ex.InnerException.ToString();
        }
           
       
   }
}
