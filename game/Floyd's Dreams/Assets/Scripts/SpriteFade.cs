using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color spriteColor;
    public EightWayMovement Floyd;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
        
    }

    public void Fade() {
        StartCoroutine(FadeInOut());
        
    }

    public IEnumerator FadeInOut()
    {
        
        yield return StartCoroutine(FadeTo(1f, 2f));

        yield return new WaitForSeconds(0.5f);
      
        yield return StartCoroutine(FadeTo(0f, 2f));

        Floyd.inTransition = false;
    }

    private IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = spriteColor.a;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            spriteColor.a = alpha;
            spriteRenderer.color = spriteColor;
            yield return null;
        }

       
        spriteColor.a = targetAlpha;
        spriteRenderer.color = spriteColor;
    }
}
