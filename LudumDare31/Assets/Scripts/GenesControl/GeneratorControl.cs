using UnityEngine;
using System.Collections;

public class GeneratorControl : MonoBehaviour {
	public GameObject [] Generators = new GameObject[4];
	bool sleep1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Generators[1].activeInHierarchy == true){
			if(VirusValues.Radius > 4 && Generators[1].activeInHierarchy == false){
				Generators[1].SetActive(true);
				GenesGenerator.Interval = 4;
			}
			if(VirusValues.Radius > 6 && Generators[2].activeInHierarchy == false){
				Generators[2].SetActive(true);
				GenesGenerator.Interval = 5;
			}
			if(VirusValues.Radius > 8 && Generators[3].activeInHierarchy == false){
				Generators[3].SetActive(true);
				GenesGenerator.Interval = 6;
			}
			if(VirusValues.Radius > 10 && !sleep1){
				sleep1 = true;
			}
		}
	}
	public void Startup(){
		Generators [0].SetActive(true);
	}
}
