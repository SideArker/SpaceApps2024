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
    [SerializeField] private Button spectroscopyButton;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private Slider progressSlider;
    [SerializeField][TextArea(0, 20)] private string decoTextArea;
    [SerializeField] private TMP_Text decoText;
    [SerializeField] private GameObject decoPanel;

    public void GoSpectroscopy()
    {
        spectroscopyButton.interactable = false;
        NoDataText.gameObject.SetActive(false);
        progress.SetActive(true);
        StartCoroutine(LeanText());
        LeanTween.value(progress, 0f, 1f, 3f).setEase(LeanTweenType.easeInOutSine).setOnUpdate((float val) =>
        {
            progressSlider.value = val;
            progressText.text = Mathf.RoundToInt(val * 100).ToString() + " %";
        }).setOnComplete(() => StartCoroutine(ShowSpectre()));
    }

    IEnumerator ShowSpectre()
    {
        StartCoroutine(LeanText());
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

    IEnumerator LeanText()
    {
        yield return new WaitUntil(() => decoText);
        decoText.text = "";

        decoPanel.SetActive(true);

        int index = 0;
        while (index < decoTextArea.Length)
        {
            decoText.text += decoTextArea[index];
            index++;
            yield return new WaitForSeconds(2f / decoTextArea.Length);
        }
    }

}