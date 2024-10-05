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
            LeanTween.moveY(panel, new Vector2().y, 1f);
            isShown = true;
        }
        else
        {
            LeanTween.moveY(panel, -UnityEngine.Device.Screen.height / 2f, 1f);
            isShown = false;
        }
    }

    
}
