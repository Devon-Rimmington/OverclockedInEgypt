using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	private bool forward = true;
	private float timer = 0;
	public float timeToWait;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (forward) {
			transform.Rotate (20*transform.forward * Time.deltaTime);
			timer += Time.deltaTime;
			if (timer >= timeToWait) {
				forward = false;
				timer = 0;
			}
		} else {
			transform.Rotate (20*-transform.forward * Time.deltaTime);
			timer += Time.deltaTime;
			if(timer >= timeToWait) {
				forward = true;
				timer = 0;
			}
		}
	}
}
