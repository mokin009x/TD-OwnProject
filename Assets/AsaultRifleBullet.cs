using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsaultRifleBullet : MonoBehaviour
{
    private Vector3 Target;
    private Vector3 Origin;
    private Vector3 BulletDirection;
    private float BulletSpeed;
    
    


    // Use this for initialization
    void Start ()
    {
        Origin = transform.position;
        Target = Vector3.forward + Origin;
        BulletSpeed = 1;
        BulletDirection = Vector3.forward;
        BulletDirection.Normalize();
        BulletDirection = Target - Origin ;
Debug.Log(Origin);
        Debug.Log(Target);
        Debug.Log(BulletDirection);
    }

    // Update is called once per frame
    void Update ()
    {
        move();
        

    }
    
    

    public void move()
    {
        transform.Translate(BulletDirection * BulletSpeed*Time.deltaTime); 
    }
}
