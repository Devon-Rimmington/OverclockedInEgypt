using UnityEngine;
using System.Collections;

public class LeverActions : MonoBehaviour {

	public GameObject[] controlledObjects;
	private TwoStatObj twoStateObj;
	private MovingPlatform2State mvplatform2State;
	private bool doorController;
	private AudioSource audioSource;
	public AudioClip clickSound;


	// Use this for initialization
	void Start () {
		if ((twoStateObj = controlledObjects[0].GetComponent<TwoStatObj>()) != null) {
			doorController = true;
		} else {
			doorController = false;
			mvplatform2State = controlledObjects[0].GetComponent<MovingPlatform2State>();
		}

		audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.clip = clickSound;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeObjectsStates(){
		if (doorController) {
			for (int i = 0; i < controlledObjects.Length; i++) {
				controlledObjects [i].GetComponent<TwoStatObj> ().changeState ();
			}
			if(!audioSource.isPlaying){
				audioSource.Play();
			}else{
				audioSource.Stop();
				audioSource.Play();
			}
		} else {
			for (int i = 0; i < controlledObjects.Length; i++) {
				controlledObjects [i].GetComponent<MovingPlatform2State> ().changeState ();
			}

			if(!audioSource.isPlaying){
				audioSource.Play();
			}else{
				audioSource.Stop();
				audioSource.Play();
			}
		}
	}
}
