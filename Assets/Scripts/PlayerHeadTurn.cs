using UnityEngine;
using System.Collections;

public class PlayerHeadTurn : MonoBehaviour {

	private PlayerMove playerMove;
	private Vector3 headDirection, otherSide;

	// Use this for initialization
	void Start () {
		playerMove = GetComponentInParent<PlayerMove> ();
		headDirection = transform.rotation.eulerAngles;
		otherSide = new Vector3 (0, 90, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!playerMove.leftOrRight) {
			transform.eulerAngles = headDirection;
		} else {
			transform.eulerAngles = (headDirection + otherSide);
		}
	}
}
