using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	public float RotateSpeed = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(new Vector3(0, 0, RotateSpeed * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(new Vector3(0, 0, -RotateSpeed * Time.deltaTime));
		}
	}
}
