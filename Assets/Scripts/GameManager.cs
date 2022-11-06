using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string HIGH_SCORE = "HIGH_SCORE";
    int currentScore = 0;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is null");
            }
            return _instance;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public void OnGameEnd()
    {
        //int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        //if (currentScore > highScore)
        //{
        //    PlayerPrefs.SetInt(HIGH_SCORE, currentScore);
        //    PlayerPrefs.Save();
        //}
        //SceneManager.LoadScene(sceneName: "EndGameScene");

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
