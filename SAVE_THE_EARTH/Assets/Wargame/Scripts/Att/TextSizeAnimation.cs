using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextSizeAnimation : MonoBehaviour
{
    public TMP_Text text; // TMP_Text 컴포넌트를 가리키는 변수
    public float maxSize = 30f; // 텍스트의 최대 크기
    public float minSize = 10f; // 텍스트의 최소 크기
    public float duration = 2f; // 애니메이션의 지속 시간

    private Coroutine animationCoroutine; // 애니메이션 코루틴을 참조하는 변수

    private void Start()
    {
        // 텍스트 크기 애니메이션 코루틴 시작
        animationCoroutine = StartCoroutine(AnimateTextSize());
    }

    private void OnDestroy()
    {
        // 객체가 파괴될 때 애니메이션 코루틴 중지
        if (animationCoroutine != null) StopCoroutine(animationCoroutine);
    }

    private IEnumerator AnimateTextSize()
    {
        float timer = 0f; // 애니메이션 타이머 초기화

        while (true)
        {
            while (timer < duration)
            {
                float t = timer / duration; // 경과 시간 비율
                float size = Mathf.Lerp(minSize, maxSize, t); // 크기 보간
                text.fontSize = size; // 텍스트 크기 설정
                timer += Time.deltaTime; // 경과 시간 증가
                yield return null; // 1프레임 대기
            }

            timer = 0f; // 타이머 초기화

            while (timer < duration)
            {
                float t = timer / duration; // 경과 시간 비율
                float size = Mathf.Lerp(maxSize, minSize, t); // 크기 보간 (반대로)
                text.fontSize = size; // 텍스트 크기 설정
                timer += Time.deltaTime; // 경과 시간 증가
                yield return null; // 1프레임 대기
            }
        }
    }
}
