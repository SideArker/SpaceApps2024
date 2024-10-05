using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionController : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        StartCoroutine(cycle());
    }
    

    private IEnumerator cycle()
    {
        yield return new WaitUntil(() => DataHandler.instance.selectedPlanet);
        while (true)
        {
            DateTime currentTime = DateTime.Now;

            string timeString = currentTime.ToString("HH:mm:ss");
            text.text =
                $"\n2024 Oct 6 \n{timeString}\n\nLocation: \nCenter of Earth, \nStalowa Wola\n\nFace: {DataHandler.instance.selectedPlanet.StarName}\n\nField: 35.1\" x 36.5\"";
            yield return new WaitForSeconds(1);

        }
    }
}
