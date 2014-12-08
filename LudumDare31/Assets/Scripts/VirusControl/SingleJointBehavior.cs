using UnityEngine;
using System.Collections;

public class SingleJointBehavior : MonoBehaviour {

	public int GeneColor;
	public float ChildDistant = 1.5f;
	public Vector3 Direction;
	public Transform genParent;
	public PopScore text;
	public GameObject deathFX, growSFX, deathSFX;

	public GameObject [] Children = new GameObject [10];
	public GameObject [] Parents = new GameObject [5];
	public int Ccount = 0,Pcount = 0;
	public float WidthInit;

	GameObject radio, temp;
	Transform potential;
	public bool emitting, Growing, dying;
	float Speed = 2f, AnimScalar;
	Vector3 Offset, originalPos;
	public int Value;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		Value = 25;
		//radio = GameObject.FindWithTag ("EmitRadio");
		potential = transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {
		float scalar = 0.25f + Value / 60f;
		if(scalar > 1.25f){
			scalar = 1.25f;
		}
		AnimScalar = GetComponent<Increasing> ().AnimScalar;
		transform.localScale = new Vector3 (scalar, scalar, scalar) * AnimScalar;
		potential.localScale = new Vector3 (1f/ scalar, 1f/ scalar, 1f/ scalar);

		if(emitting){
			transform.Translate(Direction * Time.deltaTime * Speed);
			if((transform.position - genParent.position).magnitude > ChildDistant){
				originalPos = transform.localPosition;
				emitting = false;
				VirusValues.updateRadius(transform.position);
				//gameObject.collider.isTrigger = false;
			}
		}
		else{
			Offset = GetComponent<Shaking> ().offset;
			transform.localPosition = originalPos + Offset;
		}

		if(Value >= 60 && !Growing){
			Grow();
		}

	}
	public void GetValue(int v){
		GameObject tmp;
		//Debug.Log (gameObject.name + " GetValue: " + v);
		//if(!Growing && !emitting){
			if(v>0){
				GetComponent<Increasing>().playAnim();

				tmp = Instantiate(text.gameObject, transform.position, Quaternion.identity) as GameObject;
				tmp.GetComponent<PopScore>().SetText("+" + v.ToString(), VirusValues.UsedColor[GeneColor]);
				tmp.SetActive(true);
			}
			else{
				if(emitting){
					v = v / 2;
				}
				v = v + VirusValues.BlueLevel * 2;
				if(Value + v < 0){
					v = -Value;
				}
				originalPos = transform.localPosition;
				GetComponent<Shaking>().playAnim();
				if(!emitting){
					tmp = Instantiate(text.gameObject, transform.position, Quaternion.identity) as GameObject;
					tmp.GetComponent<PopScore>().SetText(v.ToString(), VirusValues.UsedColor[3]);
					tmp.SetActive(true);
				}
			}
			Value += v;
			VirusValues.GetValue(GeneColor, v);

			if(Value <= 0){
				StartDie ();
			}
		//}
		//There should be effect
	}
	public void GetValueWithoutArmor(int v){
		GameObject tmp;
		//Debug.Log (gameObject.name + " GetValue: " + v);
		//if(!Growing && !emitting){
		if(v>0){
			GetComponent<Increasing>().playAnim();
			
			tmp = Instantiate(text.gameObject, transform.position, Quaternion.identity) as GameObject;
			tmp.GetComponent<PopScore>().SetText("+" + v.ToString(), VirusValues.UsedColor[GeneColor]);
			tmp.SetActive(true);
		}
		else{
			if(emitting){
				v = v /2;
			}
			//v = v + VirusValues.BlueLevel * 2;
			if(Value + v < 0){
				v = -Value;
			}
			originalPos = transform.localPosition;
			GetComponent<Shaking>().playAnim();

				tmp = Instantiate(text.gameObject, transform.position, Quaternion.identity) as GameObject;
				tmp.GetComponent<PopScore>().SetText(v.ToString(), VirusValues.UsedColor[3]);
				tmp.SetActive(true);
		}
		Value += v;
		VirusValues.GetValue(GeneColor, v);
		if(Value <= 0){
			StartDie ();
		}
		//}
		//There should be effect
	}

	public void GetValueWithoutScore(int v){
		GameObject tmp;
		//Debug.Log (gameObject.name + " GetValue: " + v);
		//if(!Growing && !emitting){
			if(v>0){
				GetComponent<Increasing>().playAnim();
				
//				tmp = Instantiate(text.gameObject, transform.position, Quaternion.identity) as GameObject;
//				tmp.GetComponent<PopScore>().SetText("+" + v.ToString(), VirusValues.UsedColor[GeneColor]);
//				tmp.SetActive(true);
			}
			else{
//				v = v + VirusValues.RedLevel;
//				if(v > 0){
//					v = 0;
//				}
				originalPos = transform.localPosition;
				GetComponent<Shaking>().playAnim();
				
//				tmp = Instantiate(text.gameObject, transform.position, Quaternion.identity) as GameObject;
//				tmp.GetComponent<PopScore>().SetText(v.ToString(), VirusValues.UsedColor[3]);
//				tmp.SetActive(true);
			}
			Value += v;
			//VirusValues.GetValue(GeneColor, v);
			if(Value <= 0){
				StartDie ();
			}
		//}
		//There should be effect
	}

