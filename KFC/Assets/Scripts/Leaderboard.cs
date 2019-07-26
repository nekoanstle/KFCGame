using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI m_leaderboard = null;

    private void Start()
    {
        float[] leaderboard = PlayerPrefsX.GetFloatArray("Leaderboard");
        foreach (float f in leaderboard)
        {
            m_leaderboard.text += f.ToString("00.00\n");
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            float[] leaderboard = PlayerPrefsX.GetFloatArray("Leaderboard");
            float[] updatedLeaderboard = new float[leaderboard.Length + 1];
            for (int i = 0; i < leaderboard.Length; i++)
            {
                updatedLeaderboard[i] = leaderboard[i];
            }
            updatedLeaderboard[updatedLeaderboard.Length - 1] = 10.00f;
            PlayerPrefsX.SetFloatArray("Leaderboard", updatedLeaderboard);
            m_leaderboard.text = "";
            foreach (float f in updatedLeaderboard)
            {
                m_leaderboard.text += f.ToString("00.00\n");
            }
        }

        if(Input.GetButtonDown("Reload"))
        {
            float[] reset = new float[0];
            PlayerPrefsX.SetFloatArray("Leaderboard", reset);
            m_leaderboard.text = "";
        }
    }
}
