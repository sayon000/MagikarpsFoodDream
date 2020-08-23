using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization

	public Vector3 axis;
	public float speed;
	// Update is called once per frame
	void Update () {
		transform.RotateAround (Vector3.zero, axis, speed * Time.deltaTime);
	}
}
