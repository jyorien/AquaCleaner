using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndDisplay : MonoBehaviour
{
    const string HIGH_SCORE = "HIGH_SCORE";

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        scoreText.text = $"Total Score: {GameManager.Instance.GetCurrentScore()}";
        highScoreText.text = $"High Score: {highScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
