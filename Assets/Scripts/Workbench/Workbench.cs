using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Workbench : MonoBehaviour
{
    public CraftingManager craftingManager;
    public CraftingSlot[] craftingSlots;

    public float craftDistance = 2.5f;
    private Transform player;

    private void Start()
    {
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) player = p.transform;
    }

    private void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(player.position, transform.position);

        if (dist <= craftDistance && Input.GetKeyDown(KeyCode.F))
        {
            TryCrafting();
        }
    }

    private void TryCrafting()
    {
        List<RecipeIngredient> inputs = new List<RecipeIngredient>();

        foreach(var slot in craftingSlots)
        {
            if (slot.item != null && slot.count > 0)
                inputs.Add(slot.ToIngredient());
        }

        bool success = craftingManager.TryCraft(inputs);

        if(success)
        {
            foreach (var slot in craftingSlots)
                slot.Clear();
        }
    }

}

