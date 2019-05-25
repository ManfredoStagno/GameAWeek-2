using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawScript : MonoBehaviour
{
    private Camera cam;

    public float frequency;
    public float magnitude;
    public float heightChange;

    public GameObject[] shapes;

    private GameObject activeShape;

    private void Start()
    {
        cam = Camera.main;
        NewShape();
    }
        
    private void FixedUpdate()
    {
        Oscillate();
    }

    private void Update()
    {
        Release();

        if (Input.GetMouseButton(1) && activeShape == null)
        {
            NewShape();
        }
    }



    //METHODS//

    void NewShape()
    {
        activeShape = Instantiate(shapes[Random.Range(0, shapes.Length)], transform.position, Quaternion.identity, transform);
    }

    void Release()
    {
        if(Input.GetMouseButton(0) && activeShape != null)
        {
            activeShape.GetComponent<Rigidbody>().useGravity = true;
            activeShape.transform.parent = null;
            activeShape = null;

            transform.position += new Vector3(0, heightChange, 0);
            cam.transform.position += new Vector3(0, heightChange, 0);
        }
    }

    void Oscillate()
    {
        Vector3 horizontal = new Vector3(Mathf.Cos(Time.time * frequency) * Time.deltaTime * magnitude, 0, 0);
        transform.position += horizontal;
    }


}
