using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiscScriptGPS : MonoBehaviour {

	public GameObject player;
	public Text miscTextUI;

	//private SharedValues sharedValues = SharedValues.GetInstance();
	
	// Update is called once per frame
	/*
	void Update () {
		if (!sharedValues.cheat && player.transform.position.x > 2 && player.transform.position.y > 0
			|| player.transform.position.x < 0 && player.transform.position.y < -2) {
			sharedValues.cheat = true;
		}
		if (!sharedValues.win && player.transform.position.x > 9.5F && player.transform.position.y < -7.5F) {
			sharedValues.win = true;
			sharedValues.isGameOver = true;
		}
	}
	*/
}
