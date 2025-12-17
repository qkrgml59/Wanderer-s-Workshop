using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGather : MonoBehaviour
{
    public float gatherDistance = 3f;
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

        if (Physics.Raycast(ray, out RaycastHit hit, gatherDistance))
        {
            if (hit.collider.TryGetComponent<Block>(out Block block))
            {
                block.Hit((int)PlayerStats.Instance.gatherDamage);
            }
            else if (hit.collider.TryGetComponent<PlaceableObject>(out PlaceableObject place))
            {
                place.Hit((int)PlayerStats.Instance.gatherDamage);
            }
        }
    }
}
