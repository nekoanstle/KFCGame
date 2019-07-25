using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public static bool gameover = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameover = true;
            Debug.Log("hey condition is: " + gameover);
        }
    }
}
