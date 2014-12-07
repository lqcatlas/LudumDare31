using UnityEngine;
using System.Collections;

public class ConnectControl : MonoBehaviour {
	public GameObject _from, _to;
	public float WidthInit;
	public bool isBase;
	public GameObject deathFX;
	//public PopScore text;

	bool life, increasing, decreasing;
	float AnimScalar;
	Vector3 Offset, originalPos;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		if (isBase){
			SetConnect (_from, _to);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (gameObject.name + ": " + transform.position);
		//Debug.Log (gameObject.name + ": " +"To: "+ (transform.position - _to.transform.position).magnitude);
		//Debug.Log (gameObject.name + ": " +"From: " + (transform.position - _from.transform.position).magnitude);
//		if((transform.position - _to.transform.position).magnitude > 2 ||
//		   (transform.position - _from.transform.position).magnitude > 2){
//			life = false;
//			StartDie(0);
//		}
		if(life && _to && _from && _to != _from ){
			Vector3 v = _to.transform.position - _from.transform.position;
			float dis = v.magnitude;
			AnimScalar = GetComponent<Increasing> ().AnimScalar;
			transform.localScale = new Vector3(dis, WidthInit * AnimScalar, 1);

			float angle = angle_360 (Vector3.right, v.normalized);
			transform.eulerAngles = new Vector3(0, 0, angle);
			transform.position = Vector3.Lerp (_from.transform.position, _to.transform.position, 0.5f); 
			originalPos = transform.localPosition;

			Offset = GetComponent<Shaking> ().offset;
			transform.localPosition = originalPos + Offset;
		}
		else{
			life = false;
			StartDie(0);
		}

	}
	public void StartDie(int fromwho){
		life = false;
		if(_to != null){
			_to.GetComponent<SingleJointBehavior>().ParentConnectDie(gameObject);
		}
		if(_from != null){
			if(GameObject.Find ("Base") != _from){
				_from.GetComponent<SingleJointBehavior>().ChildConnectDie(gameObject);
			}
		}
		GameObject tmp = Instantiate (deathFX, transform.position, Quaternion.identity) as GameObject;
		tmp.GetComponent<DeathFX> ().FX ();
		Destroy (gameObject);
	}
	public void GetValue(int v){
		if(GameObject.Find ("Base") != _from){
			_from.GetComponent<SingleJointBehavior> ().GetValue(v / 2);
		}
		_to.GetComponent<SingleJointBehavior> ().GetValue (v / 2);
		if(v > 0){
			GetComponent<Increasing>().playAnim();
		}
		else{
			originalPos = transform.position;
			GetComponent<Shaking>().playAnim();
		}

	}
	public void SetConnect(GameObject parent, GameObject child){
		_from = parent;
		_to = child;
		if(!isBase)
			WidthInit = parent.GetComponent<SingleJointBehavior> ().GetChildConnect (gameObject);
		child.GetComponent<SingleJointBehavior> ().GetParentConnect (gameObject, WidthInit);
		transform.localScale = new Vector3(transform.localScale.x, WidthInit*VirusValues.Blue_WidthScalar, 1);
		life = true;
		isBase = false;
	}
	public void ResetConnect(GameObject child){
		//_from = parent;
		life = false;
		_to.GetComponent<SingleJointBehavior> ().ParentConnectDie (gameObject);
		_to = child;
		child.GetComponent<SingleJointBehavior> ().GetParentConnect (gameObject, WidthInit);
		life = true;
		//transform.localScale = new Vector3(transform.localScale.x, WidthInit*VirusValues.Red_WidthScalar, 1);
		//life = true;
	}
	float angle_360(Vector3 from_, Vector3 to_){  
		Vector3 v3 = Vector3.Cross(from_,to_);  
		if(v3.z > 0)  
			return Vector3.Angle(from_,to_);  
		else  
			return 360-Vector3.Angle(from_,to_);  
	}

}
