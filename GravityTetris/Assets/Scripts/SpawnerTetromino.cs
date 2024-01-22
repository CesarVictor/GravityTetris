using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTetromino : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    private bool isSpawning = false;
    void Start()
    {
        NewTetromino();
    }
    public void NewTetromino()
    {
        if (isSpawning)
        {
            return;
        }
        isSpawning = true;
        GameObject newTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], transform.position,
        Quaternion.identity);
        MovementBlock movementBlock = newTetromino.GetComponent<MovementBlock>();
        if (movementBlock != null)
        {
            movementBlock.enabled = true;
        }
        newTetromino.SetActive(true);
        StartCoroutine(ResetSpawnFlag());
    }

    IEnumerator ResetSpawnFlag()
    {
        yield return new WaitForSeconds(0.5f);
        isSpawning = false;
    }
}