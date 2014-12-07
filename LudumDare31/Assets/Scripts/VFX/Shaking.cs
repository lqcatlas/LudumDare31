using UnityEngine;
using System.Collections;

public class Shaking : MonoBehaviour {
	public Vector3 offset;
	public float MaxOffset = 0.1f;
	int stage;
	// Use this for initialization
	void Start () {
		stage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (stage == 0) {
			offset = Vector3.zero;
		}
		else if(stage == 1){
			offset = new Vector3(Random.Range(-MaxOffset, MaxOffset), Random.Range(-MaxOffset, MaxOffset), 0);
		}
	
	}
	void cooldown(){
		stage = 0;
	}
	public void playAnim(){
		stage = 1;
		Invoke ("cooldown", 0.5f);
	}
}
