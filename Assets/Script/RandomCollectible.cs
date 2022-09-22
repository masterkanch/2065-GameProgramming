using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCollectible : MonoBehaviour
{
    [SerializeField] private Sprite[] CollectibleSprite = new Sprite[3];
    private int index;
    public enum CollectibleType{
    Green,
    Blue,
    Yellow
   }
   public CollectibleType CollectibleColor;

    void Start()
    {
        index = Random.Range(0, CollectibleSprite.Length);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = CollectibleSprite[index];
        if(index == 0){
            CollectibleColor = CollectibleType.Green; 
        }else if(index == 1){
            CollectibleColor = CollectibleType.Blue;
        }else if(index == 2){
            CollectibleColor = CollectibleType.Yellow;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col){
      gameObject.SetActive(false);
      switch(CollectibleColor){
        case CollectibleType.Green:
            col.GetComponent<SpriteRenderer>().color = Color.green;
            break;
        case CollectibleType.Blue:
            col.GetComponent<SpriteRenderer>().color = Color.blue;
            break;
        case CollectibleType.Yellow:
            col.GetComponent<SpriteRenderer>().color = Color.yellow;
            break;
        }
    }
}
