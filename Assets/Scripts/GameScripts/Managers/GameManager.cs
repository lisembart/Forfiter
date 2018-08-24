using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Score Manager")]
    public int allowedMissedFood;
    public int currentMissedFood;
    public int currentScore;
    public int bestScore;
    public Text scoreText;

    [Header("Game Over")]
    public GameObject gameOverObject;
    public GameObject player;
    public GameObject gameCanvas;
    public GameObject spawnManager;
    public GameObject foodSpriteRenderer;

    void Awake ()
    {
        PlayerPrefs.GetInt("Best Score");
        bestScore = PlayerPrefs.GetInt("Best Score");
        gameOverObject.SetActive(false);
	}

    void Update ()
    {
        scoreText.text = currentScore.ToString();

        if(currentScore > bestScore)
        {
            PlayerPrefs.SetInt("Best Score", currentScore);
            bestScore = PlayerPrefs.GetInt("Best Score");
        }

        if(currentMissedFood >= allowedMissedFood)
        {
            player.SetActive(false);
            gameCanvas.SetActive(false);
            spawnManager.SetActive(false);
            foodSpriteRenderer.SetActive(false);
            if (GameObject.FindWithTag("Food") != null)
            {
                Destroy(GameObject.FindWithTag("Food"));
            }
            gameOverObject.SetActive(true);
        }
	}
}
