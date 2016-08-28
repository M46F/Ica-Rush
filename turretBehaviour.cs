using UnityEngine;
using System.Collections;

public class turretBehaviour : MonoBehaviour {
	public Rigidbody2D projectile;
	public float speed;
	public Transform player;
	public float downSpeed;
	public float delay;
	void Shoot(){
		Vector3 pos = transform.position;
		Rigidbody2D instance = (Rigidbody2D)Instantiate(projectile,transform.position,transform.rotation);
		instance.transform.parent = transform;
		Vector2 arah = player.position - transform.position;
		instance.velocity = arah.normalized*speed;
	}
	void Update(){
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity=new Vector2(0,-1)*downSpeed;
	}
	void Awake() {
		InvokeRepeating("Shoot", 0, delay);
	}
}
