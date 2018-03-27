using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour {

    // this is a weapon
    public GameObject WeaponObj;
    public GameObject Bullet;
    public int ClipSize;
    public float FireRate;




    // Use this for initialization
    void Start()
    {
        
    }
    private void Awake()
    {
        FireRate = 1f;
        ClipSize = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

  
}
