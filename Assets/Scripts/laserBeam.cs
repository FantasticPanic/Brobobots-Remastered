using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBeam : MonoBehaviour {
//	Vector2 mouse;
	GameObject laserBase;
	enemyAI[] bots;
	float range = 100.0f;
	LineRenderer line;
	public Material lineMaterial;

	// Use this for initialization
	void Start () {
		laserBase = GameObject.FindWithTag ("LaserBase");


		line = GetComponent<LineRenderer>();
//		line.SetVertexCount(2);
		line.GetComponent<Renderer>().material = lineMaterial;
		line.SetWidth(0.1f, 0.1f);
		//line.material = 

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		Vector3 forwardVector = transform.rotation * Vector3.forward;

		Ray ray2 = new Ray (laserBase.transform.position, forwardVector);//Camera.main.ScreenPointToRay(Input.mousePosition);
		Ray rayCheckHit = new Ray(laserBase.transform.position, Vector3.forward);
		if(Physics.Raycast(ray2, out hit, range))
		{
//			if(Input.GetMouseButton(0))
//			{
				line.enabled = true;
			line.SetPosition(0, transform.position- new Vector3(0,0.05f,0));
			line.SetPosition(1, hit.point - new Vector3(0,0.05f,0));// + hit.normal
//			Debug.Log("Hitnormal: "+ hit.normal);


			if (Physics.Raycast (rayCheckHit, out hit, range)) {
				if (hit.collider.tag == "Dink") {
					Debug.Log ("Hit");
				}
			}


			if (Physics.Raycast (rayCheckHit, out hit, range)) {
				if (hit.collider.tag == "CopBot") {
					Debug.Log ("Hit_Cop");

//					foreach (enemyAI bot in bots) {
//					Destroy (GameObject.FindGameObjectWithTag("CopBot"));
//					}


				}
			}


			}
			else
				line.enabled = false;
		}
		
	}


