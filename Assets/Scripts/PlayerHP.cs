using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int initialHealth;
    public int health;
    public Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < -10f)
        {
            health = 0;
        }

        else if (health <= 0)
        {
            Destroy(gameObject);
            //FindObjectOfType<GameManager>().EndGame();
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player takes damage!");
    }
}
