using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	int stage;
	// Use this for initialization
	void Start () {
		stage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(stage == 0){
			if(Input.GetKeyDown("1")){
				VirusValues.Mode = 0;;
			}
			else if(Input.GetKeyDown("2")){
				VirusValues.Mode = 1;
			}
			else if(Input.GetKeyDown("3")){
				VirusValues.Mode = 2;
			}
		}
		else if(stage == 1){
			if(Input.anyKeyDown){

			}
		}
		else if(stage == 2){
			if(Input.anyKeyDown){
				Application.LoadLevel("VirusX");
			}
		}
	}
}
