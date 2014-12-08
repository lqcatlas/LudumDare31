﻿using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Texture2D Capture(){
		gameObject.SetActive (true);
		Texture2D tmp = CaptureCamera (GetComponent<Camera> (), new Rect (0f, 0f, Screen.width * 1f, Screen.height * 1f));
		gameObject.SetActive (false);
		return tmp;
	}
	Texture2D CaptureCamera(Camera camera, Rect rect){  
		RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);  
 
		camera.targetTexture = rt;  
		camera.Render();  

		RenderTexture.active = rt;  
		Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24,false);  
		screenShot.ReadPixels(rect, 0, 0);  
		screenShot.Apply();  

		camera.targetTexture = null;  

		RenderTexture.active = null;  
		GameObject.Destroy(rt);  
 
//		byte[] bytes = screenShot.EncodeToPNG();  
//		string filename = Application.dataPath + "/Screenshot.png";  
//		System.IO.File.WriteAllBytes(filename, bytes);  
		return screenShot;  
	}  
}