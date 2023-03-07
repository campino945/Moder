using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float movementScore;
    public float lightScore;

    public Rigidbody rb;

    private TMP_Text moveText;

    public bool[] items = new bool[3];
    
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0;i < 3; i++)
        {
            items[i] = false;
        }
        
        movementScore = 0f;
        lightScore = 0f;

        moveText = GameObject.Find("SoundText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 2 && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
        {
            movementScore += 1 * Time.deltaTime;
        }
        else if (rb.velocity.magnitude > 2 && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
        {
            movementScore += 2.5f * Time.deltaTime;
        }
        else if(rb.velocity.magnitude > 2 && Input.GetKey(KeyCode.LeftControl))
        {
            movementScore += 0.1f * Time.deltaTime;
        }
        else if(rb.velocity.magnitude < 2 && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
        {
            movementScore -= 1 * Time.deltaTime;
        }

        movementScore -= (Mathf.Pow(2, (movementScore / 10)) / 50) * Time.deltaTime;

        if(movementScore < 0)
        {
            movementScore = 0;
        }
        


        moveText.text = "Sound " + Mathf.Round(movementScore);
        if(movementScore < 30)
        {
            moveText.color = Color.green;
        }
        else if(movementScore >= 30)
        {
            moveText.color = Color.red;
        }

    }
}
