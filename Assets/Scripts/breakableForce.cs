using UnityEngine;
using System.Collections;

public class breakableForce : MonoBehaviour {

    public float force = 100f;
    public float breakTime = 3.0f;
	private Rigidbody rb;

    private BoxCollider box;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag=="Invisible")
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
        if (col.gameObject.tag=="Break")
        {
			rb = col.gameObject.GetComponent<Rigidbody>();
			rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(0, force, force);
            Destroy(col.gameObject,breakTime);
		}if (col.gameObject.tag == "Mummy") {
			if(transform.position.x > col.gameObject.transform.position.x){
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
