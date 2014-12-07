using UnityEngine;
using System.Collections;

public class GenesGenerator : MonoBehaviour {
	public GameObject [] Genes = new GameObject[3];
	public float InitRadius, LaunchRadius, LaunchSpeed;
	public static float Interval = 3;
	//-------------
	GameObject temp;
	bool ready;
	// Use this for initialization
	void Start () {
		ready = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(ready){
			ready = false;
			launchGene(1);
			Invoke("cooldown", Interval);
		}
		if(Input.GetKeyDown("e")){
			launchGene(1);
		}
	}	
	void cooldown(){
		ready = true;
	}
	public void launchGene(int hit){

		if (hit == 0) {
//			temp = Instantiate(Genes[Random.Range(0, 3)], InitPos(), Quaternion.identity) as GameObject;
//			temp.GetComponent<GeneBehavior>().setDirection(LaunchDirection());
//			temp.GetComponent<GeneBehavior>().setSpeed(LaunchSpeed + Random.Range(-LaunchSpeed / 5, LaunchSpeed / 5));
		}
		else{
			Vector3 initp = InitPos();
			temp = Instantiate(Genes[Random.Range(0, 3)], initp, Quaternion.identity) as GameObject;
			temp.GetComponent<GeneBehavior>().setDirection(LaunchDirection(initp));
			temp.GetComponent<GeneBehavior>().setSpeed(LaunchSpeed + Random.Range(-LaunchSpeed / 5, LaunchSpeed / 5));
		}
	}
	Vector3 LaunchDirection(Vector3 InitP){
		float r = LaunchRadius;
		r = VirusValues.Radius / 1.5f;
		Vector3 centerDir = InitP;
		Vector3 OrthoDir = new Vector3 (centerDir.y, -centerDir.x, 0).normalized;
		return -(centerDir + OrthoDir * Random.Range(-r, r)).normalized;
	}
	Vector3 InitPos(){
		Vector3 centerDir = transform.position;
		Vector3 OrthoDir = new Vector3 (centerDir.y, -centerDir.x, 0).normalized;
		return centerDir + OrthoDir * Random.Range (-InitRadius, InitRadius);
	}


}
