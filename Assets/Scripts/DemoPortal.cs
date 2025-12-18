using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPortal : MonoBehaviour
{

    public Transform targetPosition; // 이동할 위치

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            other.transform.position = targetPosition.position;
        }
    }
}
