using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SaveScore : MonoBehaviour
{
    public TextMeshProUGUI m_timeScore = null;

    public void Save()
    {
        float[] leaderboard = PlayerPrefsX.GetFloatArray("Leaderboard");
        float[] updatedLeaderboard = new float[leaderboard.Length + 1];
        for (int i = 0; i < leaderboard.Length; i++)
        {
            updatedLeaderboard[i] = leaderboard[i];
        }
        updatedLeaderboard[updatedLeaderboard.Length - 1] = float.Parse(m_timeScore.text);
        PlayerPrefsX.SetFloatArray("Leaderboard", updatedLeaderboard);
    }
}
