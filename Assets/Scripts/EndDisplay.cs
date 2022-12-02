using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class EndDisplay : MonoBehaviour
{
    const string HIGH_SCORE = "HIGH_SCORE";

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] Button BackButton;
    [SerializeField] TMP_Text DialogUI;
    [SerializeField] Button Btn;
    [SerializeField] TMP_Text BtnText;
    [SerializeField] GameObject DialogPanel;
    [SerializeField] GameObject GreatPacificGP;
    [SerializeField] GameObject WhaleNet;
    [SerializeField] GameObject PlasticTurtle;
    [SerializeField] GameObject ActionablePanel;
    string[] Dialogs;
    int DialogIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        scoreText.text = $"Total Score: {OceanGameManager.Instance.GetCurrentScore()}";
        highScoreText.text = $"High Score: {highScore}";

        BackButton.onClick.AddListener(() => {
            BeachEndManager.Instance.PlayButtonClickSound();
            SceneManager.LoadScene(sceneName: "WorldScene"); });

        Dialogs = new string[] {
            $"T-thanks for collecting some of the t-trash, {GameManager.Instance.GetPlayerName()}!",
            "I r-really appreciate you t-trying to help clean the ocean.",
            "H-however, it doesn’t stop here.",
            $"Did y-you know, {GameManager.Instance.GetPlayerName()}? The trash in the ocean have been harming my friends and me really badly.",
            "..Sea turtles like m-myself and my whale friends have b-been found entangled in fishing nets.",
            "At this rate, there m-may be more trash t-than fishes in the sea by 2050.",
            "Plastics in o-oceans affect the e-environment too.",
            "The microplastics in the water a-affect many marine micro-organisms’ ability t-to photosynthesise.",
            "Without them, our oceans’ carbon sink b-becomes less effective.",
            "T-the best time to start helping the ocean was 50 years ago...",
            "b-but the second best time is today!",
            "W-we can all play a part by educating o-ourselves on this issue and take small steps to address the problems."
        };
        UpdateDialog();
        Btn.onClick.AddListener(() => {
            BeachEndManager.Instance.PlayButtonClickSound();
            UpdateDialog(); });
    }

    void UpdateDialog()
    {
        Btn.gameObject.SetActive(false);
        string currentDialog = Dialogs[DialogIndex];
        DialogUI.text = currentDialog;
        switch (DialogIndex)
        {
            case 3:
                GreatPacificGP.SetActive(true);
                WhaleNet.SetActive(false);
                PlasticTurtle.SetActive(false);
                break;
            case 4:
                GreatPacificGP.SetActive(false);
                WhaleNet.SetActive(true);
                PlasticTurtle.SetActive(true);
                break;
            case 11:
                Btn.onClick.RemoveAllListeners();
                Btn.onClick.AddListener(() => { DisplayActionables(); });
                break;

            default:
                break;
        }
        DialogIndex += 1;
        StopCoroutine("ShowTypewriterEffect");
        new WaitForSeconds(1f);
        StartCoroutine(ShowTypewriterEffect(currentDialog));
    }
    void DisplayActionables()
    {
        GreatPacificGP.SetActive(false);
        WhaleNet.SetActive(false);
        PlasticTurtle.SetActive(false);
        DialogPanel.SetActive(false);
        ActionablePanel.SetActive(true);
    }

    IEnumerator ShowTypewriterEffect(string textToDisplay)
    {
        int totalVisibleChars = textToDisplay.Count();
        int counter = 0;
        while (counter < totalVisibleChars + 1)
        {
            counter += 3;
            if (counter % 5 == 0)
            {
                GameManager.Instance.PlayTalkingSound();
            }
            DialogUI.maxVisibleCharacters = counter;
            yield return new WaitForSeconds(0.01f);
        }
        Btn.gameObject.SetActive(true);

    }
}
