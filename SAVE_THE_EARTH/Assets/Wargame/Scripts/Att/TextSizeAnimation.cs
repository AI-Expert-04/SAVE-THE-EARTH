using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextSizeAnimation : MonoBehaviour
{
    public TMP_Text text;
    public float maxSize = 30f;
    public float minSize = 10f;
    public float duration = 2f;

    private Coroutine animationCoroutine;

    private void Start()
    {
        animationCoroutine = StartCoroutine(AnimateTextSize());
    }

    private void OnDestroy()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
    }

    private IEnumerator AnimateTextSize()
    {
        float timer = 0f;

        while (true)
        {
            while (timer < duration)
            {
                float t = timer / duration;
                float size = Mathf.Lerp(minSize, maxSize, t);
                text.fontSize = size;
                timer += Time.deltaTime;
                yield return null;
            }

            // 크기가 maxSize에 도달한 후 잠시 멈춤
            //yield return new WaitForSeconds(0.5f);

            timer = 0f;

            while (timer < duration)
            {
                float t = timer / duration;
                float size = Mathf.Lerp(maxSize, minSize, t);
                text.fontSize = size;
                timer += Time.deltaTime;
                yield return null;
            }

            // 크기가 minSize에 도달한 후 잠시 멈춤
            //yield return new WaitForSeconds(0.5f);
        }
    }
}