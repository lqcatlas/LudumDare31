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

	public GameObject[] Arrows = new GameObject[3];
	public LineRenderer[] ProgressBars = new LineRenderer[3];
	float [] a = new float[3];

	public GameObject[] InitBases = new GameObject[3];
	// Use this for initialization
	void Start () {
		//Red_WidthScalar = 1;
		Invoke ("RdInitValue", .05f);
		UsedColor [0] = new Color (155/255f, 52/255f, 78/255f, 1f);
		UsedColor [1] = new Color (170/255f, 162/255f, 57/255f, 1f);
		UsedColor [2] = new Color (42/255f, 77/255f, 110/255f, 1f);
		UsedColor [3] = new Color (1f, 1f, 1f, 1f);
		if(Mode == -1){
			Mode = Random.Range(0, 3);
			GenerateTask(Mode);
		}
		ArrowMaintaining ();
	}
	public static void GenerateTask(int t){
		//int t = Random.Range (0, 3);
		Mode = t;
		if(t == 0){
			TaskRequire[0] = 200;
			TaskRequire[1] = 500;
			TaskRequire[2] = 500;
		}
		else if(t == 1){
			TaskRequire[0] = 100;
			TaskRequire[1] = 700;
			TaskRequire[2] = 700;
		}
		else if(t == 2){
			TaskRequire[0] = 1000;
			TaskRequire[1] = 1000;
			TaskRequire[2] = 1000;
		}
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

		Blue_WidthScalar = 1 + BlueLevel / 3f;
		Green_RotateSpeed = 80 + GreenLevel * 30f;
		Red_Vision = 1 + RedLevel / 5f;

		ProgressBarMaintaining ();
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
		Arrows [0].transform.position = new Vector3 (Mathf.Lerp (-10f, -5f, TaskRequire[0]/1000f), -8.5f, -8);
		Arrows [1].transform.position = new Vector3 (Mathf.Lerp (-2.5f, 2.5f, TaskRequire[1]/1000f), -8.5f, -8);
		Arrows [2].transform.position = new Vector3 (Mathf.Lerp (5f, 10f, TaskRequire[2]/1000f), -8.5f, -8);
	}
	public static void updateRadius(Vector3 pos){
		if(pos.magnitude > Radius){
			Radius = pos.magnitude;
		}
	}
	public static void GetValue(int color, int v){
		colorPoints [color] += v;
	}

}
