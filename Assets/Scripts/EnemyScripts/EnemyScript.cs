using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //this script keeps references to all scripts belonging to specified prefab this script is attached to;
    public float Hp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Death();
	}

    public void Death()
    {
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
