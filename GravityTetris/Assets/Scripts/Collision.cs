using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public static bool bonus;
    private bool canSpawnNewTetromino = true;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!bonus) {
        if (other.gameObject.CompareTag("Plateforme")  && canSpawnNewTetromino)
        {
            DisableMovementBlock();
            SpawnerTetromino spawnerTetromino = FindObjectOfType<SpawnerTetromino>();
            spawnerTetromino.NewTetromino();
            this.tag = "Plateforme";
            print(this.tag);
            canSpawnNewTetromino = false; 
            if (this.name == "Bonus(Clone)") {
            Rigidbody2D freeze = this.GetComponent<Rigidbody2D>();
            freeze.constraints = RigidbodyConstraints2D.FreezeAll;
            }   
        }
        if (other.gameObject.CompareTag("mur")  && canSpawnNewTetromino)
        {
            DisableMovementBlock();
            SpawnerTetromino spawnerTetromino = FindObjectOfType<SpawnerTetromino>();
            spawnerTetromino.NewTetromino();
            this.tag = "Plateforme";
            print(this.tag);
            canSpawnNewTetromino = false;  
            if (this.name == "Bonus(Clone)") {
            Rigidbody2D freeze = this.GetComponent<Rigidbody2D>();
            freeze.constraints = RigidbodyConstraints2D.FreezeAll;
            }          
        }
        } else if (bonus) {
        if (other.gameObject.CompareTag("Plateforme")  && canSpawnNewTetromino)
        {
            DisableMovementBlock();
            SpawnerTetromino spawnerTetromino = FindObjectOfType<SpawnerTetromino>();
            spawnerTetromino.BonusSpawn();
            this.tag = "Plateforme";
            print(this.tag);
            canSpawnNewTetromino = false;  
            bonus = false ; 
        }
        if (other.gameObject.CompareTag("mur")  && canSpawnNewTetromino)
        {
            DisableMovementBlock();
            SpawnerTetromino spawnerTetromino = FindObjectOfType<SpawnerTetromino>();
            spawnerTetromino.BonusSpawn();
            this.tag = "Plateforme";
            print(this.tag);
            canSpawnNewTetromino = false;
            bonus = false; 
        }
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
