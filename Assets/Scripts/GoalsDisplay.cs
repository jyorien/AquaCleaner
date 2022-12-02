using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GoalsDisplay : MonoBehaviour
{
    const string IS_TALKED_GAIA = "IS_TALKED_GAIA";
    const string IS_TALKED_CLASSMATE = "IS_TALKED_CLASSMATE";
    const string OCEAN_HIGH_SCORE = "HIGH_SCORE";
    const string BEACH_HIGH_SCORE = "BEACH_HIGH_SCORE";
    Color32 CompletedColor = new Color32(90, 248, 71, 255);
    Color32 WhiteColor =  new Color32(255, 255, 255, 255);
    [SerializeField] TMP_Text GaiaTextField;
    [SerializeField] TMP_Text ClassmateTextField;
    [SerializeField] TMP_Text OceanHighScoreTextField;
    [SerializeField] TMP_Text BeachHighScoreTextField;

    private static GoalsDisplay _instance;
    public static GoalsDisplay Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GoalsDisplay is null");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGoals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GetGaiaTalked()
    {
        return PlayerPrefs.GetInt(IS_TALKED_GAIA, 0);
    }

    int GetClassmateTalked()
    {
        return PlayerPrefs.GetInt(IS_TALKED_CLASSMATE, 0);
    }

    string GetBeachHighScore()
    {
        int score = PlayerPrefs.GetInt(BEACH_HIGH_SCORE, 0);
        if (score == 0)
        {
            return "0000";
        }
        else
        {
            return score.ToString().PadLeft(4, '0');
        }
    }

    string GetOceanHighScore()
    {
        int score = PlayerPrefs.GetInt(OCEAN_HIGH_SCORE, 0);
        if (score == 0)
        {
            return "0000";
        }
        else
        {
            return score.ToString().PadLeft(4, '0');
        }
    }

    public void UpdateGoals()
    {
        if (GetGaiaTalked() == 0)
        {
            GaiaTextField.color = WhiteColor;
            GaiaTextField.text = "Talk to Ms Gaia: 0/1";
        } else
        {
            GaiaTextField.color = CompletedColor;
            GaiaTextField.text = "Talk to Ms Gaia: 1/1";
        }

        if (GetClassmateTalked() == 0)
        {
            ClassmateTextField.color = WhiteColor;
            ClassmateTextField.text = "Talk to Classmate: 0/1";
        } else
        {
            ClassmateTextField.color = CompletedColor;
            ClassmateTextField.text = "Talk to Classmate: 1/1";
        }
        OceanHighScoreTextField.text = $"Ocean Clean Up High Score: {GetOceanHighScore()}";
        BeachHighScoreTextField.text = $"Beach Clean Up High Score: {GetBeachHighScore()}";
    }
}
