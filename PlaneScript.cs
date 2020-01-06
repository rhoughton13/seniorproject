using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public float x = 1f;//These are the original starting numbers
    public float y = 0.1f;
    public float z = 1f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//increase X & Z by one 
        {
            transform.localScale += new Vector3(1f, 0f, 1f);
        }

        if (Input.GetKey(KeyCode.E) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//decrease X & Y by one
        {
            transform.localScale += new Vector3(-1f, 0f, -1f);
        }

    }
}
