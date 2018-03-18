using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [HideInInspector] public float Hp = 1;

    public List<Enemy> EnemyTypes;
    public List<Transform> EnemySpawnPoints;

    public EnemyType1 EnemyNormal;
    //Enemy types
   
    // Use this for initialization

    private void Awake()
    {
    }


    // Update is called once per frame
	void Update () {
	    if (Hp <= 0)
	    {
	        Destroy(this.gameObject);
	    }
    }
}
