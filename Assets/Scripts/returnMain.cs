using UnityEngine;
using System.Collections;

public class returnMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void returnMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
