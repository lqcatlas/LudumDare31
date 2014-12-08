using UnityEngine;
using System.Collections;

public class TimerControl : MonoBehaviour {
	public LevelControl L_t;
	public SpriteRenderer [] Ds = new SpriteRenderer[3];
	public Sprite [] numbers = new Sprite[10];
	bool active;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(L_t.Timer>0){
			int d3, d2, d1;
			d3 = (int)L_t.Timer / 100;
			d2 = ((int)L_t.Timer / 10) % 10;
			d1 = (int)L_t.Timer % 10;

			Ds [2].sprite = numbers [d3];
			Ds [1].sprite = numbers [d2];
			Ds [0].sprite = numbers [d1];
			if(d3 == 0 && d2 == 0 && !active){
				active = true;
				audio.Play();
				Invoke("audioPlay", 1);
				Invoke("audioPlay", 2);
				Invoke("audioPlay", 3);
				Invoke("audioPlay", 4);
				Invoke("audioPlay", 5);
				Invoke("audioPlay", 6);
				Invoke("audioPlay", 7);
				Invoke("audioPlay", 8);
				Invoke("audioPlay", 9);

			}
		}
	}
	void audioPlay(){
		audio.Play();
	}
}
