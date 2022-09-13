using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType{
    Green,
    Blue,
    Yellow
   }
   public CollectibleType CollectibleColor;
 
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
