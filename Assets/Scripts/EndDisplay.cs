using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.Instance.GetCurrentScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
