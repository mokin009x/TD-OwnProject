using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class Weapon : MonoBehaviour
{
    /// <summary>
    ///     takes care of what the weapon you are holding can do and it also takes care of waht guns exist
    /// </summary>

    //variables
    public bool InGameScene;

// current weapon
    public GameObject CurrentWeapon;
    public GameObject CurrentWeaponBullet;
    public Transform CurrentBulletExitPoint;
    public GameObject WeaponBullet;
    public int WeaponDmg;
    public int CurrentClipsize;
    public int CurrentAmountOfBullets;
    public float FireRate = 0f;


    //Slot 1
    public GameObject WeaponSlot1Obj;
    public GameObject Slot1Bullet;
    public Transform WeaponExit1;
    public int Slot1Clipsize;
    public int Slot1AmountOfBullets;
    public float Slot1FireRate;
    //slot 2
    public GameObject WeaponSlot2Obj;
    public GameObject Slot2Bullet;
    public Transform WeaponExit2;
    public int Slot2Clipsize;
    public int Slot2AmountOfBullets;
    public float Slot2FireRate;

    //managers references
    public PlayerManager PlayerManager;

    // Weapon Scripts that have all the variables for said weapon 
    public AsaultRifle asaultRifle;
    public Sniper sniper;
    

    // Use this for initialization
    private void Awake()
    {
       
    }

    private void Start()
    {
        //thread
       
        

        PlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        asaultRifle = GameObject.Find("WeaponManager+Weapons").GetComponent<AsaultRifle>();
        sniper = GameObject.Find("WeaponManager+Weapons").GetComponent<Sniper>();
    }

    // Update is called once per frame

    /// <summary>
    ///     Input for selecting loadout substitute
    /// </summary>

        //happens Before GameScene (For Quick testing it does not)
    private void Update()
    {
       
        // button for selecting AsaultRifle
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetAsaultRifle();

        }
        // button for selecting sniper

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            // temporary substitute for selecting weapons input
            SetSniperRifle();

        }

        // FireRate timer
        if (FireRate > 0)
        {
            FireRate = FireRate - Time.deltaTime;

        }


       Debug.Log("===========" + "Frame" + "===========");

    }

    void SetAsaultRifle()
    {
        if (WeaponSlot1Obj == null)
        {
            WeaponSlot1Obj = asaultRifle.WeaponObj;
            Slot1Bullet = asaultRifle.Bullet;
            Slot1Clipsize = asaultRifle.ClipSize;
            Slot1AmountOfBullets = Slot1Clipsize;
            Slot1FireRate = asaultRifle.FireRate;
            
        }
        else
        {
            WeaponSlot2Obj = asaultRifle.WeaponObj;
            Slot2Bullet = asaultRifle.Bullet;
            Slot2Clipsize = asaultRifle.ClipSize;
            Slot2AmountOfBullets = Slot2Clipsize;
            Slot2FireRate = asaultRifle.FireRate;

        }
        Debug.Log(WeaponSlot1Obj);
        
    }

    void SetSniperRifle()
    {
        if (WeaponSlot1Obj == null)
        {
            WeaponSlot1Obj = sniper.WeaponObj;
            Slot1Bullet = sniper.Bullet;
            Slot1Clipsize = sniper.ClipSize;
            Slot1AmountOfBullets = Slot1Clipsize;
            Slot1FireRate = sniper.FireRate;
        }
        else
        {
            WeaponSlot2Obj = sniper.WeaponObj;
            Slot2Bullet = sniper.Bullet;
            Slot2Clipsize = sniper.ClipSize;
            Slot2AmountOfBullets = Slot1Clipsize;
            Slot2FireRate = sniper.FireRate;

        }
        Debug.Log(WeaponSlot2Obj);
    }
    

    // this is later going to Move to the start of active game Scene
    

    public void FireBullet( )
    {
        while (FireRate <= 0)
        {

       
            Instantiate(CurrentWeaponBullet, CurrentBulletExitPoint.transform.position, GameObject.Find("Player/Player Camera").GetComponent<Transform>().rotation);
            FireRate = PlayerManager.SelectedWeaponFireRate;
            Debug.Log("fired");

        }






    }
}