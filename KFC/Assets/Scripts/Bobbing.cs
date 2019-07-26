using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float amplitude;          //Set in Inspector 
    public float speed;              //Set in Inspector 
    private float tempVal;
    private Vector3 tempPos;

    void Start()
    {
        tempVal = transform.position.y;
    }

    void Update()
    {
        tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = new Vector3(Screen.width/2, tempPos.y);
    }
}
