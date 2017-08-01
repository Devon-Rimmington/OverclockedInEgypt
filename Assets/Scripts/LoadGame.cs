using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("score", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadLevel(){
		Application.LoadLevel ("Level1");
	}	
}
