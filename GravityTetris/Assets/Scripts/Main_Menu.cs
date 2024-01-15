using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_Menu : MonoBehaviour
{
   public void Jouer()
   {
    SceneManager.LoadScene("Game");
   }

   public void Quit()
   {
    Application.Quit();
   }
}
