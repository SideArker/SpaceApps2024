using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spectroscopy : MonoBehaviour
{
    [SerializeField] private Transform elementsParent;
    [SerializeField] private GameObject elementPrefab;
    [SerializeField] private GameObject NoDataText;
    
    [SerializeField] private GameObject progress;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private Slider progressSlider;


    [Button]
    public void GoSpectroscopy()
    {
        LeanTween.value(progress, 0f, 1f, 3f).setEase(LeanTweenType.easeInOutSine).setOnUpdate((float val) =>
        {
            progressSlider.value = val;
            progressText.text = Mathf.RoundToInt(val * 100).ToString() + " %";
        }).setOnComplete(() => ShowSpectre());
    }

    void ShowSpectre()
    {
        Debug.Log("poka widmo");
    }
}
