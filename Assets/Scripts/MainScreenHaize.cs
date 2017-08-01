using UnityEngine;
using System.Collections;

public class MainScreenHaize : MonoBehaviour {

	private Vector3 thisPosition, thatPosition;
	private float timer;
	private bool goingUp;

	// Use this for initialization
	void Start () {
		thisPosition = transform.position;
		thatPosition = thisPosition + Vector3.up;
		timer = 0;
		goingUp = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (goingUp) {
			timer += Time.deltaTime;
			transform.position = Vector3.Lerp(thisPosition, thatPosition, timer);
			if(timer >= 1)
				goingUp = !goingUp;
		} else {
			timer -= Time.deltaTime;
			transform.position = Vector3.Lerp(thatPosition, thisPosition, timer);
			if(timer <= 0)
				goingUp = !goingUp;
		}
	}
}
