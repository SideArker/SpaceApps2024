using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField][Range(25f, 50f)] float timeForFlicker = 25f;
    [SerializeField][Range(0, 1)] float flickerDuration;
    [SerializeField] Sprite litSprite;
    [SerializeField] Sprite unlitSprite;

    void Start()
    {
        StartCoroutine(LightFlick());   
    }

    IEnumerator LightFlick()
    {
        Light2D light = GetComponent<Light2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        while(true)
        {
            int subsequentFlicks = Random.Range(1, 2);
            Debug.Log(subsequentFlicks);
            Debug.Log("yooo");
            yield return new WaitForSeconds(Random.Range(1, 5));
            for (int i = 0; i < subsequentFlicks; i++)
            {
                spriteRenderer.sprite = unlitSprite;
                light.enabled = false;

                yield return new WaitForSeconds(flickerDuration);
                light.enabled = true;
                spriteRenderer.sprite = litSprite;
            }


        }
    }


}
