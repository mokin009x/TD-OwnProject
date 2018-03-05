using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    ///     takes care of what the weapon you are holding can do and it also takes care of waht guns exist
    /// </summary>
    public enum weapppp
    {
        AsaultRifle,
        Sniper
    }

    public int CurrentWeapon;
    public bool InGameScene;

    public int LoadOutWeapons;

    //Loadout 1
    public GameObject LoadoutWeaponSlot1;
    public GameObject LoadoutWeaponSlot2;
    [HideInInspector]public PlayerManager PlayerManager;
    public AsaultRifle AsaultRifle;
    public Sniper Sniper;
    public GameObject WeaponBullet;

    public Transform WeaponBulletExitPoint;
    public int WeaponDmg;
    public List<weapppp> WeaponLoadout = new List<weapppp>();


    // Use this for initialization
    private void Awake()
    {
       
    }

    private void Start()
    {
        PlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        AsaultRifle = GameObject.Find("WeaponManager+Weapons").GetComponent<AsaultRifle>();
        Sniper = GameObject.Find("WeaponManager+Weapons").GetComponent<Sniper>();
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
            LoadoutWeaponSlot1 = AsaultRifle.WeaponModel;
            Debug.Log(LoadoutWeaponSlot1);

        }
        // button for selecting Sniper

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            // temporary substitute for selecting weapons input
            LoadoutWeaponSlot2 = Sniper.WeaponModel;
            Debug.Log(LoadoutWeaponSlot2);

        }
    }

    // this is later going to move to the start of active game Scene

    public void FireBullet()
    {
        Debug.Log("test 2");

        Instantiate(WeaponBullet, WeaponBulletExitPoint.transform.position, Quaternion.identity);
    }
}