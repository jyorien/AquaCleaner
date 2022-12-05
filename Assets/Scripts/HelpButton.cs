using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class HelpButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject InstructionsMenu;
    bool isDisplayed = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        InstructionsMenu.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InstructionsMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        InstructionsMenu.SetActive(false);

    }

   
}
