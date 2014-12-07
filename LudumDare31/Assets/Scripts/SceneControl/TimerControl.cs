using UnityEngine;
using System.Collections;

public class TimerControl : MonoBehaviour {
	public LevelControl L_t;
	public SpriteRenderer [] Ds = new SpriteRenderer[3];
	public Sprite [] numbers = new Sprite[10];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int d3, d2, d1;
		d3 = (int)L_t.Timer / 100;
		d2 = (int)L_t.Timer / 10;
		d1 = (int)L_t.Timer % 10;

		Ds [2].sprite = numbers [d3];
		Ds [1].sprite = numbers [d2];
		Ds [0].sprite = numbers [d1];
	}
}
