using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OceanGameManager : MonoBehaviour
{
    const string HIGH_SCORE = "HIGH_SCORE";
    int currentScore = 0;

    private static OceanGameManager _instance;
    public static OceanGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("OceanGameManager is null");
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public void OnGameEnd()
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, currentScore);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(sceneName: "EndGameScene");

    }

    public void AddToScore(int points)
    {
        currentScore += points;
    }

    public void UpdateScore(int points)
    {
        currentScore = points;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
