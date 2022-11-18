using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NameInput : MonoBehaviour
{
    [SerializeField] Button ConfirmButton;
    [SerializeField] TMP_InputField NameInputField;
    [SerializeField] BeachPlayer PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OpenDialog(false);

        ConfirmButton.onClick.AddListener(() =>
        {
            GameManager.Instance.SetPlayerName(NameInputField.text);
            GameManager.Instance.OpenNameInput(false);
            PlayerScript.enabled = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
