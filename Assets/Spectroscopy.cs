using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Spectroscopy : MonoBehaviour
{
    [SerializeField] private Transform elementsParent;
    [SerializeField] private GameObject elementPrefab;
    [SerializeField] private GameObject NoDataText;
    
    [SerializeField] private GameObject progress;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private Slider progressSlider;

    public void GoSpectroscopy()
    {
        
    }

    IEnumerator Progress()
    {
        yield return new WaitForSeconds(3);
    }
}
