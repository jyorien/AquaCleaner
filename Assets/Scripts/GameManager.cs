using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    string PlayerName = "Johnny";

    [SerializeField] GameObject NamePanel;
    [SerializeField] GameObject DialogPanel;
    [SerializeField] GameObject InputNamePanel;
    [SerializeField] AudioClip TalkingNoise;
    AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void PlayTalkingSound()
    {
        audioSource.PlayOneShot(TalkingNoise);
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


}
