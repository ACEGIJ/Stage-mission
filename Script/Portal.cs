using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portal : MonoBehaviour
{
    public Vector3 destination; // 이동 좌표

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //CharacterController 확인
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                // CharacterController 비활성화
                controller.enabled = false;

                // 위치 설정
                other.transform.position = destination;

                // CharacterController 활성화
                controller.enabled = true;
            }
            else
            {
                // CharacterController없을 때 직접 위치 설정
                other.transform.position = destination;
            }
        }
    }
}
