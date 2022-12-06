using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartMenuActions : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button CreditsButton;
    [SerializeField] Button CreditsCloseButton;
    [SerializeField] GameObject CreditsPopup;
    bool isCreditsShown = false;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync("WorldScene");
        });

        CreditsButton.onClick.AddListener(() =>
        {
            ChangeCreditsShownState();
        });
        CreditsCloseButton.onClick.AddListener(() => {
            ChangeCreditsShownState();
        });
    }

    void ChangeCreditsShownState()
    {
        isCreditsShown = !isCreditsShown;
        CreditsPopup.SetActive(isCreditsShown);
    }
}
