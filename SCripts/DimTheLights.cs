using UnityEngine;
using System.Collections;

public class DimTheLights : MonoBehaviour {

	public GameObject obj;
	public Light lite;
	public float low;
	public float high;
	
	// Update is called once per frame
	void Update () {
		if (obj.transform.position.y < 0) {
			lite.intensity = low;
		}
		if (obj.transform.position.y >= 0) {
			lite.intensity = high;
		}
	}
}
