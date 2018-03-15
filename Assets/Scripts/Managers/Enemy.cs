using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp = 10;
    public GameObject[] EnemyObjects;
    private List<Enemy> EnemyTypes;
	// Use this for initialization
	

    private void Awake()
    {
        for (int i = 0; i < EnemyObjects.Length; i++)
        {
            EnemyTypes.Add(new Enemy(EnemyObjects[i]));

        }
    }

    public Enemy(GameObject EnemyObj)
    {
        
    }

    // Update is called once per frame
	void Update () {
        // Death
	    if (Hp <= 0)
	    {
	        Destroy(this.gameObject);
	    }
	}
}
