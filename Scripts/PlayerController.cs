using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    public GameManager myGameManager; //score
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
        myGameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
        }
        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);
        if(Input.GetKeyDown(KeyCode.E)){
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("goodItem")){
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }else if(collision.CompareTag("badItem")){
            Destroy(collision.gameObject);
            PlayerDeath();
        } else if(collision.CompareTag("deathzone")){
            PlayerDeath();
        }
    }

    void PlayerDeath(){
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator WalkCoRoutine(){
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if(index == 4){
            index = 0;
        }
        StartCoroutine(WalkCoRoutine());
    }
}

