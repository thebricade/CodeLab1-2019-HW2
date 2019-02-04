using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlower : MonoBehaviour
{
    public int score = 0;
    public GameObject currentPlayer;
    public float playerX;
    public float playerY; 
    
    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = GameObject.FindWithTag("Player");
        InvokeRepeating("Spawn",1,1);
        
    }

    // Update is called once per frame
    void Update()
    {
        checkScore();
    }

    void Spawn()
    {
        GameObject newFlower = Instantiate(Resources.Load<GameObject>("Prefabs/Flower"));
        newFlower.transform.position = new Vector2(Random.Range(-10,10),Random.Range(-5,5));
       
    }

    void checkScore()
    {
        if (score >= 5)
        {
            playerX = currentPlayer.transform.position.x;
            playerY = currentPlayer.transform.position.y;
            Invoke("SpawnDeathFlowers",0.5f);
            Destroy(currentPlayer);
            //object.Destroy(GameObject.FindWithTag("Player"));
            score = 0;
            Invoke("SpawnPlayer", 5);
        }
    }

    void SpawnPlayer()
    {
        GameObject newPlayer = Instantiate(Resources.Load<GameObject>("Prefabs/Player1"));
        currentPlayer = GameObject.FindWithTag("Player");
    }

    void SpawnDeathFlowers()
    {
        GameObject deathFlower1 = Instantiate(Resources.Load<GameObject>("Prefabs/deathFlower"));
        deathFlower1.transform.position = new Vector2(Random.Range(playerX-2,playerX+2), Random.Range(playerY-2,playerY+2));
        
    }
}
