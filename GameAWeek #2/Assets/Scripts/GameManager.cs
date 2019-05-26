using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager instance;

    private int score = 0;
    private bool outOfBounds = false;

    #region Singleton

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one GameManager instance!");
            return;
        }
        instance = this;
    }

    #endregion

    
    void Start()
    {
        outOfBounds = false;
    }

    void Update()
    {
        if (outOfBounds)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        //TODO:
        Debug.Log("You Dead");
    }

    public void OutOfBounds()
    {
        outOfBounds = true;
    }

    public void ChangeScore(int value)
    {
        score += value;
        Debug.Log("The Score is: " + score);
    }
}
