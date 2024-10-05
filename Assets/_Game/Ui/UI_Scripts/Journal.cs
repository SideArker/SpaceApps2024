using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Journal : MonoBehaviour
{
    [SerializeField] GameObject journal;
    [SerializeField] CanvasGroup uiElement;
    public bool isOpen = false;

    
    public void JournalOpen()
    {
        journal.SetActive(true);
        LeanTween.alphaCanvas(uiElement, 1f, 0.5f).setEase(LeanTweenType.linear);
    }

    public void JournalClose()
    {
        LeanTween.alphaCanvas(uiElement, 0f, 0.5f).setEase(LeanTweenType.linear).setOnComplete(() => journal.SetActive(false)); 

    }

}
