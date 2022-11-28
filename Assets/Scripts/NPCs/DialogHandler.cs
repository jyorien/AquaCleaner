using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class DialogHandler : MonoBehaviour
{
    const string COORD_X = "COORD_X";
    const string COORD_Y = "COORD_Y";
    [SerializeField] TMP_Text NameUI;
    [SerializeField] TMP_Text DialogUI;
    [SerializeField] Button Btn;
    [SerializeField] TMP_Text BtnText;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject HermieNKey;
    [SerializeField] GameObject ToddieNKey;
    [SerializeField] GameObject GaiaNKey;
    [SerializeField] GameObject ClassmateNKey;
    string _currentNPC = "";
    int _dialogIndex = 0;
    bool isTalking = false;
    Dialog[] _currentDialogs = { };

    private void Update()
    {
        string currentNearbyNPC = "";

        Collider2D[] npcCollider = Physics2D.OverlapCircleAll(transform.position, 1);
        List<string> colliderNameList = npcCollider.Select(item => item.name).ToList();

        string npcName = gameObject.name;
        if (colliderNameList.Contains("Player"))
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                isTalking = true;
                StartDialog();
            }
            currentNearbyNPC = npcName;
            switch (npcName)
            {
                case "Hermie":
                    HermieNKey.SetActive(true);
                    break;
                case "Toddie":
                    ToddieNKey.SetActive(true);
                    break;
                case "Ms Gaia":
                    GaiaNKey.SetActive(true);
                    break;
                case "Classmate":
                    ClassmateNKey.SetActive(true);
                    break;
                default:
                    break;
            }
        } else
        {
            if (isTalking)
            {
                isTalking = !isTalking;
                GameManager.Instance.OpenDialog(false);
            }

            currentNearbyNPC = npcName;
            switch (npcName)
            {
                case "Hermie":
                    HermieNKey.SetActive(false);
                    break;
                case "Toddie":
                    ToddieNKey.SetActive(false);
                    break;
                case "Ms Gaia":
                    GaiaNKey.SetActive(false);
                    break;
                case "Classmate":
                    ClassmateNKey.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 1);
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
                NPC Hermie = CreateHermie();
                _currentDialogs = Hermie.Dialogs;
                UpdateDialog();
                Btn.onClick.AddListener(() => {
                    UpdateDialog();
                });
                break;
            case "Toddie":
                _currentNPC = "Toddie";
                NPC Toddie = CreateToddie();
                _currentDialogs = Toddie.Dialogs;
                UpdateDialog();
                Btn.onClick.AddListener(() => {
                    UpdateDialog();
                });
                break;
            case "Ms Gaia":
                _currentNPC = "Ms Gaia";
                NPC MsGaia = CreateMsGaia();
                _currentDialogs = MsGaia.Dialogs;
                UpdateDialog();
                Btn.onClick.AddListener(() => {
                    UpdateDialog();
                });
                break;
            case "Classmate":
                _currentNPC = "Classmate";
                NPC Classmate = CreateClassmate();
                _currentDialogs = Classmate.Dialogs;
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
        Btn.gameObject.SetActive(false);
        Dialog dialog = _currentDialogs[_dialogIndex];
        NameUI.text = dialog._isNPC ? _currentNPC : GameManager.Instance.GetPlayerName();
        DialogUI.text = dialog._text;
        StopCoroutine("ShowTypewriterEffect");
        new WaitForSeconds(1f);
        StartCoroutine(ShowTypewriterEffect(dialog._text));
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

    IEnumerator ShowTypewriterEffect(string textToDisplay)
    {
        int totalVisibleChars = textToDisplay.Count();
        int counter = 0;
        while (counter < totalVisibleChars + 1)
        {
            counter += 3;
            DialogUI.maxVisibleCharacters = counter;
            yield return new WaitForSeconds(0.01f);
        }
        Btn.gameObject.SetActive(true);


    }

    // NPCS
    NPC CreateHermie()
    {
        return new NPC("Hermie", new Dialog[]{
        new Dialog("(Pssstt..)",true, null, null),
        new Dialog("Huh?", false, null, null),
        new Dialog("(Psstt...) Over here, bud!", true, null ,null),
        new Dialog("Hey bud, have you seen my best bud Sheldon? I haven't seen him in days!",true, null, null),
        new Dialog("Anyways, ain't it seem like the shells here been lookin' weird lately?",true, null, null),
        new Dialog("They've all been lookin' so grey and ugly. Look at my shell!" ,true, null, null),
        new Dialog("Any idea what's happened?" ,true, null, null),
        //new Dialog("(All that trash has caused the hermit crabs to mistake trash for new homes)", false, null, null),
         new Dialog("(I should probably clean the beach)", false, "Accept", () => {
             StartMinigame("BeachCleanUpScene");
         })
    }
        );
    }
    NPC CreateToddie()
    {
        return new NPC("Toddie", new Dialog[]{
        new Dialog("H-Hey... Don't you think the ocean's b-been weird recently?",true, null, null),
        new Dialog("I-I've been seeing more jellyfishes i-in the ocean... but my stomach has also been feeling bad lately...",true, null, null),
        new Dialog("D-Do you think the jellyfishes h-have gone bad?",true, null, null),
        //new Dialog("(The plastics in the ocean have caused turtles to mistake the plastics for food)",false, null, null),
        new Dialog("(I should probably collect the trash in the ocean)",false, "Accept", () => {
            StartMinigame("GameScene");
        }),
    }
    );
    }
    NPC CreateMsGaia()
    {
        return new NPC("Ms Gaia", new Dialog[]{
        new Dialog($"Hey, {GameManager.Instance.GetPlayerName()}! Today, the Environment Club decided to clean the beach.", true, null, null),
        new Dialog($"The beach has been looking bad recently.. the creatures here don't look well.", true, null, null),
        new Dialog($"I wonder if there's a way to help them?", true, "End", () => { GameManager.Instance.OpenDialog(false); }),
    }
);
    }
    NPC CreateClassmate()
    {
        return new NPC("Classmate", new Dialog[]
    {
        new Dialog($"Heya, {GameManager.Instance.GetPlayerName()}! Don't you just love the smell of the beach~?", true, null, null),
        new Dialog("When I'm sad, I sit by the waters and it magically makes me feel better~", true, null, null),
        new Dialog("Don't you think it would be a shame if all we saw was floating trash in the future?", true, null, null),
        new Dialog("Every year, roughly 8 million tons of plastic enters our oceans.", true, null, null),
        new Dialog("I joined the Environmental Club because I wanted to make a difference~", true, "End", () => { GameManager.Instance.OpenDialog(false); }),
    });
    }

    void SavePosition()
    {
       PlayerPrefs.SetFloat(COORD_X, Player.transform.position.x);
       PlayerPrefs.SetFloat(COORD_Y, Player.transform.position.y);
    }

    void StartMinigame(string sceneName)
    {
        SavePosition();
        GameManager.Instance.StopBGM();
        SceneManager.LoadScene(sceneName: sceneName);
    }
}
