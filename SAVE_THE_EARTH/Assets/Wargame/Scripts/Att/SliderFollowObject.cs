using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFollowObject : MonoBehaviour
{
    public GameObject objectA; // 오브젝트 A (추적 대상)
    public Slider slider; // 슬라이더 UI

    private float collisionValueDecrease; // 충돌 시 감소할 값
    private RectTransform sliderRectTransform; // 슬라이더의 RectTransform 컴포넌트
    private RectTransform canvasRectTransform; // 캔버스의 RectTransform 컴포넌트

    private void Start()
    {
        // 초기화 작업
        sliderRectTransform = slider.GetComponent<RectTransform>();
        canvasRectTransform = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        // 오브젝트 A의 태그에 따라 슬라이더의 초기 값 설정
        if (objectA.CompareTag("Alien"))
        {
            slider.value = 50;
        }
        
        if (objectA.CompareTag("Asteroid"))
        {
            slider.value = 20;
        }
    }

    private void Update()
    {
        // 오브젝트 A의 위치를 슬라이더 위치로 매핑하여 UI 이동
        Vector2 objectAPosition = objectA.transform.position;
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(objectAPosition);
        Vector2 sliderPosition = new Vector2(
            (viewportPosition.x * canvasRectTransform.sizeDelta.x) - (canvasRectTransform.sizeDelta.x * 0.5f),
            (viewportPosition.y * canvasRectTransform.sizeDelta.y) - (canvasRectTransform.sizeDelta.y * 0.5f)
        );
        sliderRectTransform.anchoredPosition = sliderPosition;

        // 충돌 시 감소할 값 설정
        GameObject spaceshipObject = GameObject.Find("Spaceship(Clone)");
        GameObject spaceshipObject2 = GameObject.Find("Spaceship 1(Clone)");
        if (spaceshipObject != null){
            collisionValueDecrease = 10;
        }
        else if (spaceshipObject2 != null){
            collisionValueDecrease = 20f;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌 시 슬라이더 값 감소
        if (collision.gameObject.CompareTag("Bullet") && !objectA.CompareTag("Planet"))
        {
            slider.value -= collisionValueDecrease;

            // 슬라이더 값이 0 이하이면 오브젝트 파괴 및 킬 카운트 증가
            if(slider.value <= 0){
                Destroy(gameObject);
                if(gameObject.CompareTag("Alien") || gameObject.CompareTag("Alien2")) KillCounter.instance.ailenKill++;
                if(gameObject.CompareTag("Asteroid") || gameObject.CompareTag("Asteroid2")) KillCounter.instance.meteorKill++;      
            }
        }
    }
}
