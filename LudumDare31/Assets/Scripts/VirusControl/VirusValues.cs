using UnityEngine;
using System.Collections;

public class VirusValues : MonoBehaviour {
	public static float Radius = 1.5f;
	public static float Red_WidthScalar = 1, Green_RotateSpeed = 30, Blue_Vision;
	public static int[] colorPoints = new int[3];
	public static int RedLevel, GreenLevel, BlueLevel;
	public static Color[] UsedColor= new Color [4];

	public LineRenderer[] ProgressBars = new LineRenderer[3];
	float [] a = new float[3];
	public GameObject[] InitBases = new GameObject[3];
	// Use this for initialization
	void Start () {
		//Red_WidthScalar = 1;
		Invoke ("RdInitValue", .05f);
		UsedColor [0] = new Color (1f, 0, 0, 1f);
		UsedColor [1] = new Color (0, 1f, 0, 1f);
		UsedColor [2] = new Color (0, 0, 1f, 1f);
		UsedColor [3] = new Color (1f, 1f, 1f, 1f);
	}
	void RdInitValue(){
		InitBases [0].GetComponent<SingleJointBehavior> ().Value = Random.Range (25, 60);
		InitBases [1].GetComponent<SingleJointBehavior> ().Value = Random.Range (25, 60);
		InitBases [2].GetComponent<SingleJointBehavior> ().Value = Random.Range (25, 60);
	}
	// Update is called once per frame
	void Update () {
		RedLevel = colorPoints [0] / 100;
		GreenLevel = colorPoints [1] / 100;
		BlueLevel = colorPoints [2] / 100;

		Red_WidthScalar = 1 + RedLevel / 10f;
		Green_RotateSpeed = 80 + GreenLevel * 30f;
		Blue_Vision = 1 + BlueLevel / 5f;

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
	public static void updateRadius(Vector3 pos){
		if(pos.magnitude > Radius){
			Radius = pos.magnitude;
		}
	}
	public static void GetValue(int color, int v){
		colorPoints [color] += v;
	}

}
