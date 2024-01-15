using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.position += new Vector3(-1, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            transform.position += new Vector3(1, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
        }

        if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime)){
            transform.position += new Vector3(0,-1,0);
            previousTime = Time.time;
        }
        }
    }

