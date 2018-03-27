using System.Collections.Generic;
using UnityEngine;
using System.Threading;
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
    public float SelectedWeaponFireRate;
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
        Cursor.lockState = CursorLockMode.Locked;


    }

    public void DebugTest()
    {
        Debug.Log("ye");
    }

    
    // Update is called once per frame
    private void Update()
    {
        // may need to change location of ShowWeaponOnStart
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




        if (Input.GetKey(KeyCode.Mouse0))
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
                WeaponManager.CurrentWeaponBullet = WeaponManager.Slot1Bullet;

                SpawnedWeapon = Instantiate(WeaponInstance, Weaponpos.transform.position, CameraPlayerObj.transform.rotation);
                SpawnedWeapon.transform.SetParent(CameraPlayerObj.transform);
                WeaponManager.WeaponExit1 = SpawnedWeapon.GetComponentInChildren<Transform>();
                WeaponManager.CurrentBulletExitPoint = WeaponManager.WeaponExit1;
                WeaponManager.CurrentClipsize = WeaponManager.Slot1Clipsize;
                WeaponManager.CurrentAmountOfBullets = WeaponManager.Slot1AmountOfBullets;
                SelectedWeaponFireRate = WeaponManager.Slot1FireRate;
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

            // Switching weapon visually (could be combined with animation if I had one)
            switch (SelectedWeapon)
            {
                case 1:
                    WeaponManager.CurrentWeapon = WeaponManager.WeaponSlot1Obj;
                    WeaponManager.CurrentWeaponBullet = WeaponManager.Slot1Bullet;
                    WeaponManager.CurrentClipsize = WeaponManager.Slot1Clipsize;
                    WeaponManager.CurrentAmountOfBullets = WeaponManager.Slot1AmountOfBullets;
                    SelectedWeaponFireRate = WeaponManager.Slot1FireRate;
                    WeaponInstance = WeaponManager.CurrentWeapon;
                    SpawnedWeapon = Instantiate(WeaponInstance, Weaponpos.transform.position, CameraPlayerObj.transform.rotation);
                    SpawnedWeapon.transform.SetParent(CameraPlayerObj.transform);
                    WeaponManager.WeaponExit1 = SpawnedWeapon.GetComponentInChildren<Transform>();
                    WeaponManager.CurrentBulletExitPoint = WeaponManager.WeaponExit1;


                    break;
                case 2:
                    WeaponManager.CurrentWeapon = WeaponManager.WeaponSlot2Obj;
                    WeaponManager.CurrentWeaponBullet = WeaponManager.Slot2Bullet;
                    WeaponManager.CurrentClipsize = WeaponManager.Slot2Clipsize;
                    WeaponManager.CurrentAmountOfBullets = WeaponManager.Slot2AmountOfBullets;
                    SelectedWeaponFireRate = WeaponManager.Slot2FireRate;
                    WeaponInstance = WeaponManager.CurrentWeapon;
                    SpawnedWeapon = Instantiate(WeaponInstance, Weaponpos.transform.position, CameraPlayerObj.transform.rotation);
                    SpawnedWeapon.transform.SetParent(CameraPlayerObj.transform);
                    WeaponManager.WeaponExit2 = SpawnedWeapon.GetComponentInChildren<Transform>();
                    WeaponManager.CurrentBulletExitPoint = WeaponManager.WeaponExit2;
                    break;
            }

            // setting the Exitpoint for the bullets 
          
          
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