using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGather : MonoBehaviour
{
    public float attackRange = 3f;
    public LayerMask blockLayer;
    public int baseDamage = 1;

    Camera cam;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ÁÂÅ¬¸¯
        {
            TryGather();
        }
    }

    void TryGather()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, attackRange, blockLayer))
        {
            Block block = hit.collider.GetComponent<Block>();
            if (block)
            {
                int damage = Mathf.RoundToInt(
                    baseDamage * PlayerStats.Instance.gatherDamage
                );

                block.Hit(damage);
            }
        }
    }
}
