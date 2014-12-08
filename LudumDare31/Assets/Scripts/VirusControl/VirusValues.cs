using UnityEngine;
using System.Collections;

public class VirusValues : MonoBehaviour {
	public static float Radius = 1.5f;
	public static float Blue_WidthScalar = 1, Green_RotateSpeed = 30, Red_Vision;
	public static int[] colorPoints = new int[3];
	public static int RedLevel, GreenLevel, BlueLevel;
	public static Color[] UsedColor= new Color [4];
	public static int[] TaskRequire = new int[3];
	public static int Mode = -1;

	public static Texture2D Screenshot;
	public ScreenShot cc;

	public GameObject[] Arrows = new GameObject[3];
	public LineRenderer[] ProgressBars = new LineRenderer[3];
	float [] a = new float[3];

	public GameObject[] InitBases = new GameObject[3];
	// Use this for initialization
	void Start () {
		//Red_WidthScalar = 1;
		//Invoke ("RdInitValue", .05f);
		UsedColor [0] = new Color (155/255f, 52/255f, 78/255f, 1f);
		UsedColor [1] = new Color (170/255f, 162/255f, 57/255f, 1f);
		UsedColor [2] = new Color (42/255f, 77/255f, 110/255f, 1f);
		UsedColor [3] = new Color (1f, 1f, 1f, 1f);
		colorPoints [0] = 0;
		colorPoints [1] = 0;
		colorPoints [2] = 0;
		if(Mode == -1){
			Mode = Random.Range(0, 3);
		}
		Invoke ("GenerateTask", 0.5f);;
	}
	public void GenerateTask(){
		//int t = Random.Range (0, 3);
		int t = Mode;
		if(t == 0){
			TaskRequire[0] = 200;
			TaskRequire[1] = 200;
			TaskRequire[2] = 200;

			int v = Random.Range (60, 100);
			InitBases [0].GetComponent<SingleJointBehavior> ().Value = v;
			colorPoints [0] += v;
			
			v = Random.Range (60, 100);
			InitBases [1].GetComponent<SingleJointBehavior> ().Value = v;
			colorPoints [1] += v;
			
			v = Random.Range (60, 100);
			InitBases [2].GetComponent<SingleJointBehavior> ().Value = v;
			colorPoints [2] += v;
		}
		else if(t == 1){
			TaskRequire[0] = 200;
			TaskRequire[1] = 400;
			TaskRequire[2] = 400;

			int v = Random.Range (400, 400);
			InitBases [0].GetComponent<SingleJointBehavior> ().Value = v;
			colorPoints [0] += v;
			
			v = Random.Range (500, 600);
			InitBases [1].GetComponent<SingleJointBehavior> ().Value = v;
			colorPoints [1] += v;
			
			v = Random.Range (500, 600);
			InitBases [2].GetComponent<SingleJointBehavior> ().Value = v;
			colorPoints [2] += v;
		}
		else if(t == 2){
			TaskRequire[0] = 800;
			TaskRequire[1] = 800;
			TaskRequire[2] = 800;

			int v = Random.Range (25, 60);
			InitBases [0].GetComponent<SingleJointBehavior> ().Value = v;
			colorPoints [0] += v;
			
			v = Random.Range (25, 60);
			InitBases [1].GetComponent<SingleJointBehavior> ().Value = v;
			colorPoints [1] += v;
			
			v = Random.Range (25, 60);
			InitBases [2].GetComponent<SingleJointBehavior> ().Value = v;
			colorPoints [2] += v;
		}
		ArrowMaintaining ();
	}
	void RdInitValue(){
		int v = Random.Range (25, 60);
		InitBases [0].GetComponent<SingleJointBehavior> ().Value = v;
		colorPoints [0] += v;

		v = Random.Range (25, 60);
		InitBases [1].GetComponent<SingleJointBehavior> ().Value = v;
		colorPoints [1] += v;

		v = Random.Range (25, 60);
		InitBases [2].GetComponent<SingleJointBehavior> ().Value = v;
		colorPoints [2] += v;
//		InitBases [1].GetComponent<SingleJointBehavior> ().Value = Random.Range (25, 60);
//		InitBases [2].GetComponent<SingleJointBehavior> ().Value = Random.Range (25, 60);
	}
	// Update is called once per frame
	void Update () {
		RedLevel = colorPoints [0] / 100;
		GreenLevel = colorPoints [1] / 100;
		BlueLevel = colorPoints [2] / 100;

		Blue_WidthScalar = 1 + BlueLevel / 2f;
		Green_RotateSpeed = 80 + GreenLevel * 30f;
		Red_Vision = 1.5f + RedLevel / 5f;

		ProgressBarMaintaining ();
		CheckFinish ();
	}
	void CheckFinish(){
		if(Mode == 0 || Mode == 2){
			if(colorPoints [0] > TaskRequire[0] &&
			   colorPoints [1] > TaskRequire[1] &&
			   colorPoints [2] > TaskRequire[2]){
				if(Mode ==0){
					Screenshot = cc.Capture();
					Application.LoadLevel("es1");
				}
				else if(Mode == 2){
					Screenshot = cc.Capture();
					Application.LoadLevel("es3");
				}
			}
		}
		else if(Mode == 1){
			if(colorPoints [0] < TaskRequire[0] &&
			   colorPoints [1] > TaskRequire[1] &&
			   colorPoints [2] > TaskRequire[2]){
				Screenshot = cc.Capture();
				Application.LoadLevel("es2");
			}
		}
	}
	public void TimeEnd(){
		if(colorPoints [0] >= colorPoints [1] && colorPoints [0] >= colorPoints [2]){
			Screenshot = cc.Capture();
			Application.LoadLevel("ef1");
		}
		else if(colorPoints [1] >= colorPoints [0] && colorPoints [1] >= colorPoints [2]){
			Screenshot = cc.Capture();
			Application.LoadLevel("ef2");
		}
		else if(colorPoints [2] >= colorPoints [0] && colorPoints [2] >= colorPoints [1]){
			Screenshot = cc.Capture();
			Application.LoadLevel("ef3");
		}
	}
	void ProgressBarMaintaining(){
		for(int i=0;i<3;i++){
			a[i] = colorPoints[i] / 1000f;
			if(a[i] >1){
				a[i] = 1;
			}
		}
		ProgressBars [0].SetPosition (0, new Vector3 (-10f, -9f, -8f));
		ProgressBars [0].SetPosition (1, new Vector3 (Mathf.Lerp (-10f, -5f, a [0]), -9f, -8f));
		ProgressBars [1].SetPosition (0, new Vector3 (-2.5f, -9f, -8f));
		ProgressBars [1].SetPosition (1, new Vector3 (Mathf.Lerp (-2.5f, 2.5f, a [1]), -9f, -8f));
		ProgressBars [2].SetPosition (0, new Vector3 (5f, -9f, -8f));
		ProgressBars [2].SetPosition (1, new Vector3 (Mathf.Lerp (5f, 10f, a [2]), -9f, -8f));
	}
	void ArrowMaintaining(){
		Arrows [0].transform.position = new Vector3 (Mathf.Lerp (-10f, -5f, TaskRequire[0]/1000f), -8.5f, -9f);
		Arrows [1].transform.position = new Vector3 (Mathf.Lerp (-2.5f, 2.5f, TaskRequire[1]/1000f), -8.5f, -9f);
		Arrows [2].transform.position = new Vector3 (Mathf.Lerp (5f, 10f, TaskRequire[2]/1000f), -8.5f, -9f);
	}
	public static void updateRadius(Vector3 pos){
		if(pos.magnitude > Radius){
			Radius = pos.magnitude;
			Debug.Log ("NewRadius: "+ Radius);
		}
	}
	public static void GetValue(int color, int v){
		colorPoints [color] += v;
	}

}
