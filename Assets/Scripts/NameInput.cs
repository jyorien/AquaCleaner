using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NameInput : MonoBehaviour
{
    const string HAS_PLAYED = "IS_FIRST";
    const string PLAYER_NAME = "PLAYER_NAME";
    const string COORD_X = "COORD_X";
    const string COORD_Y = "COORD_Y";
    [SerializeField] Button ConfirmButton;
    [SerializeField] TMP_InputField NameInputField;
    [SerializeField] BeachPlayer PlayerScript;
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        int hasPlayed = PlayerPrefs.GetInt(HAS_PLAYED, 0);
        GameManager.Instance.OpenDialog(false);
        NameInputField.contentType = TMP_InputField.ContentType.Name;
        if (hasPlayed == 0)
        {
            ConfirmButton.onClick.AddListener(() =>
            {
                GameManager.Instance.SetPlayerName(NameInputField.text);
                GameManager.Instance.OpenNameInput(false);
                PlayerScript.enabled = true;
                PlayerPrefs.SetInt(HAS_PLAYED, 1);
                PlayerPrefs.SetString(PLAYER_NAME, NameInputField.text);
                GameManager.Instance.PlayButtonClickSound();
            });
        }
        else
        {
            string name = PlayerPrefs.GetString(PLAYER_NAME, "Johnny");
            float coordX = PlayerPrefs.GetFloat(COORD_X, -0.91f);
            float coordY = PlayerPrefs.GetFloat(COORD_Y, -2.69f);
            Debug.Log($"{coordX} {coordY}");
            Player.transform.position = new Vector3(coordX, coordY, 0);
            GameManager.Instance.SetPlayerName(name);
            GameManager.Instance.OpenNameInput(false);
            PlayerScript.enabled = true;
        }

            
    }

}
