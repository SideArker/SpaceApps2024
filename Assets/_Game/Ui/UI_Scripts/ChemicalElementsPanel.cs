using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Device;

public class ChemicalElementsPanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] private GameObject closingTarget;
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
        panel.transform.LeanMoveLocalY(-500f, .5f).setOnComplete(() => closingTarget.SetActive(true));
    }

    public void HidePanel()
    {
        closingTarget.SetActive(false);
        panel.transform.LeanMoveLocalY(-1490f, .5f);
       
    }
    
}
