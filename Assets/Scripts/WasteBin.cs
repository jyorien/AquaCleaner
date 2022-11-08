using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WasteBin : MonoBehaviour
{
    [SerializeField] TMP_Text BeachScoreText;

    // Update is called once per frame
    void Update()
    {
        BeachScoreText.text = $"{GameManager.Instance.GetBeachScore():D4}";
    }
}
