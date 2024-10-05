using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    [SerializeField] GameObject journal;
    [SerializeField] GameObject[] journalContent;
    [SerializeField] CanvasGroup uiElement;
    [SerializeField] private float journalSpeed = 0.25f;

    [Header("Confirmation Panel")]
    [SerializeField] TMP_Text exoPlanetName;
    [SerializeField] TMP_Text exoPlanetDescription;
    [SerializeField] GameObject exoPlanetComposition;
    [SerializeField] private Transform ImagesParent;
    [SerializeField] List<GameObject> tempImages = new List<GameObject>();

    [Header("Planet Choosing Panel")]
    [SerializeField] TMP_Text exoPlanetNameConfirm;
    [SerializeField] TMP_Text exoPlanetLookDesc;

    [SerializeField] Image[] confirmImages = new Image[3];

    public bool isOpen = false;

    public void SetValues()
    {
        DataHandler dh = DataHandler.instance;
        PlanetObject findedPlanet = dh.chosenPlanetObject;

        foreach (var planet in dh.planets)
        {
            foreach (var element in planet.elements)
            {
                //
            }
        }

        if(findedPlanet == null)
        {
            foreach (GameObject item in journalContent)
            {
                item.SetActive(false);
            }
            // return;
        } else
        {
            foreach (GameObject item in journalContent)
            {
                item.SetActive(true);
            }
            exoPlanetName.text = findedPlanet.name;
            exoPlanetDescription.text = findedPlanet.PlanetDescription;
            
            exoPlanetNameConfirm.text = findedPlanet.name;
            exoPlanetLookDesc.text = findedPlanet.PlanetLookDescription;
        }


        
        print("before");
        
        
        foreach(GameObject gameObject in tempImages)
        {
            Destroy(gameObject);
        }
        tempImages.Clear();

        
        foreach(ElementObject element in dh.chosenElements)
        {
            GameObject img = Instantiate(exoPlanetComposition, ImagesParent);
            img.GetComponent<Image>().sprite = element.Sprite;
            tempImages.Add(img);
        }

    }

    private void sketchSelect(DataHandler dh)
    {
        List<PlanetObject> tempPlanets = dh.planets;
        foreach(Image img in confirmImages)
        {
            int randomIndex = Random.Range(0, tempPlanets.Count);
            img.sprite = dh.planets[randomIndex].PlanetSprite;
            tempPlanets.RemoveAt(randomIndex);
        }
    }


    public void JournalOpen()
    {
        print("Open");
        journal.SetActive(true);
        SetValues();
        LeanTween.alphaCanvas(uiElement, 1f, journalSpeed).setEase(LeanTweenType.linear);
    }

    public void JournalClose()
    {
        LeanTween.alphaCanvas(uiElement, 0f, journalSpeed).setEase(LeanTweenType.linear).setOnComplete(() => journal.SetActive(false)); 

    }

}
