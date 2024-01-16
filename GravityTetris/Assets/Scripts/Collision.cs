using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private bool canSpawnNewTetromino = true;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Plateforme") && canSpawnNewTetromino)
        {
            Debug.Log("Collided with Plateforme");
            DisableMovementBlock();
            SpawnerTetromino spawnerTetromino = FindObjectOfType<SpawnerTetromino>();
            spawnerTetromino.NewTetromino();
            this.tag = "Plateforme";
            Debug.Log("Tag changed to Plateforme");
            print(this.tag);
            canSpawnNewTetromino = false;
            
            //Invoke("ResetSpawnCondition", 0.5f);
            
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
