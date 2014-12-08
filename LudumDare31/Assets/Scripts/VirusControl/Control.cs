using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	public float RotateSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RotateSpeed = VirusValues.Green_RotateSpeed;
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
			transform.Rotate(new Vector3(0, 0, RotateSpeed * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			transform.Rotate(new Vector3(0, 0, -RotateSpeed * Time.deltaTime));
		}
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel("Intro");
		}
	}
}
