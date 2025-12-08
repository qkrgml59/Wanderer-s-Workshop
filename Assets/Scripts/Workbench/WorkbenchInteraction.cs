using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchInteraction : MonoBehaviour
{
    public GameObject craftingUI;   //작업대 UI


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TryOpenWorkbench();
        }
    }

    void TryOpenWorkbench()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);   // 메인 카메라를 기준으로 마우스 위치의 광선 생성 <- ScreenPointToRay

        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                ToggleWorkbench();
            }
        }
    }

    void ToggleWorkbench()
    {
        CraftingUIManager.Instance.ToggleUI();
    }
}
