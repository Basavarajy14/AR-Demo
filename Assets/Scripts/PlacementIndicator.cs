using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{

    private ARRaycastManager rayManager;
    private GameObject indicatorObj;

    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
        indicatorObj = this.transform.GetChild(0).gameObject;
        indicatorObj.SetActive(false);
       
    }

    void Update()
    {
        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // if we hit an AR plane surface, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            var CameraForward = Camera.current.transform.forward;       
            var cameraBearing = new Vector3(CameraForward.x, 0f, CameraForward.z).normalized;
            transform.rotation = Quaternion.LookRotation(cameraBearing);



            if (!indicatorObj.activeInHierarchy)
            {
                indicatorObj.SetActive(true);
            }

            
        }
    }
}