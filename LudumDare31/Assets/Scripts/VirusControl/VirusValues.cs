using UnityEngine;
using System.Collections;

public class VirusValues : MonoBehaviour {
	public static float Radius = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void updateRadius(Vector3 pos){
		if(pos.magnitude > Radius){
			Radius = pos.magnitude;
		}
	}

}
