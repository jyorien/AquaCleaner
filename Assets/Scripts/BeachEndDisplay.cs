using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class BeachEndDisplay : MonoBehaviour
{
    const string HIGH_SCORE = "BEACH_HIGH_SCORE";

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] Button RetryButton;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        scoreText.text = $"Total Score: {GameManager.Instance.GetBeachScore()}";
        highScoreText.text = $"High Score: {highScore}";
        RetryButton.onClick.AddListener(() => { SceneManager.LoadScene(sceneName: "BeachCleanUpScene"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
