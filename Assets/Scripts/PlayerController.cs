using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("플레이어 정보")]
    public float moveSpeed = 5f;
    public float jumpPower = 5f;
    public float gravity = -9.81f;

    [Header("마우스 감도)")] 
    public float mouseSensitivity = 3f;
    float xRotation = 0f;

    CharacterController controller;
    Transform cam;
    Vector3 velocity;
    bool isGrounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (cam == null)
        {
            cam = GetComponentInChildren<Camera>()?.transform;
        }
    }

    void Update()
    {
        HandleMove();
        HandleLook();
    }

    void HandleMove()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.right * h + transform.forward * v;
        controller.Move(move * moveSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        if (cam != null)
            cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);              //Quaternion = x,y,z축 꼬임 방지의 새로운 축을 생성

    }

    public void CollectItem(ItemSO item)
    {

        int itemCount = 1;
        // 인벤토리에 추가
        Inventory.Instance.AddItem(item, itemCount);

        // 퀘스트에 반영
        QuestManager.Instance.OnGather(item);
    }

    public void CraftItem(ItemSO item)
    {
        // 제작 후 퀘스트 반영
        QuestManager.Instance.OnCraft(item);
    }
}
