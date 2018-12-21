using UnityEngine;
using System.Collections;

public class TrapGPS : MonoBehaviour {

	public int trapStateOn;

	private SharedValues sharedValues = SharedValues.GetInstance();
	private int timeout;

	void Start() {
		FixedParameters fp = FixedParameters.GetInstance();
		timeout = fp.timeout;
	}

	void Update() {
		if (GetComponent<Renderer>() != null) {
			GetComponent<Renderer>().enabled = (sharedValues.trapDisplayState == trapStateOn);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Block") && !other.isTrigger)
			&& sharedValues.trapDisplayState == trapStateOn) {
			sharedValues.areWallsShown = false;
			sharedValues.wallFrames = timeout;
			gameObject.SetActive(false);
		}
	}
}
