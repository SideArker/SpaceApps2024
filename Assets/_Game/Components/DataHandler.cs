using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DataHandler : MonoBehaviour
{
    public static DataHandler instance;
    [SerializeField] float points;
    [SerializeField] float time;
    [field: SerializeField]
    public PlanetObject selectedPlanet { get; private set; }
    [field: SerializeField]
    public PlanetObject chosenPlanetObject { get; private set; }
    public bool correctPlanet { get; private set; }

    public ElementObject[] elements;

    [field: SerializeField]
    public List<ElementObject> chosenElements { get; private set; } = new List<ElementObject>();

    [field: SerializeField]
    public List<PlanetObject> planets { get; private set; } = new List<PlanetObject>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(instance != null) Destroy(this);
        instance = this;
    }
    // Start is called before the first frame update

    public void StartGame()
    {
        Debug.LogWarning("Starting game");
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

    public void SetPoints(float points)
    {
        this.points = points;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
