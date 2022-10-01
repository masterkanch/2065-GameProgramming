using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{
   private void Awake(){
    DontDestroyOnLoad(gameObject);
   }
}
