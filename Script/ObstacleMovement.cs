using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2f; // 기본 이동 속도
    public float distance = 3f; // 기본 이동 거리
    public bool moveHorizontally = true; // 좌우 이동 여부
    public bool moveVertically = false; // 위아래 이동 여부

    private Vector3 startPos; // 초기 위치
    private Vector3 moveDirection = Vector3.right; // 이동 방향 (기본값: 우측)

    void Start()
    {
        startPos = transform.position; // 시작 위치 설정
        if (!moveHorizontally && moveVertically)
        {
            moveDirection = Vector3.up; // 위로 이동 설정
        }
    }

    void Update()
    {
        // 좌우, 위 아래로 이동
        if (moveHorizontally || moveVertically)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);

            // 거리가 일정 거리 이상 넘어가면 방향을 반대로 변경
            if (Mathf.Abs((moveDirection.x != 0 ? transform.position.x : transform.position.y) - (moveDirection.x != 0 ? startPos.x : startPos.y)) >= distance)
            {
                moveDirection *= -1f;
            }
        }
    }
}
