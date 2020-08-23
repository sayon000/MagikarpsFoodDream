using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MakeSound : MonoBehaviour {
	
	public AudioClip DaSound;

	void Start () {
		GetComponent<AudioSource>().playOnAwake = false;
		GetComponent<AudioSource>().clip = DaSound;
	}
	
	void onTriggerEnter(){
		AudioSource.PlayClipAtPoint(DaSound,transform.position);
	}
}
