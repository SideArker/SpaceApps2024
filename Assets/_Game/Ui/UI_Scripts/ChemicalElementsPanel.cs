using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class ChemicalElementsPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public bool isOpen = false;
    public void ShowHidePanel()
    {
        if(!isOpen)
        {
            ShowPanel();
            isOpen = true;
        }
        else
        {
            HidePanel();
            isOpen = false;
        }
    }


    public void ShowPanel()
    {
        LeanTween.moveY(panel, new Vector2().y, 0.5f);
    }

    public void HidePanel()
    {
        LeanTween.moveY(panel, -UnityEngine.Device.Screen.height + UnityEngine.Device.Screen.height / 7f, 0.5f);
       
    }
    
}
