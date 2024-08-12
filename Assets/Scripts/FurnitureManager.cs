using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class FurnitureManager : MonoBehaviour
{
    
    [SerializeField]
    GameObject indicatorToggleButton, pointerIndicatorObj;
    GameObject indicatorObj, currentFurnitureObj;
    public List<GameObject> furnitureList = new List<GameObject>();

    void Awake()
    {
        if(indicatorToggleButton.activeInHierarchy)
        {
            indicatorToggleButton.SetActive(false);
        }
        indicatorObj = pointerIndicatorObj.transform.GetChild(0).gameObject;
    }


    public void FurnitureToggleButton(int index)
    {

        if(!furnitureList[index].activeInHierarchy)
        {
            SpawnFurniture(index);
        }
        else
        {
            DisableFurniture(index);
        }


    }

    private void SpawnFurniture(int index)
    {
        if(index>=0&&index<furnitureList.Count)
            currentFurnitureObj = furnitureList[index];

        if (currentFurnitureObj != null && indicatorObj.activeInHierarchy)
        {
            currentFurnitureObj.transform.position = pointerIndicatorObj.transform.position;
            currentFurnitureObj.transform.rotation = pointerIndicatorObj.transform.rotation;
            currentFurnitureObj.SetActive(true);

            if(!indicatorToggleButton.activeInHierarchy)
                indicatorToggleButton.SetActive(true);


        }
    }

    private void DisableFurniture(int index)
    {
        if(furnitureList[index].activeInHierarchy)
            furnitureList[index].SetActive(false);

    }

    public void IndicatorToggleButton()
    {
        if(pointerIndicatorObj.activeInHierarchy)
        {
            pointerIndicatorObj.SetActive(false);
            indicatorObj.SetActive(false);
        }else
        {
            pointerIndicatorObj.SetActive(true);
            indicatorObj.SetActive(true);
        }
    }

    
}