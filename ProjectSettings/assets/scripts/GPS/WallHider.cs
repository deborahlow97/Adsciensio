using UnityEngine;
using System.Collections;

public class WallHider : MonoBehaviour {

	// Update is called once per frame
	void Update() {
		if (GetComponent<Renderer>() != null) {
			GetComponent<Renderer>().enabled = SharedValues.GetInstance().areWallsShown;
		}
	}
}
