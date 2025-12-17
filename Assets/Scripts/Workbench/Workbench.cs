using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBench : MonoBehaviour
{
    public CraftingUI craftUI;
    public float interactDistance = 2f;
    public CraftingUI craftingUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (!player) return;

        if (Vector3.Distance(player.transform.position, transform.position) <= interactDistance)
        {
            craftUI.Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            craftingUI.Close();
    }
}
