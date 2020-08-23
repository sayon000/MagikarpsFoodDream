using UnityEngine;
using System.Collections;

public class ShootHamburgers : MonoBehaviour {

	public Rigidbody projectile;
	public float speed;
	
	// Update is called once per frame
	

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Rigidbody clone;
			clone = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * speed);
			clone.tag = "Destroy";
		}
		GameObject[] obj = GameObject.FindGameObjectsWithTag ("Destroy");
		foreach (GameObject o in obj) {
			DestroyObject (o, 2.0f);
		}
	}
}
