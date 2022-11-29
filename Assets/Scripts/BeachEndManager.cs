using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachEndManager : MonoBehaviour
{
    [SerializeField] AudioClip EndBuzzerSound;
    AudioSource AudioPlayer;
    private static BeachEndManager _instance;
    public static BeachEndManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("BeachEndManager is null");
            }
            return _instance;
        }
    }

    void Awake()
    {
        AudioPlayer = GetComponent<AudioSource>();
        AudioPlayer.PlayOneShot(EndBuzzerSound);
        _instance = this;
    }
}
