using UnityEngine;
using System.Collections;

public class ConnectControl : MonoBehaviour {
	public GameObject _from, _to;
	public float WidthInit;
	public bool isBase;
	bool life;
	// Use this for initialization
	void Start () {
		if (isBase){
			SetConnect (_from, _to);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(life){
			Vector3 v = _to.transform.position - _from.transform.position;
			float dis = v.magnitude;
			transform.localScale = new Vector3(dis, transform.localScale.y, 1);
			float angle = angle_360 (Vector3.right, v.normalized);
			transform.eulerAngles = new Vector3(0, 0, angle);
			transform.position = Vector3.Lerp (_from.transform.position, _to.transform.position, 0.5f); 
		}

	}
	public void StartDie(int fromwho){
		life = false;
		if(fromwho == 0){
			_to.GetComponent<SingleJointBehavior>().ParentConnectDie(gameObject);
		}
		else{
			if(GameObject.Find ("Base") != _from)
				_from.GetComponent<SingleJointBehavior>().ChildConnectDie(gameObject);
		}
		Destroy (gameObject);
	}
	public void GetValue(int v){
		if(GameObject.Find ("Base") != _from){
			_from.GetComponent<SingleJointBehavior> ().GetValue(v / 2);
		}
		_to.GetComponent<SingleJointBehavior> ().GetValue (v / 2);
	}
	public void SetConnect(GameObject parent, GameObject child){
		_from = parent;
		_to = child;
		if(!isBase)
			WidthInit = parent.GetComponent<SingleJointBehavior> ().GetChildConnect (gameObject);
		child.GetComponent<SingleJointBehavior> ().GetParentConnect (gameObject, WidthInit);
		transform.localScale = new Vector3(transform.localScale.x, WidthInit*VirusValues.Red_WidthScalar, 1);
		life = true;
		isBase = false;
	}
	public void ResetConnect(GameObject child){
		//_from = parent;
		_to.GetComponent<SingleJointBehavior> ().ParentConnectDie (gameObject);
		_to = child;
		child.GetComponent<SingleJointBehavior> ().GetParentConnect (gameObject, WidthInit);
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
