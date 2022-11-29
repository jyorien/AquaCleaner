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
        StartCoroutine(Countdown(60));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown(int seconds)
    {
        //int counter = seconds;
        //while (counter > 0)
        //{
        //    yield return new WaitForSeconds(1);
        //    counter--;
        //    displayedText.text = $"00:{counter:D2}";
        //    if (counter == 10)
        //    {
        //        OceanGameManager.Instance.StartTenSecsCountdown();
        //    }
        //    //Debug.Log(counter);
        //    if (counter == 0)
        //    {
        //    }

        //}

        int counter = seconds;
        while (counter > 0)
        {
            counter--;
            if (counter == 10)
            {
                OceanGameManager.Instance.StartTenSecsCountdown();
            }
            if (counter >= 60)
            {
                int minutes = Mathf.FloorToInt(counter / 60);
                int secs = counter % 60;
                displayedText.text = $"{minutes:D2}:{secs:D2}";
            }
            else
            {
                displayedText.text = $"00:{counter:D2}";
            }
            if (counter == 0)
            {
                OceanGameManager.Instance.OnGameEnd();

            }
            yield return new WaitForSeconds(1);
        }
    }
}
