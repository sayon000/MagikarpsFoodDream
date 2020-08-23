using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStuff: MonoBehaviour {
	
	//public GameObject[] stuff; // way to get a array of enemies 
	//--> then have a private int to call randomly 
	public GameObject collectable;
	public Vector3 spawnValue;
	public float spawnWait;
	public float spawnLeast; // least amount of wait time
	public float spawnMost; // most amount of wait time
	public int startTime;//starts the spawn
	public int maxSpawn;
	public int spawns = 0;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(WaitSpawn());
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (Vector3.zero, Vector3.left, 30 * Time.deltaTime);
		spawnWait = Random.Range(spawnLeast, spawnMost);
	}
	IEnumerator WaitSpawn() {
		yield return new WaitForSeconds(startTime);
		while(spawns < maxSpawn) {
			spawns++;
			Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 0.5f, Random.Range(-spawnValue.z, spawnValue.z));
			Instantiate(collectable, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
			yield return new WaitForSeconds(spawnWait);
		}
	}
}