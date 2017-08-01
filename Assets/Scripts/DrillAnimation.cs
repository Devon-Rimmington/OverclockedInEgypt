using UnityEngine;
using System.Collections;

public class DrillAnimation : MonoBehaviour {

	public float drillSpeed;
	public AudioSource audioSource;
	public AudioClip drillSound;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.clip = drillSound;
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (drillSpeed*Time.deltaTime, 0, 0);
		if (!audioSource.isPlaying) {
			audioSource.Play();
		}
	}
}
