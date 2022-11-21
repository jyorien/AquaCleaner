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
    [SerializeField] Button BackButton;
    [SerializeField] TMP_Text DialogUI;
    [SerializeField] Button Btn;
    [SerializeField] TMP_Text BtnText;
    [SerializeField] GameObject NamePanel;
    [SerializeField] GameObject DialogPanel;
    [SerializeField] GameObject BeachPollutionPics;
    [SerializeField] GameObject PlasticAnimalPics;
    [SerializeField] GameObject ActionablePanel;
    string[] Dialogs;
    int DialogIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        scoreText.text = $"Total Score: {GameManager.Instance.GetBeachScore()}";
        highScoreText.text = $"High Score: {highScore}";
        BackButton.onClick.AddListener(() => { SceneManager.LoadScene(sceneName: "WorldScene"); });

        Dialogs = new string[] {
            $"Wow, {GameManager.Instance.GetPlayerName()}! You helped clean the beach!",
            "Thanks bud, my friends and I appreciate your efforts.",
            $"Hey {GameManager.Instance.GetPlayerName()}, did you know? plastic is found on the shorelines of every continent, especially at popular tourist destinations and densely populated areas.",
            "Beach pollution has been estimated to affect over 800 wildlife species around the globe.",
            "In fact, more than 100,000 of my friends, including other creatures, die each year after ingesting plastic or getting entangled in it!",
            "Hermit crabs like myself mistake trash for shells and get trapped to death. Some of my friends inhabit these trash that do not provide proper protection for us.",
            "The plastic ingested by my friends travels up the food chain and eventually reaches human stomachs when they consume seafood.",
            "There are many other problems related to beach pollution, including a health risk for people who come in contact with dirty water or sand.",
            "We can all play a part by educating ourselves on the issue of pollution on beaches and taking steps to address the problems."
        };
        UpdateDialog();
        Btn.onClick.AddListener(() => { UpdateDialog(); });
    }

    void UpdateDialog()
    {

        string currentDialog = Dialogs[DialogIndex];
        DialogUI.text = currentDialog;
        switch (DialogIndex)
        {
            case 2:
                BeachPollutionPics.SetActive(true);
                PlasticAnimalPics.SetActive(false);
                break;
            case 4:
                BeachPollutionPics.SetActive(false);
                PlasticAnimalPics.SetActive(true);
                break;
            case 8:
                Btn.onClick.RemoveAllListeners();
                Btn.onClick.AddListener(() => { DisplayActionables(); });
                break;

            default:
                //BeachPollutionPics.SetActive(false);
                //PlasticAnimalPics.SetActive(false);
                break;
        }
        DialogIndex += 1;
    }
    void DisplayActionables()
    {
        BeachPollutionPics.SetActive(false);
        PlasticAnimalPics.SetActive(false);
        NamePanel.SetActive(false);
        DialogPanel.SetActive(false);
        ActionablePanel.SetActive(true);
    }
}
