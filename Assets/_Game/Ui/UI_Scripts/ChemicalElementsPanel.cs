using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class ChemicalElementsPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void ShowPanel()
    {
        LeanTween.moveY(panel, new Vector2().y, 1f);
    }

    public void HidePanel()
    {
        LeanTween.moveY(panel, -UnityEngine.Device.Screen.height / 2f, 1f);
    }
    
}
