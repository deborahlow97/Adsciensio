using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WallTimeUI : MonoBehaviour {

	private Text wallTimeUI;
	private SharedValues sharedValues = SharedValues.GetInstance();

	// Use this for initialization
	void Start () {
		wallTimeUI = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!sharedValues.areWallsShown) {
			string timeLeftString = (sharedValues.wallFrames / 60.0F).ToString("0.00");
			wallTimeUI.text = "Lights out!: " + timeLeftString + "s";
		}
		else {
			wallTimeUI.text = "";
		}
	}
}
