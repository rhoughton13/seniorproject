using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 8;
    public float doubleSpeed = 16;
    public Camera MainCamera, Camera2;
    public int availableBox;
    public int availableCrate;
    public int availableCylinder;

    void Start()
    {
        MainCamera.gameObject.SetActive(true);
        GameObject.Find("Camera2").transform.position = new Vector3(0.88f, 13.60f, -1.63f);//Still need to find best position

        Camera2.gameObject.SetActive(false);

        availableBox = 0;
        availableCrate = 0;
        availableCylinder = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.N) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            availableBox++;
        }
        if (Input.GetKey(KeyCode.L) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))//Left CTRL + L to create Crate
        {
            availableCrate++;
        }
        if (Input.GetKey(KeyCode.C) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))//Left CTRL + C to create Cylinder
        {
            availableCylinder++;
        }
        if (Input.GetKey(KeyCode.Equals) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Minus) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
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
        if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.right, -doubleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.right, doubleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.up, -doubleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.Rotate(Vector3.up, doubleSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.F12))//Puts .jpg in project folder. 
        {
            ScreenCapture.CaptureScreenshot("UnityProj.jpg");
        }
        if (availableBox == 1)
        {
            CreateObject(10, 10, 20);
            StartCoroutine(Waiter());
        }
        if (availableCrate == 1)
        {
            CreateCrate();
            StartCoroutine(Waiter());
        }
        if (availableCylinder == 1)
        {
            CreateCylinder();
            StartCoroutine(Waiter());
        }
    }

    public void CreateObject(float width, float height, float length) //Create box with input
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent(typeof(Rigidbody));
        cube.AddComponent(typeof(BoxMovement));
        cube.GetComponent<Rigidbody>().isKinematic = false;
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.black);
        cube.transform.localScale = new Vector3(width, height, length);
        cube.transform.position = new Vector3(0, height / 2, 0);
    }

    public void CreateCylinder()//create standard Cylinder
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.AddComponent(typeof(Rigidbody));
        cube.AddComponent(typeof(BoxMovement));
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
        cube.AddComponent(typeof(BoxMovement));
        cube.transform.localScale = new Vector3(2f, 2f, 2f);
        cube.transform.position = new Vector3(0, 0.5f, 0);
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5);
        availableBox = 0;
        availableCrate = 0;
        availableCylinder = 0;
    }
}
