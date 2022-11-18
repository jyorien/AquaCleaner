using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    const string HIGH_SCORE = "HIGH_SCORE";
    const string BEACH_HIGH_SCORE = "BEACH_HIGH_SCORE";

    int currentScore = 0;
    int beachScore = 0;
    string PlayerName = "Johnny";
    [SerializeField] TMP_Text NewlyAddedScoreText;
    AudioSource AudioPlayer;
    [SerializeField] AudioClip SuccessSound;
    [SerializeField] AudioClip FailureSound;

    [SerializeField] GameObject NamePanel;
    [SerializeField] GameObject DialogPanel;
    [SerializeField] GameObject InputNamePanel;

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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public void OpenNameInput(bool isOpen)
    {
        InputNamePanel.SetActive(isOpen);
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public string GetPlayerName()
    {
        return PlayerName;
    }

    public void OpenDialog(bool isOpen)
    {
        NamePanel.SetActive(isOpen);
        DialogPanel.SetActive(isOpen);
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
        int highScore = PlayerPrefs.GetInt(BEACH_HIGH_SCORE, 0);
        if (beachScore > highScore)
        {
            PlayerPrefs.SetInt(BEACH_HIGH_SCORE, beachScore);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(sceneName: "BeachEndScene");
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
