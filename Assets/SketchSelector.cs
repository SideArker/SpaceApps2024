using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SketchSelector : MonoBehaviour
{
    [SerializeField] private TMP_Text planetName;
    [SerializeField] private TMP_Text planetDescription;
    [SerializeField] private Image[] images;
    public int selectedIndex;

    private void Start()
    {
        planetName.text = DataHandler.instance.chosenPlanetObject.name;
        planetDescription.text = DataHandler.instance.chosenPlanetObject.PlanetLookDescription;

        List<PlanetObject> temp = new List<PlanetObject>();

        temp = DataHandler.instance.planets.ToList();

        temp.Remove(DataHandler.instance.chosenPlanetObject);

        foreach (var image in images)
        {
            var randomPlanet = temp[Random.Range(0, temp.Count)];
            image.sprite = randomPlanet.PlanetSprite;
            temp.Remove(randomPlanet);
        }

        selectedIndex = Random.Range(0, images.Length);
        images[selectedIndex].sprite = DataHandler.instance.chosenPlanetObject.PlanetSprite;


    }

    public void select(int id)
    {
        DataHandler.instance.isSKetchCorrect = (id == selectedIndex);
        
        print(DataHandler.instance.isSKetchCorrect);
        
        //DO SOMETHING TO SUMMARY
    }
}
