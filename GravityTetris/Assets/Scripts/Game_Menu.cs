using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Menu : MonoBehaviour
{
    public GameObject Base_1;
    public GameObject Base_2;
    public GameObject Base_3;
    public GameObject Base_4;
    public GameObject Base_5;
    public GameObject Base_6;
    private void Start() {
        int number = Random.Range(1, 6);
        Vector2 pos = new Vector2(15.59f, -12.38f);
        if (number == 1)
        Instantiate(Base_1, pos, Quaternion.identity);
        else if (number == 2)
        Instantiate(Base_2, pos, Quaternion.identity);
        else if (number == 3)
        Instantiate(Base_3, pos, Quaternion.identity);
        else if (number == 4)
        Instantiate(Base_4, pos, Quaternion.identity);
        else if (number == 5)
        Instantiate(Base_5, pos, Quaternion.identity);
        else if (number == 6)
        Instantiate(Base_6, pos, Quaternion.identity);

    }

    public void Quit()
    {
    SceneManager.LoadScene("Menu_Principal");
    }
    public Text startText;
    float timeRemaining ;
    void Update()
    {
        timeRemaining += Time.deltaTime;
        float min=Mathf.FloorToInt(timeRemaining/60);
        float sec=Mathf.FloorToInt(timeRemaining%60);
        startText.text=string.Format("{0:00}:{1:00}",min,sec);
    }
}

