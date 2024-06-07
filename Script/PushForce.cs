using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForce : MonoBehaviour
{
    public float pushForce = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        // Rigidbody가 없거나, kinematic이면 작동 안함
        if (rb == null || rb.isKinematic)
        {
            return;
        }

        // 충돌한 방향으로 힘을 가함
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        rb.velocity = pushDir * pushForce;
    }
}
