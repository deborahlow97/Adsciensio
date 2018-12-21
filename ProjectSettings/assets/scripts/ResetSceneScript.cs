using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetSceneScript : MonoBehaviour {

	private SharedValues sharedValues;

	// Use this for initialization
	void Start () {
		sharedValues = SharedValues.GetInstance();
		switch (sharedValues.level) {
			case 0:
				SceneManager.LoadScene("level1");
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
