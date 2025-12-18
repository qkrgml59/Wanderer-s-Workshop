using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public ItemSO item;
    public float pickUpDistance = 1.5f;

    public GameObject player;
    private Inventory inv;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
            inv = player.GetComponent<Inventory>();
    }

    private void Update()
    {
        if (player == null || inv == null || item == null) return;

        if (Vector3.Distance(transform.position, player.transform.position) <= pickUpDistance)
        {
            if (inv.AddItem(item, 1))
            { 
                Destroy(gameObject);
            }
        }
    }
}
