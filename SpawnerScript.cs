using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {


	public GameObject[] prefabs;
	public float delay = 2.0f;
	public bool active = true;
	public float batasKanan = 9f;
	public float batasKiri = 7f;
	public float minX = 0;
	public float maxX = 20;
	public float speed = 5;

	public Vector2 delayRange = new Vector2(1, 2);

	// Use this for initialization
	void Start () {
		ResetDelay ();
		StartCoroutine (EnemyGenerator ());
	}

	IEnumerator EnemyGenerator(){

		yield return new WaitForSeconds (delay);
		int type = Random.Range (0, 5);
		/*
		0. batu
		1. turret
		2. laser
		3. turret dan batu
		4. batu dan laser
		*/
		switch (type) {
		case(0):
			{
				float x = Random.Range (minX, maxX);
				Summon (0, x, speed);
				break;
			}
		case(1):
			{
				int x = Random.Range (0, 1);
				if (x >= 1)
					x = (int) batasKiri;
				else
					x = (int) batasKanan;
				Summon (1, x, speed);
				break;
			}
		case(2):
			{
				Summon (2, batasKiri, speed);
				Summon (2, batasKanan, speed);
				break;
			}
		case(3):
			{
				float x = Random.Range (minX, maxX);
				Summon (0, x, speed);
				x = Random.Range (0, 1);
				if (x >= 1)
					x = batasKiri;
				else
					x = batasKanan;
				Summon (1, x, speed);
				break;
			}
		case(4):
			{
				float x = Random.Range (minX, maxX);
				Summon (0, x, speed);
				Summon (2, batasKiri, speed);
				Summon (2, batasKanan, speed);
				break;
			}
		}

		ResetDelay();
		StartCoroutine (EnemyGenerator ());

	}

	void ResetDelay(){
		delay = Random.Range (delayRange.x, delayRange.y);
	}

	void Summon(int i, float x,float speed){
		GameObject  instance = (GameObject) Instantiate(prefabs[i],new Vector3(x,this.transform.position.y,0), transform.rotation);
		instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1*speed);
	}


}
