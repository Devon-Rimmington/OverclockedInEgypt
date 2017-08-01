using UnityEngine;
using System.Collections;

public class CameraRay : MonoBehaviour {
	private float timer = 0, distance;
	private bool timerOn = false;
	private bool hitSomething, spawnEnemy;

	public GameObject shooter;
	public bool gunTurret;

	public Transform enemySpawnPosition;
	public GameObject enemyTemplate;

	// Use this for initialization
	void Start () {
		spawnEnemy = false;
		distance = 10;
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = new Ray (transform.position, -transform.up*10);
		RaycastHit hit;
		Debug.DrawRay (transform.position, -transform.up*10, Color.red);

		if (timerOn) {
			timer += Time.deltaTime;
			if(timer >= 2.1f)
			{
				Debug.Log ("Turret Timer turned off");
				timerOn = false;
				timer=0;
			}
		} 

		if (timerOn == false){
			if(Physics.Raycast (ray, out hit)){
				if(hit.distance <= distance){
					if(hit.collider.gameObject.tag == "Player")
					{
						if(gunTurret){
							Debug.Log ("Turret Timer turned on");
							timerOn = true;
							Debug.Log ("FIRE GUN");
							shooter.GetComponentInChildren<TurretFire>().fireGun ();
						}else{
							if(!spawnEnemy){
								spawnEnemy = true;
								GameObject temp = Instantiate(enemyTemplate, enemySpawnPosition.position, enemySpawnPosition.rotation) as GameObject;
								GameObject.Find (temp.name + "/MummyEnemy").transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
							}
						}
					}	

				}
			}
		}
	}
}
