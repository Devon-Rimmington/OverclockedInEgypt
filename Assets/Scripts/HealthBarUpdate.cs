using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarUpdate : MonoBehaviour {
    
    public float health = 0.0f;
    public GameObject cpu;
    Image HealthBarGreen;

    //get player and hpbar
    void Start()
    {
       // cpu = getPlayer();
        HealthBarGreen = gameObject.GetComponent<Image>();
        //HealthBarGreen.fillAmount = .5f;
		health = 1.0f;
    }

    public GameObject getPlayer()
    {
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        return playerList[0];
		HealthBarGreen.fillAmount = .5f;
    }



    public void setHealth(float health) {
        Image healthBarGreen = gameObject.GetComponent<Image>();
        //Fill uses 0 - 1, health is out of 10, change this?
        HealthBarGreen.fillAmount = health/10f;
    }

    void Update() //Inefficient???
    {
        health = cpu.GetComponent<characterStats>().health;
		//Debug.Log (cpu.GetComponent<characterStats>().health);
        //Fill uses 0 - 1, health is out of 10, change this?
        HealthBarGreen.fillAmount = health;

    }
}
