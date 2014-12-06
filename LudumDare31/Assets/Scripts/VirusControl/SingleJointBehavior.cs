using UnityEngine;
using System.Collections;

public class SingleJointBehavior : MonoBehaviour {

	public int GeneColor;
	public float ChildDistant = 1.5f;
	public Vector3 Direction;

	public Transform genParent;
	GameObject radio, temp;
	Transform potential;
	bool emitting;
	float Speed = 3;
	public int Value;
	// Use this for initialization
	void Start () {
		Value = 5;
		radio = GameObject.FindWithTag ("EmitRadio");
		potential = transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {
		float scalar = 0.25f + Value / 20f;
		transform.localScale = new Vector3 (scalar, scalar, scalar);

		potential.localScale = new Vector3 (1f/ scalar, 1f/ scalar, 1f/ scalar);
		if(Value >= 20){
			Grow();
		}
		if(emitting){
			transform.Translate(Direction * Time.deltaTime * Speed);
			if((transform.position - genParent.position).magnitude > ChildDistant){
				emitting = false;
				//gameObject.collider.isTrigger = false;
			}
		}
	}
	public bool Emit(Vector3 dir, Transform parent){
		//gameObject.collider.isTrigger = true;
		genParent = parent;
		RaycastHit hit;
		if(!Physics.Raycast (parent.position + Vector3.Lerp(Vector3.zero, dir, 0.5f), dir, out hit, ChildDistant / 2f)){
			emitting = true;
			Direction = dir;
			return true;
		}
		else{
			Debug.Log ("HitSth: " + hit.collider.tag);
			if(hit.collider.tag == "EmitRadio"){
				emitting = true;
				Direction = hit.collider.transform.position;
				return true;
			}
			else{
				return false;
			}
		}
	}
	void Grow(){
		Value = 15;
		Vector3 childPos = ChildDirection ();
		temp = Instantiate (gameObject, transform.position, Quaternion.identity) as GameObject;
		temp.transform.parent = GameObject.Find("Base").transform;
		int n = 0;
		while(n < 20){
			if(temp.GetComponent<SingleJointBehavior> ().Emit (childPos, transform)){
				return;
			}
			n++;
		}
		Value = 20;
	}
	Vector3 ChildDirection(){
		Vector3 parentPos = transform.position;
		float angle = Random.Range (-60f, 60f);
		//Debug.Log (angle);
		Vector3 baseVec = parentPos.normalized;
		float a = angle_360 (Vector3.right, baseVec);
		//Debug.Log ("aOriginal: " + a);
		a = a + angle;
		//Debug.Log ("aFinal:" + a);
		Vector3 childPos = new Vector3 (Mathf.Cos (a/180f * 3.14f), Mathf.Sin (a/180f * 3.14f), 0);
		//Debug.Log (childPos);
		return childPos;
	}
	public void GetValue(int v){
		Value += v;
		if(Value <= 0){
			Destroy(gameObject);
		}
		//There should be effect
	}
	void OnTriggerEnter(Collider c){
		if(emitting){
			if(c.tag == "GeneBase" && c.gameObject.transform != genParent){
				if(c.gameObject.GetComponent<SingleJointBehavior>().GeneColor == GeneColor){
					c.gameObject.GetComponent<SingleJointBehavior>().GetValue(Value);
					Destroy(gameObject);
				}
				else{
					c.gameObject.GetComponent<SingleJointBehavior>().GetValue(-Value);
					Destroy(gameObject);
				}
			}
		}
	}
	float angle_360(Vector3 from_, Vector3 to_){  
		Vector3 v3 = Vector3.Cross(from_,to_);  
		if(v3.z > 0)  
			return Vector3.Angle(from_,to_);  
		else  
			return 360-Vector3.Angle(from_,to_);  
	}  

}
