using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRotation : MonoBehaviour
{
    private void OnEnable()
    {
        Vector3 vct = new Vector3(0, 0, Random.Range(0,360));
        transform.Rotate(vct);
        
    }
    
    
}
