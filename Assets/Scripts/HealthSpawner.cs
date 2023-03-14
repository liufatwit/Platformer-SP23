using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject[] hearts;

    private float timeBetweenSpawns;
    public float minSpawnTime;
    public float maxSpawnTime;
    public float decreaseAmount;

    private float spawnTimer;
    public ObjectPooler heartPool;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GameManager.instance().gameOverCanvas.gameObject.activeSelf)
        {
            return;
        }*/
        if (spawnTimer <= 0)
        {
            GameObject heart = hearts[Random.Range(0, hearts.Length)];
            float xPos = Random.Range(-13.9f, 16.41f);
            float yPos = Random.Range(-4f, 3.5f);

            Vector3 location = new Vector3(xPos, yPos, 0f);

            GameObject go = heartPool.GetPooledObject();
            go.transform.position = location;
            go.SetActive(true);
            //Instantiate(heart, location, Quaternion.identity);


            timeBetweenSpawns -= decreaseAmount;

            if (timeBetweenSpawns < minSpawnTime)
            {
                timeBetweenSpawns = minSpawnTime;
            }

            spawnTimer = timeBetweenSpawns;
        }
        else
        {
            spawnTimer -= Time.deltaTime;

        }
    }
    public void Reset()
    {
        timeBetweenSpawns = maxSpawnTime;
        spawnTimer = timeBetweenSpawns;
    }
}
