﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
public static class ApiConsumer 
{
   private static string ApiAddress = "http://192.168.0.105:9191/api/";
   

   public async static Task<IEnumerable<HighPointsModel>> GetAllHighPoints()
   {
       try
       {
           HttpClient client = new HttpClient();
           client.BaseAddress = new Uri(ApiAddress);
           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
           HttpResponseMessage response = await client.GetAsync("highpoints");  
           
                if (response.IsSuccessStatusCode)  
                 return response.Content.ReadAsAsync<IEnumerable<HighPointsModel>>().Result;  
                return null;  
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
           HttpClient client = new HttpClient();
           client.BaseAddress = new Uri(ApiAddress);
           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
           HttpResponseMessage response =  client.PostAsJsonAsync("highpoints",playerScore).Result;
           
           
           return response.ToString();
           
       }
       catch
       {
          
           return "false";
       }
   }
}
