using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class WinCondition : MonoBehaviour
{
    public static bool gameover = false;
    public static bool win = false;
    public GameObject menuButton = null;

    public GameObject MainDoor = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            menuButton.SetActive(true);
            gameover = true;
            Time.timeScale = 0.0f;
            Debug.Log("hey condition is: " + gameover);
        }
    }
    private void Update()
    {
        if(PlayerController.amtOfEnemy <= 0)
        {
            MainDoor.GetComponent<TilemapCollider2D>().enabled = false;
        }
    }
}
