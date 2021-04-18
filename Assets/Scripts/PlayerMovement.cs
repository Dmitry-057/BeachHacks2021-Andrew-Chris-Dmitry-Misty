using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed;
    public float jumpSpeed;
    public GameObject ourPlayer;
    public Rigidbody2D rb2d;
    public bool inAir = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButton("Horizontal"))
        {
            ourPlayer.transform.position += new Vector3(movSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);

        }

        if (Input.GetButton("Jump") && !inAir)
        {
            rb2d.AddForce(new Vector2(0f, jumpSpeed));
            inAir = true;
            Debug.Log("In Air = true");
        }
        Debug.Log(ourPlayer.transform.position.y);
        if (ourPlayer.transform.position.y < -4.0f) {
            Debug.Log("exit test");
            Debug.Break();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            inAir = false;
            if (collision.gameObject.name.Contains("long-platform") /*|| collision.gameObject.name.Contains("starting")*/) {
                this.transform.parent = collision.transform;
            }
            Debug.Log("In Air = ");
        }
    }
}
