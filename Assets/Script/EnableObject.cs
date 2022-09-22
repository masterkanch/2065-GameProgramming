using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    [SerializeField] private GameObject collectible;
   
    public IEnumerator RespawnCollectible(){
        yield return new WaitForSeconds(4f);
        collectible.SetActive(true);
    }

    public void Enableobject4s(){
        StartCoroutine(RespawnCollectible());
    }
}
