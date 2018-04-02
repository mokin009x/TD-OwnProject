using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsaultRifle : MonoBehaviour
{
    public GameObject WeaponObj;
    public GameObject Bullet;
    public int MagazineSize;
    public int BulletsInMagazine;

    public float FireRate;
	// Use this for initialization
	void Start ()
	{
	    
	}

    private void Awake()
    {
        FireRate = 0.1f;
        MagazineSize = 30;
    }

    // Update is called once per frame
	void Update () {
		
	}
}
