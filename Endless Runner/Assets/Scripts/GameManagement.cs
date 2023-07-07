using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    int score;
    public static GameManagement inst;

    [SerializeField] Text scoreText;
    [SerializeField] Text livesText;
    [SerializeField] Player_Movement playerMovement;
    int death;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    public void DecreaseLife()
    {
        playerMovement.lives--;
        livesText.text = "LIVES LEFT: " + playerMovement.lives;
        
    }

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start() {
        livesText.text = "LIVES LEFT: " + playerMovement.lives;
    }

    // Update is called once per frame
    void Update() { }
}