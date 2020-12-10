using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Game's user name storage.
/// </summary>
public class User : MonoBehaviour
{
    /// <summary>
    /// Saves inserted user name to Unity's PlayerPrefs settings.
    /// </summary>
    /// <param name="userName"></param>
   public static void SetGlobalUsername(string userName)
   {
       PlayerPrefs.SetString("UserName", userName);
       PlayerPrefs.Save();
   }
   /// <summary>
   /// Returns Global user name from Unity's PlayerPrefs settings.
   /// </summary>
   /// <returns>User name</returns>
   public static string GetGlobalUsername()
   {
       return PlayerPrefs.GetString("UserName", "Unknown");
   }
}
