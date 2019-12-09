using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

	public int scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}


	void OnTriggerEnter(Collider other)
	{
//		if (Input.GetMouseButton (0)) {
		if (other.CompareTag("Dink") || other.CompareTag("Megapixel")){

			SceneManager.LoadScene (scene); //"Test_2017", LoadSceneMode.Single
		}
//		}


	}


}
