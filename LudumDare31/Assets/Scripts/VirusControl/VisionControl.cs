using UnityEngine;
using System.Collections;

public class VisionControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.one * 1.2f * VirusValues.Blue_Vision;
	}
}
