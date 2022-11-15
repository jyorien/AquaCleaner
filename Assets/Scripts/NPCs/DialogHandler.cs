using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class DialogHandler : MonoBehaviour
{
    const string PlayerName = "Joey";
    [SerializeField] TMP_Text NameUI;
    [SerializeField] TMP_Text DialogUI;
    [SerializeField] Button Btn;
    [SerializeField] TMP_Text BtnText;
    string _currentNPC = "";
    int _dialogIndex = 0;
    Dialog[] _currentDialogs = { };
    NPC Hermie = new NPC("Hermie", new Dialog[]{
        new Dialog("Hey bud, have you seen my best bud Sheldon? I haven't seen him in days!",true, null, null),
        new Dialog("Anyways, ain't it seem like the shells here been lookin' weird lately?",true, null, null),
        new Dialog("They've all been lookin' so grey and ugly. Look at my shell!" ,true, null, null),
        new Dialog("Any idea what's happened?" ,true, null, null),
        new Dialog("(All that trash has caused the hermit crabs to mistake trash for new homes)", false, null, null),
         new Dialog("(I should probably clean the beach)", false, "Accept", () => { SceneManager.LoadScene(sceneName: "BeachCleanUpScene"); })
    }
        );

    NPC Toddie = new NPC("Toddie", new Dialog[]{
        new Dialog("H-Hey... Don't you think the ocean's b-been weird recently?",true, null, null),
        new Dialog("I-I've been seeing more jellyfishes i-in the ocean... but my stomach has also been feeling bad lately...",true, null, null),
        new Dialog("D-Do you think the jellyfishes h-have gone bad?",true, null, null),
        new Dialog("(The plastics in the ocean have caused turtles to mistake the plastics for food)",false, null, null),
        new Dialog("(I should probably collect the trash in the ocean)",false, "Accept", () => { SceneManager.LoadScene(sceneName: "GameScene"); }),
    }
    );

    NPC MsGaia = new NPC("Ms Gaia", new Dialog[]{
        new Dialog($"Hey, {PlayerName}! Today, the Environment Club decided to clean the beach.", true, null, null),
        new Dialog($"The beach has been looking bad recently.. the creatures here don't look well.", true, null, null),
        new Dialog($"I wonder if there's a way to help them?", true, "End", () => { GameManager.Instance.OpenDialog(false); }),
    }
);


    private void OnMouseDown()
    {
        Debug.Log("on mouse down");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2);
        foreach (Collider2D collider in colliders)
        {
            Debug.Log(collider.name);
            if (collider.name == "Player")
            {
                Debug.Log($"NPC Name: {gameObject.name}");
                StartDialog();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 2);
    }

    private void StartDialog()
    {

        GameManager.Instance.OpenDialog(true);
        // reset index
        _dialogIndex = 0;
        BtnText.text = "Next";
        Btn.onClick.RemoveAllListeners();

        switch (gameObject.name)
        {
            case "Hermie":
                _currentNPC = "Hermie";

                _currentDialogs = Hermie.Dialogs;
                UpdateDialog();
                Btn.onClick.AddListener(() => {
                    UpdateDialog();
                });
                break;
            case "Toddie":
                _currentNPC = "Toddie";

                _currentDialogs = Toddie.Dialogs;
                UpdateDialog();
                Btn.onClick.AddListener(() => {
                    UpdateDialog();
                });
                break;
            case "Ms Gaia":
                _currentNPC = "Ms Gaia";

                _currentDialogs = MsGaia.Dialogs;
                UpdateDialog();
                Btn.onClick.AddListener(() => {
                    UpdateDialog();
                });
                break;
            default:
                break;
        }
    }

    void UpdateDialog()
    {
        Dialog dialog = _currentDialogs[_dialogIndex];
        NameUI.text = dialog._isNPC ? _currentNPC : PlayerName;
        DialogUI.text = dialog._text;
        
        _dialogIndex += 1;
        if (_dialogIndex == _currentDialogs.Length)
        {
            BtnText.text = dialog._buttonName;
            Btn.onClick.RemoveAllListeners();
            Btn.onClick.AddListener(() =>
            {
                dialog._buttonAction.Invoke();
            });
            return;
        }
    }
}
