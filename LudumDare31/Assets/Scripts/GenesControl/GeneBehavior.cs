﻿using UnityEngine;
using System.Collections;

public class GeneBehavior : MonoBehaviour {
	public int GeneColor, Value;
	public GameObject rightSFX, wrongSFX;
	Vector3 Direction;
	float Speed = 0;
	GameObject temp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Direction * Speed * Time.deltaTime);
		if(transform.position.magnitude > 50){
			Destroy(gameObject);
		}
	}
	public void setDirection(Vector3 dir){
		Direction = dir;
	}
	public void setSpeed(float s){
		Speed = s;
	}
	void OnTriggerEnter(Collider c){
		//Debug.Log ("TriggerEnter");
		if(c.tag == "GeneBase"){
			if(c.GetComponent<SingleJointBehavior>().GeneColor == GeneColor){
				c.GetComponent<SingleJointBehavior>().GetValue(Value);
				(Instantiate(rightSFX) as GameObject).SetActive(true);
				Destroy(gameObject);
			}
			else{
				c.GetComponent<SingleJointBehavior>().GetValue(-Value);
				(Instantiate(wrongSFX) as GameObject).SetActive(true);
				Destroy(gameObject);
			}
		}
		if(c.tag == "GeneLine"){
			if(c.GetComponent<ConnectControl>()._to.GetComponent<SingleJointBehavior>().GeneColor == GeneColor){
				c.GetComponent<ConnectControl>().GetValue(Value);
				(Instantiate(rightSFX) as GameObject).SetActive(true);
				Destroy(gameObject);
			}
			else{
				c.GetComponent<ConnectControl>().GetValue(-Value);
				(Instantiate(wrongSFX) as GameObject).SetActive(true);
				Destroy(gameObject);
			}

		}
	}
}
