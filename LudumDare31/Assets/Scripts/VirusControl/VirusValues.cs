using UnityEngine;
using System.Collections;

public class VirusValues : MonoBehaviour {
	public static float Radius = 1.5f;
	public static float Red_WidthScalar = 1;
	// Use this for initialization
	void Start () {
		//Red_WidthScalar = 1;
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
