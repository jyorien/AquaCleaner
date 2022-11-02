using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    TMP_Text displayedText;
    // Start is called before the first frame update
    void Start()
    {
        displayedText = GetComponent<TMP_Text>();
        Debug.Log("hello");
        StartCoroutine(Countdown(10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            displayedText.text = $"00:{counter:D2}";
            Debug.Log(counter);
            if (counter == 0)
            {
                SceneManager.LoadScene(sceneName: "EndGameScene");
            }

        }
    }
}
