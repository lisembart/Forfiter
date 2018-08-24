using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    public float fallSpeed;
    private Rigidbody2D rgbd;

	void Start ()
    {
        rgbd = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
	}
}
