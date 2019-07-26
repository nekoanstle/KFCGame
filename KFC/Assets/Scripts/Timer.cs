using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float totalTime = 0;
    TextMeshProUGUI text; 
    // Start is called before the first frame update
    void Start()
    {
        totalTime = 0;
        WinCondition.gameover = false; 
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WinCondition.gameover != true)
        {
            totalTime += Time.deltaTime;
            text.text = totalTime.ToString("00.00"); 
        }
    }
}
