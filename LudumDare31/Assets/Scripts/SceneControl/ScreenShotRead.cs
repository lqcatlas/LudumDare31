using UnityEngine;
using System.Collections;

public class ScreenShotRead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ReadScreenShot ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void ReadScreenShot(){
		gameObject.GetComponent<MeshRenderer> ().material.SetTexture ("_MainTex", VirusValues.Screenshot);
	}
}
