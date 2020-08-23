using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

	public GameObject moon; 
	public GameObject collectable;
	public Vector3 spawnValue;
	public float spawnLeast; // least amount of wait time
	public float spawnMost; // most amount of wait time
	public int startTime;//starts the spawn
	public int SK = 0;
	public int maxStars = 30;

	// Use this for initialization
	void Start () {
				StartCoroutine(WaitSpawn());
	}
	
	// Update is called once per frame
	void Update () {
		if (moon.transform.position.y < 0) {
			GameObject[] stars = GameObject.FindGameObjectsWithTag("star");
			foreach(GameObject o in stars){
				//o.gameObject.SetActive(false);
				Destroy (o);
				SK--;
			}
		}
		/*if (moon.transform.position.y >= 0) {
			GameObject[] stars = GameObject.FindGameObjectsWithTag ("star");
			foreach (GameObject o in stars) {
				o.gameObject.SetActive (true);
			}
		}*/
	}
	IEnumerator WaitSpawn() {
		yield return new WaitForSeconds(startTime);
		while (SK<maxStars) {
			Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 0.5f, Random.Range(-spawnValue.z, spawnValue.z));
			GameObject skism = (GameObject)Instantiate(collectable, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
			skism.tag = "star";
			skism.transform.parent = transform;
			SK++;
			yield return new WaitForSeconds(Random.Range(0.2f, 1f));
		}
	}
}
