using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    Enemies enemies;
    Manager manager;
    

    // Start is called before the first frame update
    void Start()
    {
        enemies = GetComponentInParent<Enemies>();
        manager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Manager>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            enemies.Initiate(enemies.midRow);
            manager.enemies = enemies.enemiesCount;
            manager.characters = other.GetComponentInParent<Controller>().noChilds;
            Destroy(gameObject);
        }
    }
}
