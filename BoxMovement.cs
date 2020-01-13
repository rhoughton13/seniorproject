using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float speed = 8;
    public float doubleSpeed = 16;
    public bool wireframeMode = false;

    void Start()
    {
        this.enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        var cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.black);
    }

    private void OnMouseUpAsButton()
    {
        this.enabled = true;
        var cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.green);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.enabled = false;
            var cubeRenderer = gameObject.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.black);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            if (Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                transform.Rotate(Vector3.up, -doubleSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                transform.Rotate(Vector3.up, doubleSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Delete))
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
