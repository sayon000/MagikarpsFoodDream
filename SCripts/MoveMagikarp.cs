using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MoveMagikarp : MonoBehaviour {

	public AudioClip leedle;
	public AudioClip boom;
	public float speed;
	public float jumpSpeed;
	public Rigidbody rb;
	public int points = 0;
	public Text numText;
	public Text victoryText;
	public GameObject moon;
	public Button butt;

	
	void Start () {
		rb = GetComponent<Rigidbody> ();
		SetNumText ();
		victoryText.text = "";

	}
	

	void FixedUpdate () {
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		float moveUp = Input.GetAxis ("Jump");
		Vector3 movement = new Vector3 (0, moveUp*jumpSpeed, 0);
		rb.AddForce (movement); //forces are vectors

		if (points >= 12 && moon.transform.position.y > 0) {
			if(Input.GetKey(KeyCode.Space)){
				transform.position = moon.transform.position;
			}
		}

	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive(false);
			points++;
			AudioSource.PlayClipAtPoint(leedle,transform.position);
			SetNumText();
		}
		if (other.gameObject.CompareTag ("Kill")) {
			Destroy(other.gameObject);
			points++;
			AudioSource.PlayClipAtPoint(leedle,transform.position);
			SetNumText();
		}
		if (other.gameObject.CompareTag ("moon")) {
			other.gameObject.SetActive(false);
			AudioSource.PlayClipAtPoint(boom,transform.position);
			butt.gameObject.SetActive(true);
		}
	}

	void SetNumText ()
	{
		numText.text = "Dews Consumed: " + points.ToString ();
		if (points >= 12)
		{
			victoryText.text = "CONGLATURATION!! YOU CAN NOW TELEPORT TO THE MOON WITH SPACE TO WIN.";
		}
	}

}
