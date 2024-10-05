using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class ElementSelector : MonoBehaviour
{
    public ElementObject element;

    [SerializeField] private Image sprite;
    [SerializeField] private TMP_Text name;
    [SerializeField] private Image spectre;

    [Button]
    public void SetData()
    {
        sprite.sprite = element.Sprite;
        name.text = element.name;
        spectre.sprite = element.Spectre;
    }

    public void toggle(bool state)
    {
        if (state)
        {
            DataHandler.instance.chosenElements.Add(element);
        }
        else
        {
            DataHandler.instance.chosenElements.Remove(element);

        }
    }
}
