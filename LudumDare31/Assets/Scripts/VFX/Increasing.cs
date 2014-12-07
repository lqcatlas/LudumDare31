using UnityEngine;
using System.Collections;

public class Increasing : MonoBehaviour {
	public float AnimScalar, MaxScalar = 1.2f;
	int stage;
	float oscale, Speed = 1;
	// Use this for initialization
	void Start () {
		stage = 0;
		AnimScalar = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(stage == 0){
			AnimScalar = 1;
		}
		if(stage == 1){
			AnimScalar += Speed * Time.deltaTime;
			if(AnimScalar > MaxScalar){
				stage = 2;
			}
		}
		else if(stage == 2){
			AnimScalar -= Speed * Time.deltaTime;
			if(AnimScalar <= 1){
				stage = 0;
			}
		}

	}
	public void playAnim(){
		stage = 1;
	}
}
