using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour
{

    public GameObject GM;
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       //
        if (other.CompareTag("Player"))
        {
            GM.gameObject.GetComponent<SpawnFlower>().score++;         
        }

        Destroy(gameObject);
    }

   
}
