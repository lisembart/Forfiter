using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D playerRigidbody;

    [Header("Player Parameters")]
    public float movementSpeed;
    public int currentFoodType;
    /*Types of Food:
     * 1 - Chicken
     * 2 - Steak
     * 3 - Fish */

    [Header("Food Types Sprites")]
    public Sprite chicken;
    public Sprite steak;
    public Sprite fish;
    public SpriteRenderer foodTypeSpriteRenderer;

    [Header("Animations/Sprites")]
    public SpriteRenderer playerSpriteRenderer;
    public Sprite aligatorIdle;
    public Sprite aligatorEating;

    public bool leftButtonPressed = false;
    public bool rightButtonPressed = false;
    bool switchButtonPressed = false;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        currentFoodType = 1;   
        foodTypeSpriteRenderer.sprite = chicken;
        playerSpriteRenderer.sprite = aligatorIdle;
    }
	
	void Update ()
    {  
        if (rightButtonPressed)
        {
            transform.Translate(Vector2.right * movementSpeed);
        } else if (leftButtonPressed)
        {
            transform.Translate(Vector2.left * movementSpeed);
        }
	}

    public void onPointerDownLeftButton()
    {
        leftButtonPressed = true;
    }   

    public void onPointerUpLeftButton()
    {
        leftButtonPressed = false;
    }   

    public void onPointerDownRightButton()
    {
        rightButtonPressed = true;
    }

    public void onPointerUpRightButton()
    {
        rightButtonPressed = false;
    }


    public void foodTypeSwitch()
    {
        switchButtonPressed = true;
        currentFoodType++;
        switch(currentFoodType)
        {
            case 1:
                foodTypeSpriteRenderer.sprite = chicken;
                break;
            case 2: 
                foodTypeSpriteRenderer.sprite = steak;
                break;
            case 3: 
                foodTypeSpriteRenderer.sprite = fish;
                break;
            case 4:
                currentFoodType = 1;
                foodTypeSpriteRenderer.sprite = chicken;
                break;
        } 
    }

    IEnumerator EatingAnimation()
    {
        playerSpriteRenderer.sprite = aligatorEating;
        yield return new WaitForSeconds(0.4f);
        playerSpriteRenderer.sprite = aligatorIdle;
    }

}
