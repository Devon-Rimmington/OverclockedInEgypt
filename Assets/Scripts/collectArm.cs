using UnityEngine;
using System.Collections;

public class collectArm : MonoBehaviour {

    GameObject CPU;
    characterStats currentStats;
	public AudioClip coin, gem, ammo, battery;
	private AudioSource audioSource;

	void Start(){
		audioSource = gameObject.AddComponent<AudioSource> ();		
	}


    void OnTriggerEnter(Collider trigger)
    {
        GameObject CPU = gameObject.transform.root.gameObject;
        currentStats = CPU.GetComponentInChildren<characterStats>();
        if (trigger.gameObject.tag == "Battery" && currentStats.health < currentStats.maxHealth)
        {
            currentStats.health = Mathf.Min(currentStats.maxHealth, currentStats.health + 0.2f);
            Destroy(trigger.gameObject);

			audioSource.clip = battery;
			audioSource.Play();

        }
        if (trigger.gameObject.tag == "Gold")
        {
            currentStats.numCoins += 1;
            Destroy(trigger.gameObject);
			audioSource.clip = coin;
			audioSource.Play();
			audioSource.volume = 0.5f;
        }
        if (trigger.gameObject.tag == "Gem")
        {
            currentStats.numCoins += 10;
            Destroy(trigger.gameObject);
			audioSource.clip = gem;
			audioSource.Play();
        }
        if (trigger.gameObject.tag == "Life")
        {
            currentStats.lives += 1;
            Destroy(trigger.gameObject);
            audioSource.clip = gem;
            audioSource.Play();
        }
        if (trigger.gameObject.tag == "Ammo" && currentStats.baseAmmo < currentStats.maxAmmo)
        {
            currentStats.baseAmmo = Mathf.Min(currentStats.maxAmmo, currentStats.baseAmmo + 3);
            Destroy(trigger.gameObject);

			audioSource.clip = ammo;
			audioSource.Play();
        }
		if (trigger.gameObject.tag == "Mummy") {
			if(transform.position.x > trigger.gameObject.transform.position.x){
				transform.root.GetComponent<characterStats> ().applyDamage(0.1f, Vector3.right);
			}
			else{
				transform.root.GetComponent<characterStats> ().applyDamage(0.1f, -Vector3.right);
			}
		}
    }



	public void doDamage(float damage){
		transform.root.GetComponent<characterStats> ().health -= damage;
	}
}
