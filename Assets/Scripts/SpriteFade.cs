using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteFade : MonoBehaviour
{
    public Image spriteRenderer;
    public Color spriteColor;
    public EightWayMovement Floyd;

    void Start()
    {
        spriteRenderer = GetComponent<Image>();
        spriteColor = spriteRenderer.color;
        
    }

    public void Fade() {
        StartCoroutine(FadeInOut());
        
    }

    public IEnumerator FadeInOut()
    {
        
        yield return StartCoroutine(FadeTo(1f, 0.5f));

        yield return new WaitForSeconds(0.5f);
      
        yield return StartCoroutine(FadeTo(0f, 0.5f));

        Floyd.inTransition = false;
    }

    public IEnumerator FadeTo(float targetAlpha, float duration)
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
