using UnityEngine;
using System.Collections;

public class bulletBehaviour : MonoBehaviour {
	float lastY;
	void Awake(){
		lastY = transform.position.y;
	}
	void Update () {
		
		transform.position = new Vector2 (transform.position.x, transform.position.y - (lastY - transform.parent.position.y));
		lastY = transform.parent.position.y;
		Debug.Log (transform.position);
	}
}
