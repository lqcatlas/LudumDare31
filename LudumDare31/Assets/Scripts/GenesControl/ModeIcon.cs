using UnityEngine;
using System.Collections;

public class ModeIcon : MonoBehaviour {
	public GameObject [] Icons = new GameObject [3];
	// Use this for initialization
	void Start () {
		Invoke ("IconDisplay", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void IconDisplay(){
		if(VirusValues.Mode == 0){
			Icons[0].SetActive(true);
		}
		if(VirusValues.Mode == 1){
			Icons[1].SetActive(true);
		}
		if(VirusValues.Mode == 2){
			Icons[2].SetActive(true);
		}
	}
}
