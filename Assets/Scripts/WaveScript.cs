using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameObject ourPlayer;
    public int damage;
    public float movSpeed;
    public GameObject wave;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wave.transform.position += new Vector3(movSpeed, 0, 0);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ourPlayer.GetComponent<PlayerHP>().TakeDamage(damage);
            Debug.Log("Wave reached the player");
        }
    }
}
