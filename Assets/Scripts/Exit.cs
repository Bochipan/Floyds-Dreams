using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public SpriteFade3D fade;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Exit") StartCoroutine(wakeUp());
    }
    public IEnumerator wakeUp()
    {
        fade.StartCoroutine(fade.FadeTo(1f, 0.5f));
        yield return new WaitForSeconds(2f);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("2DScene");

    }
}
