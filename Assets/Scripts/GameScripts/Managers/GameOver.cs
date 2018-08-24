using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("Necessary Components")]
    public Text currentScoreText;
    public Text bestScoreText;
    private GameManager gameManager;
    private AdManager adManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        adManager = FindObjectOfType<AdManager>();
    }

    void Start()
    {
        currentScoreText.text = ("YOUR SCORE:  " + gameManager.currentScore.ToString());
        bestScoreText.text = ("BEST SCORE:  " + gameManager.bestScore.ToString());
        adManager.ShowBannerGameOver();
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
