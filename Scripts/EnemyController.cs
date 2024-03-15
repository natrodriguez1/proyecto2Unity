using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
    }

     void Update()
    {
        //myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);
    }

    // Update is called once per frame
    IEnumerator WalkCoRoutine(){
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if(index == mySprites.Length){
            index = 0;
        }
        StartCoroutine(WalkCoRoutine());
    }
}
