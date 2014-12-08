using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	int stage;
	bool active;
	public GameObject [] tasks = new GameObject[3];
	public GameObject instructions;
	// Use this for initialization
	void Start () {
		stage = 0;
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(stage == 0){
			if(Input.GetKeyDown("1") && active){
				VirusValues.Mode = 0;
				active = false;
				stage ++;
				audio.Play();
				Invoke("stageTransition", 0.5f);
				tasks[0].SetActive(true);
			}
			else if(Input.GetKeyDown("2") && active){
				VirusValues.Mode = 1;
				active = false;
				stage ++;
				audio.Play();
				Invoke("stageTransition", 0.5f);
				tasks[1].SetActive(true);
			}
			else if(Input.GetKeyDown("3") && active){
				VirusValues.Mode = 2;
				active = false;
				stage ++;
				audio.Play();
				Invoke("stageTransition", 0.5f);
				tasks[2].SetActive(true);
			}
		}
		else if(stage == 1){
			if(Input.anyKeyDown && active){
				active = false;
				stage ++;
				audio.Play();
				instructions.SetActive(true);
				Invoke("stageTransition", 0.5f);
			}
		}
		else if(stage == 2){
			if(Input.anyKeyDown && active){
				audio.Play();
				Application.LoadLevel("VirusX");
			}
		}
	}
	void stageTransition(){
		active = true;
	}
}
