using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour {
	public GameObject [] bases = new GameObject[3];
	public float Timer;
	public bool starting;
	public GameObject generator;
	bool wait;
	// Use this for initialization
	void Start () {
		wait = true;
		Invoke ("cool", 5);
	}
	
	// Update is called once per frame
	void Update () {
		if(!starting && !wait){
			CheckStart();
		}
		if(starting){
			Timer -= Time.deltaTime;
		}
	}
	void cool(){
		wait = false;
	}
	void CheckStart(){
		if(bases[0].GetComponent<SingleJointBehavior>().Value < 50 &&
		   bases[1].GetComponent<SingleJointBehavior>().Value < 50 &&
		   bases[2].GetComponent<SingleJointBehavior>().Value < 50){
			starting = true;
			generator.GetComponent<GeneratorControl>().Startup();
			Timer = 120;
			Debug.Log ("Game Start");
		}
	}
}
