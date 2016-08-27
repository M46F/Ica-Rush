using UnityEngine;
using System.Collections;

public class bulletBehaviour : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, transform.parent.position.y);	
		Debug.Log (transform.position);
	}
}
