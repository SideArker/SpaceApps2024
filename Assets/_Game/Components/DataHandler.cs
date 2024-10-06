using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class DataHandler : MonoBehaviour
{
    public static DataHandler instance;
    [SerializeField]public int points;
    [SerializeField] int time;
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject canvas;
    [field: SerializeField]
    public PlanetObject selectedPlanet { get; private set; }

    [field: SerializeField] public PlanetObject chosenPlanetObject;
    public bool correctPlanet { get; private set; }

    public ElementObject[] elements;

    [field: SerializeField]
    public List<ElementObject> chosenElements { get; private set; } = new List<ElementObject>();

    [field: SerializeField]
    public List<PlanetObject> planets { get; private set; } = new List<PlanetObject>();

    public bool isSKetchCorrect = false;

    public int countedTime = 0;

    public GameObject summaryScreen;
    
    private void Awake()
    {
        // DontDestroyOnLoad(gameObject);

        if(instance != null) Destroy(this);
        instance = this;
    }
    // Start is called before the first frame update

    public void StartGame()
    {
        Debug.LogWarning("Starting game");

        // for (int i = 0; i < 10; i++)
        // {
        //     print(planets[Random.Range(0, planets.Count)].name);
        // }

        time = 0;

        points = 0;
        
        try
        {
            selectedPlanet = planets[Random.Range(0, planets.Count)];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        StartCoroutine(Timer());
    }

    public void ChooseObject(PlanetObject selectedPlanet)
    {
        chosenPlanetObject = selectedPlanet;
    }
    
    public void EndGame()
    {
        Debug.LogWarning("Game end");
        StopAllCoroutines();
        GetComponent<PointCounter>().AddPoints(time);
    }


    public void GetCoordinates()
    {
        mainCam.gameObject.SetActive(true);
        canvas.GetComponent<CoordinateHandler>().AfterCoordinates();
    }
    public void SetPoints(float points)
    {
        // this.points = points;
    }

    IEnumerator Timer()
    {
        time = 0;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            time++;
        }
    }

    void Start()
    {
        StartGame();
    }

    public void Finish()
    {
        summaryScreen.SetActive(true);
        countedTime = time;
        points = math.clamp(500 - time, 0, 500) * (selectedPlanet == chosenPlanetObject ? 2 : 0) * (isSKetchCorrect ? 2 : 1);
    }
    
}
