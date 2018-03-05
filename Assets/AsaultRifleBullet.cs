using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsaultRifleBullet : MonoBehaviour
{
    private Vector3 BulletDirection;
    private float BulletSpeed;
    


    // Use this for initialization
    void Start ()
    {
        BulletSpeed = 1;
        BulletDirection = Vector3.forward;
        BulletDirection.Normalize();
        BulletDirection = BulletDirection * BulletSpeed;
    }

    // Update is called once per frame
    void Update ()
    {
        move();


    }
    
    

    public void move()
    {
        transform.position = transform.position + BulletDirection;
    }
}
