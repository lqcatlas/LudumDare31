using UnityEngine;
using System.Collections;

public class PopScore : MonoBehaviour {
	float timer, speed = 3;
	Color BaseColor;
	bool deathable;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0){
			float a = Mathf.Lerp(1, 0, timer / 1f);
			//Debug.Log ("a = " + a);
			transform.Translate(Vector3.up * speed * Time.deltaTime);
			GetComponent<TextMesh> ().color = BaseColor - new Color(0, 0, 0, a);  
			timer -= Time.deltaTime;
		}
		else if(deathable){
			Destroy (gameObject);
		}
	}
	public void SetText(string str, Color c){
		GetComponent<TextMesh> ().text = str;
		gameObject.SetActive (true);
		BaseColor = c;
		timer = 1f;
		deathable = true;
	}

}
