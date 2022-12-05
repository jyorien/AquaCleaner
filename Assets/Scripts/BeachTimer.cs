using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BeachTimer : MonoBehaviour
{
    TMP_Text displayedText;
    // Start is called before the first frame update
    void Start()
    {
        displayedText = GetComponent<TMP_Text>();
        StartCoroutine(Countdown(60));
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
            counter--;
            if (counter == 10)
            {
                BeachCleanUpManager.Instance.StartTenSecsCountdown();
            }
            if (counter >= 60)
            {
                int minutes = Mathf.FloorToInt(counter / 60);
                int secs = counter % 60;
                displayedText.text = $"Time: {minutes:D2}:{secs:D2}";
            } else
            {
                displayedText.text = $"Time: 00:{counter:D2}";
            }

            //Debug.Log(counter);
            if (counter == 0)
            {
                BeachCleanUpManager.Instance.OnBeachGameEnd();
            }
            yield return new WaitForSeconds(1);



        }
    }
}
