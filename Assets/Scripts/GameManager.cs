using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    const string HIGH_SCORE = "HIGH_SCORE";
    int currentScore = 0;
    int beachScore = 0;
    [SerializeField] TMP_Text NewlyAddedScoreText;
    AudioSource AudioPlayer;
    [SerializeField] AudioClip SuccessSound;
    [SerializeField] AudioClip FailureSound;

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
        AudioPlayer = GetComponent<AudioSource>();
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
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, currentScore);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(sceneName: "EndGameScene");

    }

    public void OnBeachGameEnd()
    {
        Debug.Log("Game end");
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

    public void AddToBeachScore()
    {
        beachScore += 1;
        NewlyAddedScoreText.text = "+1";
        NewlyAddedScoreText.color = new Color32(134, 255, 137, 255);
        AudioPlayer.clip = SuccessSound;
        AudioPlayer.Play();
    }

    public void DeductFromBeachScore()
    {
        var updatedScore = beachScore - 2;
        if (updatedScore < 0)
        {
            beachScore = 0;
        } else
        {
            beachScore -= 2;
        }
        NewlyAddedScoreText.text = "-2";
        NewlyAddedScoreText.color = new Color32(255, 57, 111, 255);
        AudioPlayer.clip = FailureSound;
        AudioPlayer.Play();
    }

    public int GetBeachScore()
    {
        return beachScore;
    }
}
