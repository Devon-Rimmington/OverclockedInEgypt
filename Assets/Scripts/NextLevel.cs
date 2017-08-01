using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string nextLevel;
	private characterStats cStats;

	// Use this for initialization
	void Start () {
		//score = GetComponent<characterStats> ();
		cStats = GetComponent<characterStats> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider trigger){

		PlayerPrefs.SetInt("score", cStats.numCoins);

		if (trigger.gameObject.tag == "ZoneEnd") {
			Application.LoadLevel (nextLevel);
		}
	}
}
