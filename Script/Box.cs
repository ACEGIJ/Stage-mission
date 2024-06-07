using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject door;  // 문 설정
    public Vector3 openPosition;  // 문이 열렸을 때의 위치
    public float openSpeed = 2f;  // 문이 열리는 속도
    public int requiredBoxCount = 4;  // 필요한 박스 개수

    private Vector3 closedPosition;  // 문이 닫힌 위치
    private int currentBoxCount = 0;  // 현재 트리거 안에 있는 박스 개수

    void Start()
    {
        if (door != null)
        {
            closedPosition = door.transform.position;  // 시작할 때 문이 닫힌 위치 저장
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            currentBoxCount++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            currentBoxCount--;
        }
    }

    void Update()
    {
        if (currentBoxCount == requiredBoxCount && door != null)
        {
            // 문 열림
            door.transform.position = Vector3.Lerp(door.transform.position, openPosition, Time.deltaTime * openSpeed);
        }
        else if (door != null)
        {
            // 문 닫힘
            door.transform.position = Vector3.Lerp(door.transform.position, closedPosition, Time.deltaTime * openSpeed);
        }
    }
}
