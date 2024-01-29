using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementBlock : MonoBehaviour
{
    GameObject Previews;
    public Vector3 rotationPoint;
    public float fallTime = 10f;
    int rotate_ho = 0;
    int rotate_ve = 0;
    void Update()
    {
        Previews = GameObject.Find("Preview");
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
            transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
            if (Previews.transform.localScale.x == transform.localScale.x) {
                rotate_ho ++;
                Previews.transform.localScale = new Vector3 (transform.localScale.y , 36 , 0);
                if (name == "B(Clone)" && rotate_ho == 1) {
                    Previews.transform.position = new Vector3 (transform.position.x - 0.5f, 0 , 0);
                }
                else if (name == "B(Clone)" && rotate_ho == 2) {
                    Previews.transform.position = new Vector3 (transform.position.x + 0.5f, 0 , 0);
                }
                if (name == "L(Clone)" && rotate_ho == 1) {
                    Previews.transform.position = new Vector3 (transform.position.x - 0.5f, 0 , 0);
                } 
                else if (name == "L(Clone)" && rotate_ho == 2) {
                    Previews.transform.position = new Vector3 (transform.position.x + 0.5f, 0 , 0);
                }
                if (rotate_ho == 2)  {
                    rotate_ho = 0;
                }
                if (name == "S(Clone)" || name == "T(Clone)") {
                    Previews.transform.position = new Vector3 (transform.position.x, 0 , 0) ;
                }
            }
            else if (Previews.transform.localScale.x == transform.localScale.y) {
                rotate_ve ++;
                Previews.transform.localScale = new Vector3 (transform.localScale.x , 36 , 0);
                if (name == "S(Clone)" && rotate_ve == 1) {
                    Previews.transform.position = new Vector3 (transform.position.x - 0.5f, 0 , 0);
                }
                else if (name == "S(Clone)" && rotate_ve == 2) {
                    Previews.transform.position = new Vector3 (transform.position.x + 0.5f, 0 , 0);
                }
                if (name == "T(Clone)" && rotate_ve == 1) {
                    Previews.transform.position = new Vector3 (transform.position.x - 0.5f, 0 , 0);
                }
                else if (name == "T(Clone)" && rotate_ve == 2) {
                    Previews.transform.position = new Vector3 (transform.position.x + 0.5f, 0 , 0);
                }
                if (rotate_ve == 2)  {
                    rotate_ve = 0;
                }
                if (name != "S(Clone)" && name != "T(Clone)") {
                    Previews.transform.position = new Vector3 (transform.position.x, 0 , 0) ;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.position += new Vector3(0, -1, 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D MovementBlock)
    { 
        if (MovementBlock.gameObject.tag == "mur") {
            Game_Menu.timeRemaining += 10;
            Destroy(this.gameObject); 
        }
            
    }
    private void OnTriggerStay2D(Collider2D MovementBlock) {
        if (MovementBlock.gameObject.tag == "Finish" && this.tag == "Plateforme"){
            SceneManager.LoadScene("Victory");
            SceneManager.UnloadSceneAsync("Game");
        }
    }
}