	public void GetParentConnect(GameObject PConnect, float width){
		WidthInit = width; 
		if (Pcount >= 4) {
						Pcount --;
				}
		Parents [Pcount++] = PConnect;
	}
	public float GetChildConnect(GameObject CConnect){
		Children [Ccount++] = CConnect;
		return WidthInit;
	}
	public void StartDie(){
		if(!dying){
			dying = true;
			if(Value > 0)
				GetValueWithoutArmor(-Value);
			for(int i = 0;i<Pcount;i++){
				Parents[i].GetComponent<ConnectControl>().StartDie(1);
			}
			for(int i=0;i<Ccount;i++){
				Children[i].GetComponent<ConnectControl>().StartDie(0);
			}
			//Debug.Log ("StartDie: " + gameObject.name);
			if(!emitting){
				GameObject tmp = Instantiate (deathFX, transform.position, Quaternion.identity) as GameObject;
				tmp.GetComponent<DeathFX> ().FX ();
				(Instantiate(deathSFX) as GameObject).SetActive(true);
			}
			Destroy (gameObject);
		}
	}
	public void ParentConnectDie(GameObject pc){
		if (Pcount == 1){
			Pcount = 0;
			Debug.Log ("ParentDie: " + gameObject.name);
			StartDie ();
		}
		else{
			for(int i=0;i<Pcount-1;i++){
				if(pc == Parents[i]){
					Parents[i] = Parents[Pcount-1];
					break;
				}
			}
			if(Pcount > 0)
				Pcount--;
		}
	}
	public void ChildConnectDie(GameObject cc){
		for(int i=0;i<Ccount-1;i++){
			if(cc == Children[i]){
				Children[i] = Children[Ccount-1];
			}
		}
		if(Ccount>0)
			Ccount--;
	}
	public void Reset(){
		Pcount = 0;
		Ccount = 0;
		Growing = false;
	}
	void OnTriggerEnter(Collider c){
		if(emitting){
			if(c.tag == "GeneBase" && c.gameObject.transform != genParent){
				if(c.gameObject.GetComponent<SingleJointBehavior>().GeneColor == GeneColor){
					c.gameObject.GetComponent<SingleJointBehavior>().GetValue(Value/2);
					if(checkOverlap(c.gameObject))
						Parents[0].GetComponent<ConnectControl>().ResetConnect(c.gameObject);
					else
						StartDie();
					//Destroy(gameObject);
				}
				else{
					c.gameObject.GetComponent<SingleJointBehavior>().GetValueWithoutScore(-Value);
					StartDie();
					//Destroy(gameObject);
				}
			}
		}
	}
	bool checkOverlap(GameObject target){
		for(int i = 0;i<target.GetComponent<SingleJointBehavior>().Pcount;i++){
			if(target.GetComponent<SingleJointBehavior>().Parents[i]
			   && target.GetComponent<SingleJointBehavior>().Parents[i].GetComponent<ConnectControl>()._from
			   ){
				if(target.GetComponent<SingleJointBehavior>().Parents[i].GetComponent<ConnectControl>()._from ==
				   Parents[0].GetComponent<ConnectControl>()._from){
					return false;
				}
			}
		}
		return true;
	}
	void GrowEnd(){
		Growing = false;
	}
	public bool Emit(Vector3 dir, Transform parent){
		//gameObject.collider.isTrigger = true;
		genParent = parent;
		//Vector3 dir = ChildDirection ();
		RaycastHit hit;
		if(!Physics.Raycast (parent.position + Vector3.Lerp(Vector3.zero, dir, 0.75f), dir, out hit, ChildDistant / 2f)){
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
		Growing = true;
		Value -= 20;
		temp = Instantiate (gameObject, transform.position, Quaternion.identity) as GameObject;
		temp.transform.parent = GameObject.Find("Base").transform;
		temp.GetComponent<SingleJointBehavior> ().Reset ();
		int n = 0;
		while(n < 100){
			Vector3 childPos = ChildDirection ();
			if(temp.GetComponent<SingleJointBehavior>().Emit (childPos, transform)){
				//temp.GetComponent<SingleJointBehavior>().genParent = transform;
				//int n = 0;
				Invoke ("GrowEnd", 1.5f);
				(Instantiate(growSFX) as GameObject).SetActive(true);
				GameObject temp2 = Instantiate(Parents[0], transform.position + new Vector3(0, 0, -100), Quaternion.identity) as GameObject;
				temp2.GetComponent<ConnectControl>().SetConnect(gameObject, temp);
				Debug.Log ("CreateLine: " + temp2.name);
				return;
			}
			n++;
		}
		Destroy (temp);
		Value = 50;

	}
	Vector3 ChildDirection(){
		Vector3 parentPos = transform.position;
		float angle = Random.Range (-90f, 90f);
		//Debug.Log (angle);
		Vector3 baseVec = (transform.position - Parents[0].GetComponent<ConnectControl>()._from.transform.position).normalized;
		float a = angle_360 (Vector3.right, baseVec);
		//Debug.Log ("aOriginal: " + a);
		a = a + angle;
		//Debug.Log ("aFinal:" + a);
		Vector3 childPos = new Vector3 (Mathf.Cos (a/180f * 3.14f), Mathf.Sin (a/180f * 3.14f), 0);
		//Debug.Log (childPos);
		return childPos;
	}
	float angle_360(Vector3 from_, Vector3 to_){  
		Vector3 v3 = Vector3.Cross(from_,to_);  
		if(v3.z > 0)  
			return Vector3.Angle(from_,to_);  
		else  
			return 360-Vector3.Angle(from_,to_);  
	}  
}
