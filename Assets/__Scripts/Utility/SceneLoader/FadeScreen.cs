using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls screen fading functionality.
/// </summary>
public class FadeScreen : MonoBehaviour
{
    /// <summary>
    /// Gets the duration of the fade effect.
    /// </summary>
    public float FadeDuration => fadeDuration;
    [SerializeField] float fadeDuration = 2f;

    [SerializeField] bool fadeOnStart;
    [SerializeField] Color fadeColor;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        Color newColorOut = fadeColor;
        newColorOut.a = 0;
        image.color = newColorOut;
    }

    /// <summary>
    /// Initiates the fade-in effect.
    /// </summary>
    public void FadeIn()
    {
        Fade(1, 0);
    }

    /// <summary>
    /// Initiates the fade-out effect.
    /// </summary>
    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void FadeAction(Action action)
    {
        StartCoroutine(FadeActionCorutine(action));
    }

    private IEnumerator FadeActionCorutine(Action action)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(0, 1, timer / fadeDuration);
            image.color = newColor;

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColorOut = fadeColor;
        newColorOut.a = 1;
        image.color = newColorOut;

        yield return new WaitForSeconds(0.25f);
        action?.Invoke();

        timer = 0f;
        while (timer < fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(1, 0, timer / fadeDuration);
            image.color = newColor;

            timer += Time.deltaTime;
            yield return null;
        }

        newColorOut = fadeColor;
        newColorOut.a = 0;
        image.color = newColorOut;

    }

    /// <summary>
    /// Initiates the fade effect with specified alpha values.
    /// </summary>
    /// <param name="alphaIn">Alpha value for fading in.</param>
    /// <param name="alphaOut">Alpha value for fading out.</param>
    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    /// <summary>
    /// Coroutine that handles the fading effect over time.
    /// </summary>
    /// <param name="alphaIn">Alpha value for fading in.</param>
    /// <param name="alphaOut">Alpha value for fading out.</param>
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            image.color = newColor;

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColorOut = fadeColor;
        newColorOut.a = alphaOut;
        image.color = newColorOut;
    }
}
