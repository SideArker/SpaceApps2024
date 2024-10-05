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
    [SerializeField] private Button spectroscopyButton;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private Slider progressSlider;

    public void GoSpectroscopy()
    {
        spectroscopyButton.interactable = false;
        NoDataText.gameObject.SetActive(false);
        progress.SetActive(true);
        LeanTween.value(progress, 0f, 1f, 3f).setEase(LeanTweenType.easeInOutSine).setOnUpdate((float val) =>
        {
            progressSlider.value = val;
            progressText.text = Mathf.RoundToInt(val * 100).ToString() + " %";
        }).setOnComplete(() => StartCoroutine(ShowSpectre()));
    }

    IEnumerator ShowSpectre()
    {
        yield return new WaitForSeconds(0.2f);
        progress.SetActive(false);
        // Debug.Log("poka widmo");
        elementsParent.gameObject.SetActive(true);
        foreach (var element in DataHandler.instance.selectedPlanet.elements)
        {
            print(element.ElementName);
            Image obj = Instantiate(elementPrefab, elementsParent).GetComponent<Image>();
            obj.sprite = element.Spectre;
        }
    }
}
