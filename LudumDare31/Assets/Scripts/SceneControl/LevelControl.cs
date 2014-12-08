using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {
	public GameObject [] bases = new GameObject[3];
	public float Timer;
	public bool starting;
	public GameObject generator;
	public GameObject Virus;
	public GameObject[] UI = new GameObject[4];
	bool wait;
	// Use this for initialization
	void Start () {
		wait = true;
		Invoke ("cool", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if(!starting && !wait){
			CheckStart();
		}
		if(starting){
			Timer -= Time.deltaTime;
		}
		if(Timer <=0 && starting){
			Virus.GetComponent<VirusValues>().TimeEnd();
		}
	}
	void cool(){
		wait = false;
	}
	void CheckStart(){
		if(bases[0].GetComponent<SingleJointBehavior>().Value < 60 &&
		   bases[1].GetComponent<SingleJointBehavior>().Value < 60 &&
		   bases[2].GetComponent<SingleJointBehavior>().Value < 60){
			starting = true;
			generator.GetComponent<GeneratorControl>().Startup();
			Timer = 150;
			UI[0].SetActive(true);
			UI[1].SetActive(true);
			UI[2].SetActive(true);
			UI[3].SetActive(false);
			audio.Play();
			Debug.Log ("Game Start");
		}
	}
}
