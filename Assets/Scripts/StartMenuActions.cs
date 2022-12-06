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
    [SerializeField] AudioClip TrimClick;
    AudioSource audioSource;
    bool isCreditsShown = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartButton.onClick.AddListener(() =>
        {
            audioSource.PlayOneShot(TrimClick);
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
        audioSource.PlayOneShot(TrimClick);
        isCreditsShown = !isCreditsShown;
        CreditsPopup.SetActive(isCreditsShown);
    }
}
