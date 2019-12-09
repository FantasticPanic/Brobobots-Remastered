using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour {

	float timeLeft = 120f;
	float flashTime;

	public Text text;

	public int scene;

	public bool count;

	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f); 

	// Use this for initialization
	void Start () {
		count = false;

		flashTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKey (KeyCode.P)) {
//			count = true;
//		}

		if (count) {
			timeLeft -= Time.deltaTime;
			flashTime += Time.deltaTime;

			text.text = "Self Destruct in: " + Mathf.Round (timeLeft)+"s";

			text.color = Color.red;



			if (timeLeft < 0) {
				SceneManager.LoadScene (scene);
			}
		}
		
	}


}
