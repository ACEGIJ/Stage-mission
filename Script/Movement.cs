using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;
    public Transform cameraTransform;
    public float mouseSensitivity = 100.0f;
    public float cameraDistance = 5.0f;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float cameraPitch = 0.0f;
    private float cameraYaw = 0.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.None; 
    }

    void Update()
    {
        HandleMovement();
        HandleCameraRotation();
        HandleAnimation();
    }

    void LateUpdate()
    {
        UpdateCameraPosition();
    }

    void HandleMovement()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            move += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += transform.right;
        }

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleCameraRotation()
    {
        if (Input.GetMouseButton(1)) // 우클릭 상태 확인
        {
            Cursor.lockState = CursorLockMode.Locked; 
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            cameraYaw += mouseX; // 카메라 회전 각도 누적
            cameraPitch -= mouseY;
            cameraPitch = Mathf.Clamp(cameraPitch, -45.0f, 45.0f); // 카메라 피치 각도 제한

            cameraTransform.localRotation = Quaternion.Euler(cameraPitch, cameraYaw, 0.0f);
            transform.rotation = Quaternion.Euler(0.0f, cameraYaw, 0.0f); // 캐릭터 회전
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; // 마우스 기본 상태
        }
    }

    void UpdateCameraPosition()
    {
        cameraTransform.position = transform.position - cameraTransform.forward * cameraDistance + Vector3.up * 2.0f; // 카메라 높이 조정
    }

    void HandleAnimation()
    {
        Animator anim = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.Play("RUN");
        }

        else
        {
            anim.Play("WAIT"); 
        }
    }

    IEnumerator Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        while (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
            yield return null;
        }
    }
}
