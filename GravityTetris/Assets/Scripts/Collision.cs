using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private bool canSpawnNewTetromino = true;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Plateforme")  && canSpawnNewTetromino)
        {
            DisableMovementBlock();
            SpawnerTetromino spawnerTetromino = FindObjectOfType<SpawnerTetromino>();
            spawnerTetromino.NewTetromino();
            this.tag = "Plateforme";
            print(this.tag);
            canSpawnNewTetromino = false;    
        }
        if (other.gameObject.CompareTag("mur")  && canSpawnNewTetromino)
        {
            DisableMovementBlock();
            SpawnerTetromino spawnerTetromino = FindObjectOfType<SpawnerTetromino>();
            spawnerTetromino.NewTetromino();
            this.tag = "Plateforme";
            print(this.tag);
            canSpawnNewTetromino = false;            
        }
    }

    void DisableMovementBlock()
    {
        MovementBlock movementBlock = GetComponent<MovementBlock>();
        if (movementBlock != null)
        {
            movementBlock.enabled = false;
        }
    }

    void ResetSpawnCondition()
    {
        canSpawnNewTetromino = true;
    }
}
