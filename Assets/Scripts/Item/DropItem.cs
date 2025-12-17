using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public ItemSO item;
    public float pickUpDistance = 1.5f;

    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (!player) return;

        if (Vector3.Distance(transform.position, player.transform.position) <= pickUpDistance)
        {
            Inventory inv = player.GetComponent<Inventory>();
            if (inv && inv.AddItem(item, 1))
            {
                Destroy(gameObject);
            }
        }
    }
}
