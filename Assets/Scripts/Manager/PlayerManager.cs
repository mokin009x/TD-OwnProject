using System.Collections.Generic;
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
    public GameObject Weapon;
    public float Cameraspeed;
    private Transform Weaponpos;
   [HideInInspector] public Weapon WeaponManager;
    private GameObject SpawnedWeapon;
    
    
    

    
    public int SelectedWeapon;


    

    private void Awake()
    {
        

    }


  
   

    // Use this for initialization
    private void Start()
    {
        WeaponManager = GameObject.Find("WeaponManager+Weapons").GetComponent<Weapon>();
        Weaponpos = GameObject.Find("Player/Weaponpos").GetComponent<Transform>();

    }

    public void DebugTest()
    {
        Debug.Log("ye");
    }

    
    // Update is called once per frame
    private void Update()
    {
       
        ////calculating bounds of in this case camera
        //Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);


        //// a preset for checking if something is in camera view
        //if ()
        //{

        //    if (GeometryUtility.TestPlanesAABB(planes, spijkerSchilderij_1_coll.bounds))
        //    {


        //    }

        //    if (!GeometryUtility.TestPlanesAABB(planes, spijkerSchilderij_1_coll.bounds))
        //    {


        //    }
        //}


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
        
        



        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

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

    // setting current weapon with Animation and actual switching models or prefabs
    public void SwitchingWeapons()
    {
        //weapon.asaultrifle.model bijv.
        if (SpawnedWeapon == null)
        {
            switch (SelectedWeapon)
            {
                case 1:
                    Weapon = WeaponManager.LoadoutWeaponSlot1;
                    Debug.Log(SelectedWeapon);
                    break;
                case 2:
                    Weapon = WeaponManager.LoadoutWeaponSlot2;
                    break;
            }
           SpawnedWeapon= Instantiate(Weapon, Weaponpos.transform.position, Quaternion.identity);
        }
        else
        {
            Destroy(SpawnedWeapon);
            SpawnedWeapon = null;
            SwitchingWeapons();
        }
    }

    // shooting current weapon
    public void Fire()
    {
    }

    public void Reload()
    {
    }
}