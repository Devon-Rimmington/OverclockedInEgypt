using UnityEngine;
using System.Collections;

public class TurretFire : MonoBehaviour {
	public float speed = 20;
	public AudioClip shoot;
	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.clip = shoot;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void fireGun()
	{
		GameObject projectile = Resources.Load ("projectileBasic") as GameObject;
		speed = projectile.GetComponent<projectileAttributes> ().speed;
		GameObject projClone = Instantiate(projectile, transform.position + (-transform.up), transform.rotation) as GameObject;
		Rigidbody rb = projClone.GetComponent<Rigidbody>();
		rb.velocity += -transform.up * speed;
		Destroy(projClone, 5f);
		audioSource.Play ();
	}
}
