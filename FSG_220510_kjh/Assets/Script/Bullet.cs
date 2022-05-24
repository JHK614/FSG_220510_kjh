using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void LateUpdate()
    {
        if (this.transform.position.y >= 15f) this.gameObject.SetActive(false);
    }
}
