using UnityEngine;
using System.Collections;

public class thing : MonoBehaviour {

	public Texture[] faces;
	public Texture hurtFace;
	private int damageIndex;
	private Renderer thisMaterial;


	// Use this for initialization
	void Start () {
		damageIndex = 0;
		thisMaterial = gameObject.GetComponent<Renderer> ();
		thisMaterial.material.mainTexture = faces[0];
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	//call when damaged
	public void changeFace(){
		damageIndex++;
		//dont change the image if dead
		if(damageIndex == faces.Length){damageIndex--;}
		thisMaterial.material.mainTexture = hurtFace;
		thisMaterial.material.mainTexture = faces [damageIndex];

	}


}
