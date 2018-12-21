using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CallReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("r")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
