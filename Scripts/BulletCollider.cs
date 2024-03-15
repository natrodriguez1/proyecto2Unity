using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    private Rigidbody2D myrigidbody2D;
    public float bulletSpeed = 10f;
    public GameManager myGameManager;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.velocity = new Vector2(bulletSpeed, myrigidbody2D.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("goodItem")){
            Destroy(collision.gameObject);
        }else if(collision.CompareTag("badItem")){
            myGameManager.AddScore();
            Destroy(collision.gameObject);
        }
    }
}
