using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerTetromino : MonoBehaviour
{
    public GameObject bonusfigure;
    public GameObject[] Tetrominoes;
    public GameObject Previews;
    public static bool isSpawning = false;
    int bonusnumber;
    void Start()
    {
        bonusnumber = 0;
    }

    public void NewTetromino()
    {
        if (isSpawning)
        {
            return;
        }
        isSpawning = true;
        GameObject newTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], transform.position, Quaternion.identity);

        MovementBlock movementBlock = newTetromino.GetComponent<MovementBlock>();
        if (movementBlock != null)
        {
            movementBlock.enabled = true;
        }
        newTetromino.SetActive(true);
        StartCoroutine(ResetSpawnFlag());
        if (newTetromino.name == "S(Clone)" || newTetromino.name == "T(Clone)") {
        Previews.transform.position = new Vector3 (newTetromino.transform.position.x + 0.5f, 0 , 0);
        } else {
        Previews.transform.position = new Vector3 (newTetromino.transform.position.x, 0 , 0);
        }
        Previews.transform.localScale = new Vector3 (newTetromino.transform.localScale.x , 36, 0);

    }
    public void BonusSpawn(){
        if (isSpawning)
        {
            return;
        }
        isSpawning = true;
        SpawnerTetromino.isSpawning = true;
        GameObject newTetromino = Instantiate(bonusfigure, transform.position, Quaternion.identity);
        MovementBlock movementBlock = newTetromino.GetComponent<MovementBlock>();
        if (movementBlock != null)
        {
            movementBlock.enabled = true;
        }
        newTetromino.SetActive(true);
        StartCoroutine(ResetSpawnFlag());
        Previews.transform.position = new Vector3 (newTetromino.transform.position.x, 0 , 0);
        Previews.transform.localScale = new Vector3 (newTetromino.transform.localScale.x , 36, 0);
    }
    IEnumerator ResetSpawnFlag()
    {
        yield return new WaitForSeconds(0.5f);
        isSpawning = false;
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.B) && bonusnumber == 0)
        {
            Game_Menu.timeRemaining += 30;
            bonusnumber = 1;
            Collision.bonus = true;
        }
    }
}