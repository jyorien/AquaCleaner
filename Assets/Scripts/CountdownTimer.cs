using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    TMP_Text displayedText;
    // Start is called before the first frame update
    void Start()
    {
        displayedText = GetComponent<TMP_Text>();
        StartCoroutine(Countdown(30));
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
            //Debug.Log(counter);
            if (counter == 0)
            {
                GameManager.Instance.OnGameEnd();
            }

        }
    }
}
