using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class SpectroscopyAnimation : MonoBehaviour
{
    [SerializeField] private Transform planetTransform;
    [SerializeField] private Transform starTransform;
    private bool isSpectroscoping = false;
    
    [Button]
    public void StartTranzytAnimation()
    {
        isSpectroscoping = true;
    }

    private void Update()
    {
        if (isSpectroscoping)
        {
            
            starTransform.transform.localPosition = Vector3.zero;
            print(planetTransform.localPosition);
            // starTransform.transform.localPosition = planetTransform.localPosition * -1;
            
        }
    }
}
