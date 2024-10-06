
using UnityEngine;

public class PointCounter : MonoBehaviour
{

    [SerializeField] float pointsPerCorrectPlanet;
    [SerializeField] float maxTimeForPoints;
    [SerializeField] float maxPointsForTime;
    

    public void AddPoints( float time)
    {
        // float points = 0;
        // points += DataHandler.instance.correctPlanet ? pointsPerCorrectPlanet : 0;
        // if (time < maxTimeForPoints) points += maxPointsForTime * (1 - time / maxTimeForPoints);
        //
        // DataHandler.instance.SetPoints(points);
    }
}
