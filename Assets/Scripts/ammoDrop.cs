using UnityEngine;
using System.Collections;

public class ammoDrop : MonoBehaviour {
	private GameObject projClone;
	public GameObject ammo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("Turret hit by: " + col.gameObject.tag);
		if(col.gameObject.tag.Equals ("Projectile")){
			if(GetComponentInChildren<CameraBehaviour>().enabled){
				gameObject.GetComponentInChildren<CameraBehaviour>().enabled = false;
				if(gameObject.tag == "ammoTurret"){
					Debug.Log ("Ammo prefab: " + ammo.name);
					projClone = Instantiate(ammo,  transform.position - 2*transform.forward, transform.rotation) as GameObject;
				}
			}

		}
	}

}
