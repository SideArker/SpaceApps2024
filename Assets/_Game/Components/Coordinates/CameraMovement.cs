using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = .75f;
    public Collider2D cameraBounds;

    private Vector3 minBounds;
    private Vector3 maxBounds;
    private float camHalfHeight; 
    private float camHalfWidth;
    [SerializeField] int numberOfStars;
    [SerializeField] GameObject star;
    [SerializeField] Collider2D spawnBounds;

    List<GameObject> stars = new List<GameObject>();

    void Start()
    {
        GenerateStars();

        Bounds bounds = cameraBounds.bounds;

        minBounds = bounds.min;
        maxBounds = bounds.max;

        camHalfHeight = GetComponent<Camera>().orthographicSize;
        camHalfWidth = camHalfHeight * GetComponent<Camera>().aspect;

    }

    void GenerateStars()
    {
        Vector3 minSpawnBounds = spawnBounds.bounds.min;
        Vector3 maxSpawnBounds = spawnBounds.bounds.max;
        for(int i = 0; i < numberOfStars; i++)
        {
            Vector2 randomVector = new Vector2(Random.Range(minSpawnBounds.x, maxSpawnBounds.x), Random.Range(minSpawnBounds.y, maxSpawnBounds.y));
            GameObject starClone = Instantiate(star);
            Debug.Log(starClone);
            starClone.transform.position = randomVector;
            stars.Add(starClone);
        }
    }

    void SendPing()
    {
        foreach(GameObject star in stars)
        {
            star.GetComponent<ParticleSystem>().Play();
        }
    }    
    
    void Update()
    {
        MoveCameraTowardsCursor();

        if(Input.GetKey(KeyCode.Space)) SendPing();
    }

    void MoveCameraTowardsCursor()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 targetPosition = GetComponent<Camera>().ScreenToWorldPoint(mousePosition);

        targetPosition.z = transform.position.z;
        float distance = Vector2.Distance(transform.position, targetPosition);

       
        float clampedX = Mathf.Clamp(targetPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(targetPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 clampedTargetPosition = new Vector3(clampedX, clampedY, transform.position.z);

        if(distance > 2) transform.position = Vector3.Lerp(transform.position, clampedTargetPosition, moveSpeed * Time.deltaTime);
    }
}