﻿using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    
/// <summary>
/// alles wat de player object moet weten en kunnen doen 
/// </summary>

    //private Plane[] _planes;

    [SerializeField] private float _rotX;
    [SerializeField] private float _rotY;


    public GameObject CameraPlayerObj;
    public GameObject WeaponParent;
    public GameObject WeaponInstance;
    public GameObject WeaponBullet;
    public float Cameraspeed;
    private Transform Weaponpos;
   [HideInInspector] public Weapon WeaponManager;
    private GameObject SpawnedWeapon;
    public bool ShowWeapOnStart =false;
    public bool GameStarted = true;



    public int SelectedWeapon;


    

    private void Awake()
    {
        

    }


  
   

    // Use this for initialization
    private void Start()
    {
        WeaponManager = GameObject.Find("WeaponManager+Weapons").GetComponent<Weapon>();
        Weaponpos = GameObject.Find("Player/Player Camera/Weaponpos").GetComponent<Transform>();
        SelectedWeapon = 1;

    }

    public void DebugTest()
    {
        Debug.Log("ye");
    }

    
    // Update is called once per frame
    private void Update()
    {
        ShowWeaponOnStart();



        _rotY += Input.GetAxis("Mouse X") * Cameraspeed * Time.deltaTime;
        _rotX -= Input.GetAxis("Mouse Y") * Cameraspeed * Time.deltaTime;
        
        
        _rotX = Mathf.Clamp(_rotX, -90, 90);


        CameraPlayerObj.transform.rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.rotation = Quaternion.Euler(0f, _rotY, 0f);


        if (Input.GetKeyDown(KeyCode.P)) Debug.Log(CameraPlayerObj.transform.rotation.x);

        if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0, 5 * Time.deltaTime);

        if (Input.GetKey(KeyCode.A)) transform.Translate(-5 * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.S)) transform.Translate(0, 0, -5 * Time.deltaTime);

        if (Input.GetKey(KeyCode.D)) transform.Translate(5 * Time.deltaTime, 0, 0);
        
        



        if (Input.GetKeyDown(KeyCode.Mouse0)&& ShowWeapOnStart ==true)
        {
            WeaponManager.FireBullet();
        }
        //Switching weapons 

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            

            SelectedWeapon = 1;
            SwitchingWeapons();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedWeapon = 2;
            SwitchingWeapons();

        }
    }

    void ShowWeaponOnStart()
    {
        if (GameStarted == true)
        {
            if (WeaponManager.WeaponSlot1Obj != null && ShowWeapOnStart == false)
            {
                WeaponManager.CurrentWeapon = WeaponManager.WeaponSlot1Obj;
                WeaponInstance = WeaponManager.CurrentWeapon;


                SpawnedWeapon = Instantiate(WeaponInstance, Weaponpos.transform.position, CameraPlayerObj.transform.rotation);
                SpawnedWeapon.transform.SetParent(CameraPlayerObj.transform);
                
                ShowWeapOnStart = true;
            }
        }
        
    }

    // setting current weapon with Animation and actual switching models or prefabs
    public void SwitchingWeapons()
    {
        //weapon.asaultrifle.model bijv.
        if (SpawnedWeapon == null)
        {
            switch (SelectedWeapon)
            {
                case 1:
                    WeaponManager.CurrentWeapon = WeaponManager.WeaponSlot1Obj;
                    WeaponManager.CurrentWeaponBullet = WeaponManager.Slot1Bullet;
                    WeaponInstance = WeaponManager.CurrentWeapon;
                    
                    

                    break;
                case 2:
                    WeaponManager.CurrentWeapon = WeaponManager.WeaponSlot2Obj;
                    WeaponManager.CurrentWeaponBullet = WeaponManager.Slot2Bullet;
                    WeaponInstance = WeaponManager.CurrentWeapon;

                    break;
            }
           SpawnedWeapon= Instantiate(WeaponInstance, Weaponpos.transform.position, CameraPlayerObj.transform.rotation);
            SpawnedWeapon.transform.SetParent(CameraPlayerObj.transform);
            switch (SelectedWeapon)
            {
                case 1:
                    WeaponManager.WeaponExit1 = SpawnedWeapon.GetComponentInChildren<Transform>();
                    WeaponManager.CurrentBulletExitPoint = WeaponManager.WeaponExit1;


                    break;
                case 2:
                    WeaponManager.WeaponExit2 = SpawnedWeapon.GetComponentInChildren<Transform>();
                    WeaponManager.CurrentBulletExitPoint = WeaponManager.WeaponExit2;



                    break;
            }
        }
        else
        {
            Destroy(SpawnedWeapon);
            SpawnedWeapon = null;
            SwitchingWeapons();
        }
    }

    // shooting current weapon
    

    public void Reload()
    {
    }
}