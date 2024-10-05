using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Journal : MonoBehaviour
{
    [SerializeField] GameObject journal;
    [SerializeField] CanvasGroup uiElement;
    [SerializeField] private float journalSpeed = 0.25f;
    public bool isOpen = false;

    
    public void JournalOpen()
    {
        journal.SetActive(true);
        LeanTween.alphaCanvas(uiElement, 1f, journalSpeed).setEase(LeanTweenType.linear);
    }

    public void JournalClose()
    {
        LeanTween.alphaCanvas(uiElement, 0f, journalSpeed).setEase(LeanTweenType.linear).setOnComplete(() => journal.SetActive(false)); 

    }

}
