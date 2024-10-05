using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler instance;
    [SerializeField] float points;
    [SerializeField] float time;
    [field: SerializeField]
    public PlanetObject selectedPlanet { get; private set; }
    public bool correctPlanet { get; private set; }

    List<PlanetObject> planets = new List<PlanetObject>();

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
        selectedPlanet = planets[Random.Range(0, planets.Count)];
    }

    public void EndGame()
    {
        Debug.LogWarning("Game end");
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
