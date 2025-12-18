using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUIManager : MonoBehaviour
{
    public GameObject workshopButton;

    private void Start()
    {
        if (workshopButton != null)
            workshopButton.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            workshopButton.SetActive(!workshopButton.activeSelf);
        }
    }

    public void OnWorkshopButtonClicked()
    {
        SceneLoader.Instance.GoToWorkshop();
    }
}
