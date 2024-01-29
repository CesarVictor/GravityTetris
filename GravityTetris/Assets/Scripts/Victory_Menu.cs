using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Victory_Menu : MonoBehaviour
{
    public Text Score;
    float score;
    void Start(){
        score = Game_Menu.timeRemaining; 
        float min=Mathf.FloorToInt(score/60);
        float sec=Mathf.FloorToInt(score%60);
        Score.text = string.Format("Tu a fini en : {0:00} min {1:00} sec",min,sec);
    }
    public void Retry()
    {   
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Menu_Principal");
    }

}

