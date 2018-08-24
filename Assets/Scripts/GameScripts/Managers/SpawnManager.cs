using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [Header("Food Prefabs")]
    public GameObject kurczak;
    public GameObject stek;
    public GameObject ryba;

    List<GameObject> foodList = new List<GameObject>(); 

    [Header("Spawnpoints")]
    public Rigidbody2D spawnPoint1rgbd;
    public Vector3 spawnPoint1;

    public Rigidbody2D spawnPoint2rgbd;
    public Vector3 spawnPoint2;

    public Rigidbody2D spawnPoint3rgbd;
    public Vector3 spawnPoint3;

    public Rigidbody2D spawnPoint4rgbd;
    public Vector3 spawnPoint4;

    [Header("")]
    public Vector3 currentSpawnPoint;

    [Header("")]
    public float timeBetweenFoodSpawns;
    private float timeBetweenSpawns;
    public float timeToStart;

    void Start ()
    {
        foodList.Add(kurczak);
        foodList.Add(stek);
        foodList.Add(ryba);
        StartCoroutine("FoodSpawning");
	}

	void Update ()
    {
        spawnPoint1 = new Vector3(spawnPoint1rgbd.position.x, spawnPoint1rgbd.position.y, 0);
        spawnPoint2 = new Vector3(spawnPoint2rgbd.position.x, spawnPoint2rgbd.position.y, 0);
        spawnPoint3 = new Vector3(spawnPoint3rgbd.position.x, spawnPoint3rgbd.position.y, 0);
        spawnPoint4 = new Vector3(spawnPoint4rgbd.position.x, spawnPoint4rgbd.position.y, 0);
    }

    IEnumerator FoodSpawning()
    {
        yield return new WaitForSeconds(timeToStart);
        for (;;)
        {
            int foodIndex = Random.Range(0, 3);

            int spawnPointIndex = Random.Range(0, 4);

            float timeBetweenSpawns = timeBetweenFoodSpawns;

            if (spawnPointIndex == 0)
            {
                currentSpawnPoint = spawnPoint1;
            }
            else if (spawnPointIndex == 1)
            {
                currentSpawnPoint = spawnPoint2;
            }
            else if (spawnPointIndex == 2)
            {
                currentSpawnPoint = spawnPoint3;
            }
            else if(spawnPointIndex == 3)
            {
                currentSpawnPoint = spawnPoint4;
            }

            timeBetweenSpawns = timeBetweenFoodSpawns;

            yield return new WaitForSeconds(timeBetweenSpawns);
            
            Instantiate(foodList[foodIndex], currentSpawnPoint, transform.rotation);
        }
    }
}
