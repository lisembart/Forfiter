using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroyer : MonoBehaviour 
{
    GameManager gameManager;
    SoundsManager soundsManager;
    PlayerController playerController;
    public int foodType;

	void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        soundsManager = FindObjectOfType<SoundsManager>();
        playerController = FindObjectOfType<PlayerController>();
	}
	
	void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "FoodDestroyer")
        {
            soundsManager.PlayLoseEatSound();
            gameManager.currentMissedFood++;
            Destroy(this.gameObject);
        }
        
        else if(col.gameObject.tag == "Hero" && playerController.currentFoodType == foodType)
        {
            soundsManager.PlayEatSound();
            playerController.StartCoroutine("EatingAnimation");
            gameManager.currentScore++;
            Destroy(this.gameObject);
        }

        else if(col.gameObject.tag == "Hero" && playerController.currentFoodType != foodType)
        {
            gameManager.currentMissedFood++;
            Destroy(this.gameObject);
        }
    }
}
