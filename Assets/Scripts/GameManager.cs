using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    const string HIGH_SCORE = "HIGH_SCORE";
    int currentScore = 0;
    string PlayerName = "Johnny";

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
