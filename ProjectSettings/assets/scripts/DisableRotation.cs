using UnityEngine;
using System.Collections;

public class DisableRotation : MonoBehaviour {

	public Sprite blockActive;

	private Rigidbody2D rb2d;
	private bool physicsActive = true;
	private BoxCollider2D[] colliders;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
		colliders = GetComponents<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.CompareTag("Player") && physicsActive) {
			float h = Input.GetAxis("Fire3");
			Vector3 offset = (other.transform.position - transform.position);
			transform.Translate(offset * h * 0.15F);
		}
	}

	public void SetPhysicsState(bool state) {
		physicsActive = state;
		foreach (BoxCollider2D collider in colliders) {
			collider.enabled = state;
		}
		if (state) {
			GetComponent<SpriteRenderer>().sprite = blockActive;
		}
		else {
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}

	public bool GetPhysicsState() {
		return physicsActive;
	}
}
