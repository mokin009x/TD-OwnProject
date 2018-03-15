using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAndScenemanager : MonoBehaviour {
    //StartSceneStuff
    public GameObject[] StartSceneStates;

    private List<Enemy> CurrentWaveEnemys;
    public Enemy EnemyReference;
    private List<Enemy> EnemyTypes ;
	// Use this for initialization
	void Start () {
	    

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {

        }
    }

    void Wave1()
    {
        //Enemys.Add(new Enemy());
    }

    //Buttons for StartScreen al the way to the level Selection
    public void PlayButton()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            StartSceneStates[0].SetActive(false);
            StartSceneStates[1].SetActive(true);

        }

    }

    public void World1Button()
    {
        SceneManager.LoadScene("1");
    }
}
