using System.Collections;
using UnityEngine;

public class EnemyLaserBehaviour : MonoBehaviour {


	public float delayAttackTime;
	public float laserDelay; 
	public float tileSpeed;

	private float lastAttack = 0;
	private Rigidbody2D rb2d;

	//Gameobject laser harus menjadi anak dari gameobject ini
	public GameObject laser;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastAttack + delayAttackTime) {
			Shoot ();
			lastAttack = Time.time;
		}
		if (Time.time > lastAttack + laserDelay) {
			laser.SetActive(false);
		}
	}

	void FixedUpdate(){
		rb2d.velocity = Vector2.down * tileSpeed;
	}

	void Shoot(){
		Debug.Log ("SHOOT");
		laser.SetActive(true);
	}
}
