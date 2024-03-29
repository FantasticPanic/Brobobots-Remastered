﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScreen : MonoBehaviour {

	// Use this for initialization
    public static bool GameIsPaused = false;
    public GameObject addPausePanelHere;


    void Start() {
  
    }
    // Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
	}

    public void Resume() {
        addPausePanelHere.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    
    }

    public void Pause()
    {
        addPausePanelHere.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
