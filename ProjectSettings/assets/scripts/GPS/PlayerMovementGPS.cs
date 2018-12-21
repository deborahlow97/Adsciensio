using UnityEngine;
using System.Collections;

public class PlayerMovementGPS : MonoBehaviour {

	private Rigidbody2D rb2d;
	private bool moving = false;
	private int frames = 0;
	private int direction = 0;
	private const int MOVEMENT_FRAMES = 10;
	private const float MOVEMENT_PER_FRAME = 0.0125F;
	private SharedValues sharedValues = SharedValues.GetInstance();

	// Use this for initialization
	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	void FixedUpdate() {

		float h = Input.GetAxis("Horizontal");

		if (h != 0 && !moving && !sharedValues.isStunned) {
			if (Mathf.Sign(h) > 0) {
				direction = 1;
			}
			else {
				direction = 3;
			}
			moving = true;
			frames = MOVEMENT_FRAMES;
		}

		float v = Input.GetAxis("Vertical");

		if (v != 0 && !moving && !sharedValues.isStunned) {
			if (Mathf.Sign(v) > 0) {
				direction = 0;
			}
			else {
				direction = 2;
			}
			moving = true;
			frames = MOVEMENT_FRAMES;
		}

		if (moving) {
			if (frames > 0) {
				switch (direction) {
					case 0:
						transform.Translate(Vector2.up * MOVEMENT_PER_FRAME);
						break;
					case 1:
						transform.Translate(Vector2.right * MOVEMENT_PER_FRAME);
						break;
					case 2:
						transform.Translate(Vector2.down * MOVEMENT_PER_FRAME);
						break;
					case 3:
						transform.Translate(Vector2.left * MOVEMENT_PER_FRAME);
						break;
				}
				frames--;
			}
			else {
				moving = false;
				frames = 0;
			}
		}
	}

	// used to stop upon colliding with a wall
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag.Equals("Wall")) {
			// attempt to move the player away from the collision
			switch (direction) {
				case 0:
					transform.Translate(Vector2.down * MOVEMENT_PER_FRAME);
					break;
				case 1:
					transform.Translate(Vector2.left * MOVEMENT_PER_FRAME);
					break;
				case 2:
					transform.Translate(Vector2.up * MOVEMENT_PER_FRAME);
					break;
				case 3:
					transform.Translate(Vector2.right * MOVEMENT_PER_FRAME);
					break;
			}

			moving = false;
			frames = 0;
		}
	}
}
