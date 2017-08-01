using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StorySession : MonoBehaviour {


	public string[] cpuDialog;
	public string[] otherDialog;
	public Camera mainCamera, dialogCamera;
	public Canvas canvas;
	public GameObject text;
	public AudioClip[] robotChatter, radioChatter;
	private AudioSource audioSource;
	private int clipIndex;


	public string currentDialog;

	//speaking pattern cpu - other - loop
	private bool nextDialog, cpuSpeaking, dialogMode;
	private int currentDialogIndexCount;
	private PlayerMove playerMove;

	// Use this for initialization
	void Start () {
		nextDialog = false;
		cpuSpeaking = true;
		currentDialogIndexCount = 0;
		playerMove = GetComponent<PlayerMove> ();
		canvas.enabled = false;

		audioSource = gameObject.AddComponent<AudioSource> ();
		clipIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {



		if (dialogMode) {
			mainCamera.enabled = false;
			dialogCamera.enabled = true;
			shutOffControls();
			playerMove.dialogMode = true;
			canvas.enabled = true;
		} else {
			mainCamera.enabled = true;
			dialogCamera.enabled = false;
			turnOnControls();
			playerMove.dialogMode = false;
			canvas.enabled = false;
			currentDialogIndexCount = 0;
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			nextDialog = true;
			if (currentDialogIndexCount >= cpuDialog.Length) {
				dialogMode = false;
			}
		}


		if (nextDialog && dialogMode) {
			nextDialog = false;
			if(cpuSpeaking){

				if (clipIndex >= robotChatter.Length) {
					clipIndex = 0;
				}

				audioSource.Stop();
				audioSource.clip = robotChatter[clipIndex];
				audioSource.Play();

				currentDialog = cpuDialog[currentDialogIndexCount];
				cpuSpeaking = !cpuSpeaking;
			}
			else{

				if (clipIndex >= robotChatter.Length) {
					clipIndex = 0;
				}

				audioSource.Stop();
				audioSource.clip = radioChatter[clipIndex];
				audioSource.Play();

				currentDialog = otherDialog[currentDialogIndexCount];
				currentDialogIndexCount++;
				cpuSpeaking = !cpuSpeaking;
				clipIndex++;
			}
		}

		if (currentDialog.Equals ("")) {
			if (currentDialogIndexCount < cpuDialog.Length) {
				nextDialog = true;
			}
		} else {
			Debug.Log(currentDialog);
			text.GetComponent<Text>().text = currentDialog;
		}

	}

	void OnTriggerEnter(Collider trigger){

		if (trigger.gameObject.tag == "StorySpot") {
			StorySpot storySpot = trigger.gameObject.GetComponent<StorySpot>();
			if(!storySpot.spotUsed){
				storySpot.spotUsed = true;
				cpuDialog = storySpot.cpuDialog;
				otherDialog = storySpot.otherDialog;
				dialogMode = true;
			}
		}
	}

	private void shutOffControls(){
		Time.timeScale = 0;
	}
	private void turnOnControls(){
		Time.timeScale = 1.0f;
	}
}
