using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlocksPlacedUI : MonoBehaviour {

	private SharedValues sharedValues = SharedValues.GetInstance();
	private Text blocksPlacedUI;

	private int numHoles;

	// Use this for initialization
	void Start () {
		FixedParameters fp = FixedParameters.GetInstance();
		numHoles = fp.numHoles;
		blocksPlacedUI = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		blocksPlacedUI.text = (sharedValues.holesSpawned - 1) + "/" + numHoles + " blocks";
	}
}
