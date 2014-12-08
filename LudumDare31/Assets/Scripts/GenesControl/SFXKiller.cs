using UnityEngine;
using System.Collections;

public class SFXKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Death", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Death(){
		Destroy (gameObject);
	}
}
