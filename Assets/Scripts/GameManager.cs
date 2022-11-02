using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string SESSION_SCORE = "SESSION_SCORE";
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
        //PlayerPrefs.SetInt(SESSION_SCORE, currentScore);
        SceneManager.LoadScene(sceneName: "EndGameScene");

    }
    public void AddToScore(int points)
    {
        currentScore += points;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
