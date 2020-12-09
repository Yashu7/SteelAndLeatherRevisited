using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
   public static void Set(string userName)
   {
       PlayerPrefs.SetString("UserName", userName);
       PlayerPrefs.Save();
   }

   public static string Get()
   {
       return PlayerPrefs.GetString("UserName", "Unknown");
   }
}
