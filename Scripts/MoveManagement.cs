using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManagement : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    public Sprite[] mySprites;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(TurnCoRoutine());
    }

    IEnumerator TurnCoRoutine(){
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if(index == 5){
            index = 0;
        }
        StartCoroutine(TurnCoRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
