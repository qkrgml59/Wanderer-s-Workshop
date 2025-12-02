using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public ItemSO item;

    private void OnTriggerEnter(Collider other)
    {
        Inventory inv = other.GetComponent<Inventory>();

        if (inv != null)
        {
            if (inv.AddItem(item))
            {
                Destroy(gameObject);
            }
        }
    }
}
