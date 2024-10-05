using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField][Range(25f, 50f)] float timeForFlicker;
    [SerializeField][Range(0, 1)] float flickerDuration;

    void Start()
    {
        StartCoroutine(LightFlick());   
    }

    IEnumerator LightFlick()
    {
        Light2D light = GetComponent<Light2D>();
        while(true)
        {
            int subsequentFlicks = Random.Range(0, 2);

            yield return new WaitForSeconds(Random.Range(25, timeForFlicker));
            for (int i = 0; i < subsequentFlicks; i++)
            {
                light.enabled = false;

                yield return new WaitForSeconds(flickerDuration);
                light.enabled = true;
            }


        }
    }


}
