using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteFade : MonoBehaviour
{
    public Image spriteRenderer;
    public Color spriteColor;
    public Floyd Floyd;
    public GameObject sleep;

    void Start()
    {
        spriteRenderer = GetComponent<Image>();
        spriteColor = spriteRenderer.color;
        StartCoroutine(FadeTo(0f, 2f));
        
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
    public IEnumerator FadeInOutLong()
    {
        if (!Floyd.gameObject.activeSelf) StartCoroutine(wakeFloyd());
        yield return StartCoroutine(FadeTo(1f, 0.5f));

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(FadeTo(0f, 0.5f));

        Floyd.inTransition = false;
    }
    public IEnumerator FadeTo(float targetAlpha, float duration)
    {
        Debug.Log("Empieza");
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
        Debug.Log("Acaba");
    }
    public IEnumerator wakeFloyd()
    {
        yield return new WaitForSeconds(0.5f);
        Floyd.gameObject.SetActive(true);
        sleep.SetActive(false);
        if (GameManager.Instance.sound) Floyd.GetComponent<AudioSource>().Play();

    }

}
