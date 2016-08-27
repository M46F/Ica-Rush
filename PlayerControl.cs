using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float force = 10f;
	public float dec = 0.5f;

	public float speed = 0.5f;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Z) && Input.GetKeyDown (KeyCode.X)) {

			rb2d.AddForce (Vector2.up * force);
			Debug.Log ("atas");

		} else if (Input.GetKeyDown (KeyCode.Z)) {
			rb2d.velocity = Vector2.right * speed * -1;
			Debug.Log ("kiri");
		} else if (Input.GetKeyDown (KeyCode.X)) {

			rb2d.velocity = Vector2.right * speed;
			Debug.Log ("kanan");
		}
	}

	void FixedUpdate(){
		if (rb2d.velocity.x <= 0.0001 && rb2d.velocity.x >= -0.0001) {
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		}else if (rb2d.velocity.x > 0) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x - dec, rb2d.velocity.y);
		} else if (rb2d.velocity.x < 0) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x + dec, rb2d.velocity.y);
		}
	}
}
