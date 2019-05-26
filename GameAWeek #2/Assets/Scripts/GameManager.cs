using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager instance;

    public int score = 0;
    private bool outOfBounds = false;

    public bool GAMEISOVER = false;

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

        if (GAMEISOVER)
        {
            if (Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Reloading");
            }
        }
    }

    void GameOver()
    {
        GAMEISOVER = true;
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
