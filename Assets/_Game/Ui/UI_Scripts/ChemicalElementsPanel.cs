using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class ChemicalElementsPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public bool isShown = false;
    
    public void ShowHidePanel()
    {
        if(!isShown)
        {
            LeanTween.moveY(panel, UnityEngine.Screen.height / 10, 1f);
            isShown = true;
        }
        else
        {
            LeanTween.moveY(panel, -UnityEngine.Screen.height / 4.5f, 1f);
            isShown = false;
        }
    }

    
}
