using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    private Transform spaceshipTransform; // 우주선의 Transform 컴포넌트를 참조하기 위한 변수
    public Vector3 offset; // 우주선과 카메라 간의 오프셋 값

    private void Start()
    {
        // "Player" 태그를 가진 게임 오브젝트의 Transform 컴포넌트를 찾아 변수에 할당
        spaceshipTransform = GameObject.FindWithTag("Player").transform; 
    }

    private void LateUpdate()
    {
        if (spaceshipTransform != null)
        {
            Vector3 desiredPosition = spaceshipTransform.position + offset; // 우주선 위치에 오프셋을 더한 목표 위치 계산
            transform.position = desiredPosition; // 카메라의 위치를 목표 위치로 업데이트
        }
    }
}
