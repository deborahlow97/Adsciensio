using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {

	public GameObject bhscriptContainer;

	private bool hasBlock = false;
	private BlockHoleScript bhscript;

	public void GetScript() {
		bhscript = bhscriptContainer.GetComponent<BlockHoleScript>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!hasBlock && !other.isTrigger && other.gameObject.CompareTag("Block")) {
			DisableRotation drscript = other.gameObject.GetComponent<DisableRotation>();
			if (drscript != null) {
				bool isBlockActive = drscript.GetPhysicsState();
				if (isBlockActive) {
					other.gameObject.transform.position = transform.position;
					drscript.SetPhysicsState(false);
					hasBlock = true;
					GetComponent<SpriteRenderer>().enabled = false;
					bhscript.SpawnNewBlockHolePair();
				}
			}
		}
	}
}
