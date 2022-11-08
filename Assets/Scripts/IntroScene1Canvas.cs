using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroScene1Canvas : MonoBehaviour
{
    [SerializeField] TMP_Text TextField;
    [SerializeField] Button NextButton;
    [SerializeField] Button YesButton;
    [SerializeField] Button NoButton;

    int counter = 0;
    string[] TextLines = { "Hey Joey! I'm Professor Green. Do you know about plastic pollution?", "Well, today I will bring you on a journey to learn about plastic pollution in the ocean." };
    // Start is called before the first frame update
    void Start()
    {
        
        TextField.text = TextLines[counter];
        NextButton.onClick.AddListener(() => {
            counter += 1;
            TextField.text = TextLines[counter];

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleYesNoButtons()
    {

    }
}
