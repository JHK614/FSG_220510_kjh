using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Enemy"){
            Logics.Instance.Destroyplayer();
        }
    }
}
