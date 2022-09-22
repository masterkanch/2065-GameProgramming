using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
     
    [SerializeField] private SoCollectible collectibleObject;
    [SerializeField] private EnableObject enableObject;
    public void Start(){

    }
    private void OnTriggerEnter2D(Collider2D col){
        gameObject.SetActive(false);
        Debug.Log(collectibleObject.name);
        
    }

    private void OnDisable(){
        enableObject.Enableobject4s();
    }

    

}
