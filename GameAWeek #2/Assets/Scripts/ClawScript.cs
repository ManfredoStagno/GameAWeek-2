using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawScript : MonoBehaviour
{
    private Camera cam;

    public float frequency;
    public float magnitude;
    public float heightChange;

    [Header("Perfect!")]
    public float perfectDistance;
    public int perfectScore;
    public float perfectOffset;
    [Header("Good")]
    public float goodDistance;
    public int goodScore;
    public float goodOffset;
    [Header("Meh")]
    public float mehDistance;
    public int mehScore;
    public float mehOffset;
    [Header("Oops")]
    public float oopsDistance;
    public int oopsScore;
    public float oopsOffset;
    

    public GameObject[] cubes;
    public GameObject firstCube;

    private GameObject activeCube;
    private GameObject previousCube;

    private void Start()
    {
        cam = Camera.main;

        previousCube = firstCube;

        NewShape();
    }

    //Oscillation
    private void FixedUpdate()
    {
        Oscillate();
    }

    private void Update()
    {
        if (activeCube == null)
        {
            NewShape();
        }

        Release();

        if (IsLanded())
        {
            
            onCubeLanded();
        }
    }


    //METHODS//
    void NewShape()
    {
        activeCube = Instantiate(cubes[Random.Range(0, cubes.Length)], transform.position, Quaternion.identity, transform);
    }

    void Release()
    {
        if (Input.GetMouseButton(0) && activeCube != null)
        {
            activeCube.GetComponent<Rigidbody>().useGravity = true;
            activeCube.transform.parent = null;
        }
    }


    void onCubeLanded()
    {
        transform.position += new Vector3(0, heightChange, 0);
        cam.transform.position += new Vector3(0, heightChange, 0);

        CheckScores();

        previousCube = activeCube;
        activeCube = null;
    }

    void CheckScores()
    {
        float distance = Mathf.Abs(activeCube.transform.position.x - previousCube.transform.position.x);

        if (isThisTheScore(distance, perfectDistance, perfectScore, perfectOffset))
        {
            Debug.Log("PERFECT!");
            return;
        }
        else if (isThisTheScore(distance, goodDistance, goodScore, goodOffset))
        {
            Debug.Log("Good");
            return;
        }
        else if (isThisTheScore(distance, mehDistance, mehScore, mehOffset))
        {
            Debug.Log("Meh");
            return;
        }
        else
        {
            Debug.Log("Oops");
            isThisTheScore(distance, oopsDistance, oopsScore, oopsOffset);
        }
    }

    bool isThisTheScore(float distance, float checkDistance, int score, float positionOffset)
    {
        if (distance < checkDistance)
        {
            GameManager.instance.ChangeScore(score);
            float desiredPosition = previousCube.transform.position.x + positionOffset  * Mathf.Sign(previousCube.transform.position.x - activeCube.transform.position.x);
            activeCube.transform.position = new Vector3(desiredPosition, activeCube.transform.position.y, activeCube.transform.position.z);
            return true;
        }
        else return false;
    }

    bool IsLanded()
    {
        return activeCube.GetComponent<CubeScript>().isLanded;            
    }

    void Oscillate()
    {
        Vector3 horizontal = new Vector3(Mathf.Cos(Time.time * frequency) * Time.deltaTime * magnitude, 0, 0);
        transform.position += horizontal;
    }
}
