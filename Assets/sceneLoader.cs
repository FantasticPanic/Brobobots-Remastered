using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour {

	//public string sceneName;
//	public const float TIME_LIMIT;// = 26F;
	public float TIME_LIMIT;
	public string scene;
	public int sceneIndex;
	private float timer = 0F;

	void Start () {
	}

	void Update () {
	this.timer += Time.deltaTime;
		print (timer);

	if (this.timer >= TIME_LIMIT) {
//			SceneManager.LoadScene ("Tutorial_V2");
			SceneManager.LoadScene(sceneIndex);
		}
	}
}
