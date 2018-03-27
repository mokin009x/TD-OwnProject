using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public List<GameObject> CurrentWaveEnemys;
    public GameObject[] EnemyTypes;// with unmodified stats
    public GameObject thingy;
    public int WorldLevel;
    public Transform EnemySpawnPoints;

    //Enemy types
   
    // Use this for initialization

    private void Awake()
    {
        
    }

    

    private void Start()
    {
        
        WL1Wave1();
    }
    // WorldLevel 1
    public void WL1Wave1()
    {
        if (CurrentWaveEnemys !=null)
        {
           CurrentWaveEnemys.Clear();
            
                AddingType1(5);
                AddingType2(5);
            
        }
        else
        {
           
                AddingType1(5);
                AddingType2(5);


        }



    }
    //AddingEnemy to list
    public void AddingType1(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            thingy = EnemyTypes[0];

            CurrentWaveEnemys.Add(thingy);
        }
      
    }

    public void AddingType2(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            thingy = EnemyTypes[1];

            CurrentWaveEnemys.Add(thingy);
        }
    }

    void SpawnCurrentWave()
    {
        for (int i = 0; i < CurrentWaveEnemys.Count; i++)
        {
            Instantiate(CurrentWaveEnemys[i], EnemySpawnPoints.transform.position, Quaternion.identity);

        }
    }

    // Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        SpawnCurrentWave();
	    }
    }
}
