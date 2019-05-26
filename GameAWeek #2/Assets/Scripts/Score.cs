using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    public GameObject gameOver;


    private void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();

        if (GameManager.instance.GAMEISOVER)
        {
            gameOver.SetActive(true);
        }
    }
}
