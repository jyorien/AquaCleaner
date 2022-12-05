using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HelpButton : MonoBehaviour
{
    [SerializeField] GameObject InstructionsMenu;
    bool isDisplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        InstructionsMenu.SetActive(false);
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => {
            isDisplayed = !isDisplayed;
            if (isDisplayed)
            {
                InstructionsMenu.SetActive(true);
            } else
            {
                InstructionsMenu.SetActive(false);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
