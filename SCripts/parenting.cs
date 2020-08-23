using UnityEngine;
using System.Collections;

public class parenting : MonoBehaviour{

	// Update is called once per frame
	void Update () {
		transform.RotateAround (new Vector3 (0f, 2f, 0f), Vector3.up, 20f * Time.deltaTime);
	}
}
