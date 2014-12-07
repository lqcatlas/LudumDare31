using UnityEngine;
using System.Collections;

public class DeathFX : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void FX(){
		GetComponent<ParticleSystem> ().Play ();
		Invoke ("Kill", 1);
	}
	void Kill(){
		Destroy (gameObject);
	}
}
