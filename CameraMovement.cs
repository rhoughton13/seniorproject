using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 8;
    public float doubleSpeed = 16;
    public int creatable;
    public Camera MainCamera, Camera2;//You must create Camera2 in your Unity project and position it to your liking. 

    void Start()
    {
        creatable = 0;
        MainCamera.gameObject.SetActive(true);
        Camera2.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.L) && (Input.GetKey(KeyCode.LeftControl)))//Left CTRL + L to create Crate
        {
            CreateCrate();
            StartCoroutine(waiter());
        }
        if (Input.GetKey(KeyCode.C) && (Input.GetKey(KeyCode.LeftControl)))//Left CTRL + C to create Cylinder
        {
            CreateCylinder();
            StartCoroutine(waiter());
        }
        if (Input.GetKey(KeyCode.N) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            creatable++;
        }
        if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.up, -doubleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.up, doubleSpeed * Time.deltaTime);
        }
        if (creatable == 1)
        {
            CreateObject();
            StartCoroutine(Waiter());
        }
          if(Input.GetKey(KeyCode.Z) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//switch cameras to MainCamera
        {
                MainCamera.gameObject.SetActive(true);
                Camera2.gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.X) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))//switch cameras to Camera2
        {
            MainCamera.gameObject.SetActive(false);
            Camera2.gameObject.SetActive(true);
        }
    }
    public void CreateObject()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent(typeof(Rigidbody));
        cube.AddComponent(typeof(BoxMovement));
        cube.GetComponent<Rigidbody>().isKinematic = false;
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.black);
        cube.transform.localScale = new Vector3(10f, 10f, 10f);
        cube.transform.position = new Vector3(0, 5f, 0);
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5);
        creatable = 0;
    }
    public void CreateCylinder()//create standard Cylinder
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent(typeof(Rigidbody));
        cube.AddComponent(typeof(Movement2));
        cube.GetComponent<Rigidbody>().isKinematic = false;
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.black);
        cube.transform.localScale = new Vector3(1f, 1f, 1f);
        cube.transform.position = new Vector3(0, 5f, 0);
    }

    public void CreateCrate()//create standard Crate
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent(typeof(Rigidbody));
        cube.AddComponent(typeof(Movement2));
        cube.transform.localScale = new Vector3(2f, 2f, 2f);
        cube.transform.position = new Vector3(0, 0.5f, 0);
    }
}
