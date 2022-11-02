using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("player");
        GameManager.Instance.AddToScore(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
