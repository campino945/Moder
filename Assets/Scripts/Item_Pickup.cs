using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{

    private Collider itemCollider;
    private GameObject item;

    private PlayerScript playerScript;

    [SerializeField]
    private bool ItemClose;

    [SerializeField]
    private LayerMask LayerMask;

    private GameObject itemtext;

    public uint itemId;
    


    // Start is called before the first frame update
    void Start()
    {
        ItemClose = false;

        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        
        itemtext = GameObject.Find("ItemPickupText");

        if(gameObject.name == "SparkPlug")
        {
            itemId = 0;
        }
        else if(gameObject.name == "JerryCan")
        {
            itemId = 1;
        }
        else if (gameObject.name == "ToolBox")
        {
            itemId = 2;
        }
        else if (gameObject.name == "CarBattery")
        {
            itemId = 3;
        }
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

                if (item.name == "SparkPlug")
                {
                    itemId = 0;
                }
                else if (item.name == "JerryCan")
                {
                    itemId = 1;
                }
                else if (item.name == "ToolBox")
                {
                    itemId = 2;
                }
                else if (item.name == "CarBattery")
                {
                    itemId = 3;
                }

                item.SetActive(false);
                ItemClose = false;

                playerScript.items[itemId] = true;
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
