using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject m_startButton = null;
    [SerializeField] GameObject m_LeaderboardButton = null;
    [SerializeField] GameObject m_Leaderboard = null;

    public void Play()
    {
        SceneManager.LoadScene("TempMain");
    }

    public void Leaderboard()
    {
        m_startButton.SetActive(!m_startButton.activeSelf);
        m_LeaderboardButton.SetActive(!m_LeaderboardButton.activeSelf);
        m_Leaderboard.SetActive(!m_Leaderboard.activeSelf);
    }
}
