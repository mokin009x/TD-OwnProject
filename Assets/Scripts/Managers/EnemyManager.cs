using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public List<GameObject> CurrentWave;
    public List<List<GameObject>> Waves;
    public GameObject Type1;
    public GameObject Type2;
    public int WorldLevel;
    public Transform[] SpawnPointsWave1;
    public Transform[] SpawnPointsWave2;

    //Enemy types

    // Use this for initialization

    private void Awake()
    {
        Waves = new List<List<GameObject>>();
    }

    

    private void Start()
    {
        
    }
   
    //AddingEnemy to list

  public List<GameObject> NormalWave(int enemyType,int amountOfEnemys)
   {
       List<GameObject> test = new List<GameObject>();
       switch (enemyType)
       {
            case 1:
                AddingType1(amountOfEnemys,test);
            break;

            case 2:
               AddingType2(amountOfEnemys,test);
            break;
       }
       
       return test;
   }

    public void AddingType2(int amount,List<GameObject> theWave)
    {
        for (int i = 0; i < amount; i++)
        {
           theWave.Add(Type2); 
        }
    }

    public void AddingType1(int amount,List<GameObject> theWave)
    {
        for (int i = 0; i < amount; i++)
        {
            theWave.Add(Type1);
        }
    }

    //World 1 level 1 waves

    void World1Level1Waves()
    {
        Waves.Add(NormalWave(1, 5));
        Waves.Add(NormalWave(2, 20));

    }
    //Spawning the wave
    void SpawnWorld1Level1Waves()
    {
        for (int i = 0; i < Waves.Count; i++)
        {
            for (int j = 0; j < Waves[i].Count; j++)
            {
                Instantiate(Waves[i][j],SpawnPointsWave1[Random.Range(0,SpawnPointsWave1.Length)]);
            }

        }
    }

    // Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        World1Level1Waves();

            SpawnWorld1Level1Waves();
	    }
    }
}
