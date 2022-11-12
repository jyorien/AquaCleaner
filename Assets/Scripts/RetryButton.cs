using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RetryButton : MonoBehaviour
{
    Button retryButton;

    // Start is called before the first frame update
    void Start()
    {
        retryButton = GetComponent<Button>();
        retryButton.onClick.AddListener(() => { SceneManager.LoadScene(sceneName: "WorldScene"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
