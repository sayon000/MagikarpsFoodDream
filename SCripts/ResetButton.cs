using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour {
	
	public Button reset;

	void Start () {
		Button butt = reset.GetComponent<Button>();
		butt.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick () {
		Application.LoadLevel ("Pizza Karp");
	}
}
