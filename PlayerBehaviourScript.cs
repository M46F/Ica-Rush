using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour {

	public float initHP = 5;
	private float point = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (this.initHP <= 0) {
			Death ();
		}

		point += Time.deltaTime;
		Debug.Log (point);
	}

	void OncollisionEnter(Collision collision){
		if (collision.gameObject.tag.Equals ("Enemy") || collision.gameObject.tag.Equals ("Bullet")) {
			initHP -= 1;
			Debug.Log ("HP sekarang : " + initHP);
		}
	}

	void Death(){
		Destroy (this);
	}

}
