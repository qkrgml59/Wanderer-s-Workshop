using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBench : MonoBehaviour
{
    public GameObject craftingUI;
    public GameObject inventoryUI;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            craftingUI.SetActive(true);
            inventoryUI.SetActive(true);
        }
    }
}
