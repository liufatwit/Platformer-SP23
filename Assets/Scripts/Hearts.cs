using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    private int health;

    public ParticleSystem hearts;
    private float maxLifeTime = 5;
    public float lifeTimeCoolDown = 5;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeCoolDown -= Time.deltaTime;
        if(lifeTimeCoolDown < 0)
        {
            this.gameObject.SetActive(false);
            lifeTimeCoolDown = maxLifeTime;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //add player health
            GameObject go = collision.gameObject;
            PlayerPlatformerController player = go.GetComponent<PlayerPlatformerController>();

            //player.addHealth(health);

            Instantiate(hearts, this.transform.position, Quaternion.identity);

            //remove the hearts from the scene
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

}
