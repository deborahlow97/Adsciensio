using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeLeftUI : MonoBehaviour {

	private Text timeLeftUI;
	private SharedValues sharedValues = SharedValues.GetInstance();

	// Use this for initialization
	void Start () {
		timeLeftUI = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (sharedValues.timeLeft > 0) {
			string timeLeftString = (sharedValues.timeLeft / 60.0F).ToString("0.00");
			timeLeftUI.text = "Time Left: " + timeLeftString + "s";
		}
		else {
			timeLeftUI.text = "Time up!";
			sharedValues.isGameOver = true;
		}
		if (sharedValues.timeLeft < 1800) {
			timeLeftUI.color = Color.red;
		}
	}
}
