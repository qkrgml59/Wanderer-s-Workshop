using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopPanel; // 상점 UI
    private bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.P))
        {
            shopPanel.SetActive(!shopPanel.activeSelf); // P 누를 때마다 켜고 끄기
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            shopPanel.SetActive(false); // 플레이어가 나가면 자동으로 닫기
        }
    }
}
