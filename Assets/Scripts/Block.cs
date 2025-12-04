using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public enum BlockType { Dirt, Water, Gress, Air, steel, coal }
public class Block : MonoBehaviour
{
    [Header("Block")]
    public BlockType type = BlockType.Dirt;
    public int maxHP = 3;

    [HideInInspector] public int hp;

    [Header("드롭 아이템")]
    public ItemSO dropItem;
    public GameObject dropPrefab;
    public int dropCount = 1;
    public bool mineable = true;

    private void Awake()
    {
        hp = maxHP;

        if (GetComponent<Collider>() == null)
            gameObject.AddComponent<BoxCollider>();

        if (string.IsNullOrEmpty(gameObject.tag) || gameObject.tag == "Untagged")
            gameObject.tag = "Block";
    }

    public void Hit(int damage)
    {
        if (!mineable) return;

        hp -= damage;

        if (hp <= 0)
        {
            DropItems();
            Destroy(gameObject);

        }
    }

    void DropItems()
    {
        if (dropItem == null || dropPrefab == null) return;

        for (int i = 0; i < dropCount; i++)
        {
            GameObject drop = Instantiate(dropPrefab, transform.position, Quaternion.identity);
            drop.GetComponent<DropItem>().item = dropItem;
        }

    }
}
