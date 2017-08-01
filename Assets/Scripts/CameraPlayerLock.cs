using UnityEngine;
using System.Collections;

public class CameraPlayerLock : MonoBehaviour {

	public GameObject player;
	private Vector3 thisPosition;
	private PlayerHidingMechanic playerHidingMech;
	private float distFromPlayer, minDist, maxDist;

	// Use this for initialization
	void Start () {
		thisPosition = transform.position;
		distFromPlayer = thisPosition.z - 2;
		minDist = distFromPlayer + 2;
		maxDist = distFromPlayer - 10;
		playerHidingMech = player.GetComponent<PlayerHidingMechanic> ();
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (Input.mouseScrollDelta.y + " " + distFromPlayer + " " + maxDist + " " + minDist);




		distFromPlayer += Input.mouseScrollDelta.y;
		if (distFromPlayer < maxDist)
			distFromPlayer = maxDist;
		else if (distFromPlayer > minDist)
			distFromPlayer = minDist;
			
	

		gameObject.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 2, distFromPlayer);
	}
}
