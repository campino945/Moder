using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{

    private Collider itemCollider;
    private GameObject item;


    [SerializeField]
    private bool ItemClose;

    [SerializeField]
    private LayerMask LayerMask;

    private Transform mainCamera;
    private Transform cameraHolder;

    private GameObject itemtext;
    

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        ItemClose = false;

        mainCamera = GameObject.Find("PlayerCam").GetComponent<Transform>();
        cameraHolder = GameObject.Find("CameraHolder").GetComponent<Transform>();
        itemtext = GameObject.Find("ItemPickupText");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ItemClose)
        {
            itemtext.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {
                item = itemCollider.gameObject;

                item.SetActive(false);
                ItemClose = false;
            }
        }
        else
        {
            itemtext.SetActive(false);
        }

        
    }

    private Collider OnTriggerEnter(Collider other)
    {
        ItemClose = true;
        itemCollider = other;
        return other;
    }

    private void OnTriggerExit()
    {
        ItemClose = false;
    }
}
