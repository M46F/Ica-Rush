using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float force = 10f;
	public float dec = 0.5f;
	public float delayLimit = 0.25f;
	public float speed = 0.5f;

	private float delay = 0.0f;
	private bool inputZ = false;
	private bool inputX = false;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Z) && Input.GetKeyDown (KeyCode.X) || (inputX == true && inputZ == true)) {
			Debug.Log (delay);
			MoveUp ();
			DelayOver();
		}

		else if (Input.GetKeyDown(KeyCode.Z) && delay <= delayLimit) {
			inputZ = true;
		}
		else if (Input.GetKeyDown (KeyCode.X) && delay <= delayLimit) {
			inputX = true;
		} else if(Input.GetKeyDown(KeyCode.Z)){
			MoveLeft();
			DelayOver ();
		}  else if(Input.GetKeyDown(KeyCode.X)){
			MoveRight();
			DelayOver ();
		}

		delay += Time.deltaTime;
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

	void MoveUp(){
		rb2d.velocity = new Vector2 (rb2d.velocity.x, 0f);
		rb2d.AddForce (Vector2.up * force);
		Debug.Log ("A");
	}

	void MoveRight(){
		rb2d.velocity = Vector2.right * speed;
		Debug.Log ("R");
	}
	void MoveLeft(){
		Debug.Log ("L");
		rb2d.velocity = Vector2.left * speed;
	}

	void DelayOver(){
		inputX = false;
		inputZ = false;
		delay = 0;
	}

}
