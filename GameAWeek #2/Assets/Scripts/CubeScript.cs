using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    Rigidbody rb;

    [HideInInspector]
    public bool isLanded;

    [HideInInspector]
    public bool isActiveCube;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isLanded = false;
        //if example object Disable Script
        if (gameObject.transform.parent == null)
        {
            this.enabled = false;
        }
    }

    private void Update()
    {
        //Check Landed
        if (Mathf.Approximately(0, rb.velocity.x) && Mathf.Approximately(0, rb.velocity.y) && Mathf.Approximately(0, rb.velocity.z))
        {
            isLanded = true;
        }

        //Check Active Cube
        if (gameObject.transform.parent == null)
        {
            isActiveCube = false;
        }
        else
        {
            isActiveCube = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check Landed
        if (collision.collider.CompareTag("Cube"))
        {
            isLanded = true;
        }
        //Check OutOfBounds
        else
        {
            GameManager.instance.OutOfBounds();
        }
    }

    //Check NOT Landed
    private void OnCollisionExit(Collision collision)
    {
        isLanded = false;
    }

    //Check OutOfBounds
    private void OnBecameInvisible()
    {
        if (!isLanded)
        {
            GameManager.instance.OutOfBounds();
        }

        if (isActiveCube)
        {
            GameManager.instance.OutOfBounds();
        }
    }
}
