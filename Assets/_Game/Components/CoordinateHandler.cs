using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateHandler : MonoBehaviour
{
    [SerializeField] GameObject CoordinatePrefab;
    [SerializeField] GameObject CoordinateCamera;
    [SerializeField] GameObject StarScreen;
    [SerializeField] GameObject CoordinateScreen;
    [SerializeField] GameObject leftScreen;
    public void FindCoordinates()
    {
        CoordinatePrefab.SetActive(true);
        CoordinateCamera.SetActive(true);
        Camera.main.gameObject.SetActive(false);
    }

    public void AfterCoordinates()
    {
        CoordinatePrefab.SetActive(false);
        StarScreen.SetActive(true);
        CoordinateScreen.SetActive(false);
        leftScreen.SetActive(true);
    }
}
