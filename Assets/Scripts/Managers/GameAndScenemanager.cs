﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAndScenemanager : MonoBehaviour {
    //StartSceneStuff
    public GameObject[] StartSceneStates;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {

        }
    }

    //Buttons for StartScreen al the way to the level Selection
    public void PlayButton()
    {

       StartSceneStates[0].SetActive(false);
       StartSceneStates[1].SetActive(true);

    }

    public void World1Button()
    {
        SceneManager.LoadScene("1");
    }
}
