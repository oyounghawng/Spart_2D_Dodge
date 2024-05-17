using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15.0f;
    private void Update()
    {
        this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);    
    }
}
