using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public ItemSO item;          // 다시 얻을 아이템
    public int maxHP = 1;
    int hp;

    public GameObject dropPrefab;

    void Awake()
    {
        hp = maxHP;

        if (!GetComponent<Collider>())
            gameObject.AddComponent<BoxCollider>();
    }

    public void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Drop();
            Destroy(gameObject);
        }
    }

    void Drop()
    {
        GameObject drop = Instantiate(dropPrefab, transform.position, Quaternion.identity);
        drop.GetComponent<DropItem>().item = item;
    }
}
