using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifleBullet : MonoBehaviour {

    private Vector3 Target;
    private Vector3 Origin;
    private Vector3 BulletDirection;
    private float BulletSpeed = 1;
    private float Dmg = 5;




    // Use this for initialization
    void Start()
    {
        Origin = transform.position;
        Target = Vector3.forward + Origin;
        BulletDirection = Vector3.forward;
        BulletDirection.Normalize();
        BulletDirection = Target - Origin;
        //Debug.Log(Origin);
        //Debug.Log(Target);
        //Debug.Log(BulletDirection);
    }

    // Update is called once per frame
    void Update()
    {
        move();


    }

    private void OnCollisionEnter(Collision Coll)
    {
        if (Coll.gameObject.CompareTag("Enemy"))
        {
            var collidedObj = Coll.gameObject.GetComponent<Enemy>();
            collidedObj.Hp = collidedObj.Hp - Dmg;
            Debug.Log("hit");
            Destroy(this.gameObject);

        }

    }

    public void move()
    {
        transform.Translate(BulletDirection * BulletSpeed * Time.deltaTime);

    }
}
