using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //need to reset coins
	public void returnToLevel(){
		Application.LoadLevel(PlayerPrefs.GetString("currentlevel"));
	}
}
