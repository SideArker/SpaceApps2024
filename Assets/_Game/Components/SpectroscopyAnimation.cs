using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

public class SpectroscopyAnimation : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform planetTransform;

    [SerializeField] private Camera camera;

    [SerializeField] private float speed = 1f;
    private bool isSpectroscoping = false;
    private void Start()
    {
        // camera = cameraTransform.gameObject.GetComponent<Camera>();

    }

    [Button]
    public void StartTranzytAnimation()
    {
        isSpectroscoping = true;
        cameraTransform.parent = planetTransform;
    }

    private void Update()
    {
        if(isSpectroscoping)
        {
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, new Vector3(0f, 0f, cameraTransform.localPosition.z), Time.deltaTime * speed);
            
            camera.fieldOfView = math.lerp(camera.fieldOfView, 9, Time.deltaTime * speed);;
        }    
    }
}
