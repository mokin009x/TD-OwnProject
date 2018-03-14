using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    ///     takes care of what the weapon you are holding can do and it also takes care of waht guns exist
    /// </summary>
   

    public bool InGameScene;

    public int LoadOutWeapons;

    //Loadout 1
    public GameObject CurrentWeapon;
    public GameObject CurrentWeaponBullet;
    public Transform CurrentBulletExitPoint;
    public GameObject WeaponSlot1Obj;
    public GameObject WeaponSlot2Obj;
    public GameObject Slot1Bullet;
    public GameObject Slot2Bullet;
    public Transform WeaponExit1;
    public Transform WeaponExit2;
    public PlayerManager PlayerManager;
    public AsaultRifle asaultRifle;
    public Sniper sniper;
    public GameObject WeaponBullet;
    public int WeaponDmg;
    public List<Weapon> WeaponLoadout = new List<Weapon>();


    // Use this for initialization
    private void Awake()
    {
       
    }

    private void Start()
    {
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
    }

    void SetAsaultRifle()
    {
        if (WeaponSlot1Obj == null)
        {
            WeaponSlot1Obj = asaultRifle.WeaponObj;
            Slot1Bullet = asaultRifle.Bullet;
            WeaponExit1 = asaultRifle.BulletExitPoint;

        }
        else
        {
            WeaponSlot2Obj = asaultRifle.WeaponObj;
            Slot2Bullet = asaultRifle.Bullet;
            WeaponExit2 = asaultRifle.BulletExitPoint;

        }
        Debug.Log(WeaponSlot1Obj);
    }

    void SetSniperRifle()
    {
        if (WeaponSlot1Obj == null)
        {
            WeaponSlot1Obj = sniper.WeaponObj;
            Slot1Bullet = sniper.Bullet;
            WeaponExit1 = sniper.BulletExitPoint;

        }
        else
        {
            WeaponSlot2Obj = sniper.WeaponObj;
            Slot2Bullet = sniper.Bullet;
            WeaponExit2 = sniper.BulletExitPoint;

        }
        Debug.Log(WeaponSlot2Obj);
    }
    

    // this is later going to move to the start of active game Scene

    public void FireBullet()
    {
        var bulletrotation =  GameObject.Find("Player/Player Camera").GetComponent<Transform>();

        Instantiate(CurrentWeaponBullet, CurrentBulletExitPoint.transform.position,bulletrotation.rotation );
    }
}