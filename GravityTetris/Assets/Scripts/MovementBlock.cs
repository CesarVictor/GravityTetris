using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 10f;
    public Text Life;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        }

        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime)){ 
            transform.position += new Vector3(0,-1,0); 
            previousTime = Time.time;
        }

    }
    string moinsvie = "♡";
    string vie ="♥";
    int life = 3;
    int lifemax = 3;
    private void OnCollisionEnter2D(Collision2D MovementBlock)
    { 
        if (MovementBlock.gameObject.tag == "mur") 
            Destroy(this.gameObject);
            // life = life-1;
            // if (life == 0)
            //     SceneManager.LoadScene("Game_Over");
            // Life.text = "";
            // for (int i =life; i > 0; i--) 
            //     Life.text += vie;
            // for (int i = lifemax-life; i > 0; i--) 
            //     Life.text += moinsvie;   
    }
    private void OnTriggerStay2D(Collider2D MovementBlock) {
        if (MovementBlock.gameObject.tag == "Finish" && this.tag == "Plateforme"){
            SceneManager.LoadScene("Victory");
        }
    }
}
