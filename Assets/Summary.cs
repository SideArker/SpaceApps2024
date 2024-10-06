using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    [SerializeField] private Image planetImage;
    [SerializeField] private TMP_Text planetName;
    [SerializeField] private TMP_Text planetDesc;
    [SerializeField] private TMP_Text summaryText;

    private void Start()
    {
        planetImage.sprite = DataHandler.instance.selectedPlanet.PlanetSprite;
        planetName.text = DataHandler.instance.selectedPlanet.PlanetName;
        planetDesc.text = DataHandler.instance.selectedPlanet.PlanetDescription;

        summaryText.text =
            $"Time: {DataHandler.instance.countedTime}s\n\nYour score:\n500 - {DataHandler.instance.countedTime} = {500 - DataHandler.instance.countedTime}\ncorrect planet: {(DataHandler.instance.selectedPlanet == DataHandler.instance.chosenPlanetObject ? "x2" : "x0")}\ncorrect illustration: {(DataHandler.instance.isSKetchCorrect ? "x2" : "x1")}\n\ntotal: {DataHandler.instance.points}";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
