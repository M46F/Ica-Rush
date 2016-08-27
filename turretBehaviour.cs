using UnityEngine;
using System.Collections;

public class turretBehaviour : MonoBehaviour {
	public Rigidbody2D projectile;
	void Shoot(){
		Vector3 pos = transform.position;
		Rigidbody2D instance = (Rigidbody2D)Instantiate(projectile,transform.position,transform.rotation);
		instance.transform.parent = transform;
		instance.velocity = new Vector2 (1, 0);
	}
	void Update(){
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity=new Vector2(0,-1);
	}
	void Awake() {
		//InvokeRepeating("Shoot", 0, 0.3F);
		Shoot();
	}
}
