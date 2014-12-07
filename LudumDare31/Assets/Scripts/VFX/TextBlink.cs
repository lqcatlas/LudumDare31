using UnityEngine;
using System.Collections;

public class TextBlink : MonoBehaviour {
	public float BlinkTime;
	float timer;
	bool down;
	// Use this for initialization
	void Start () {
		timer = BlinkTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(down){
			GetComponent<TextMesh>().color = new Color(1, 1, 1, Mathf.Lerp (0, 1, timer));
			if(timer <= 0){
				down = false;
				timer = BlinkTime;
			}
			else{
				timer -= Time.deltaTime;
			}
		}
		else{
			GetComponent<TextMesh>().color = new Color(1, 1, 1, Mathf.Lerp (1, 0, timer));
			if(timer <= 0){
				down = true;
				timer = BlinkTime;
			}
			else{
				timer -= Time.deltaTime;
			}
		}
	}
}
