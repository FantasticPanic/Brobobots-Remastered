using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public int scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			SceneManager.LoadScene (scene); //"Test_2017", LoadSceneMode.Single

		}
	}

//	public void LoadByIndex(int sceneIndex){
//		SceneManager.LoadScene (sceneIndex);
//	}
}
