using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BeachCleanUpManager : MonoBehaviour
{
    const string BEACH_HIGH_SCORE = "BEACH_HIGH_SCORE";
    int beachScore = 0;
    AudioSource AudioPlayer;
    [SerializeField] TMP_Text NewlyAddedScoreText;
    [SerializeField] AudioClip SuccessSound;
    [SerializeField] AudioClip FailureSound;

    private static BeachCleanUpManager _instance;
    public static BeachCleanUpManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("BeachCleanUpManager is null");
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
        }
        else
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

}
