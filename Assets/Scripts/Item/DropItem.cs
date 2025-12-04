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
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.transform.position);

        if(dist <= pickUpDistance)
        {
            Inventory inven = player.GetComponent<Inventory>();
            if (inven !=null && item !=null)
            {
                inven.AddItem(item);
                Destroy(gameObject);
            }
        }
    }
}
