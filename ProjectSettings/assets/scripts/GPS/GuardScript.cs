using UnityEngine;
using System.Collections;

public class GuardScript : MonoBehaviour {

	private Rigidbody2D rb2d;

	private int direction;
	private int frames;
	private const float MOVEMENT_PER_FRAME = 0.01875F;
	private const int FRAMES_TABU = 15;
	private const int REVERSE_PENALTY = 2;
	private SharedValues sharedValues = SharedValues.GetInstance();
	private int[] lastCollision = {0, 0, 0, 0};
	private const int FRAMES_MIN = 10;
	private const int FRAMES_MAX = 20;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (sharedValues.hasGameStarted && !sharedValues.isGameOver) {
			if (frames <= 0) {
				direction = Random.Range(0, 4);
				while (lastCollision[direction] > 0) {
					direction = Random.Range(0, 4);
					// avoiding infinite loop
					for (int i = 0; i < 4; i++) {
						lastCollision[i]--;
					}
				}
				int oppDirection = direction + 2;
				if (oppDirection >= 4) {
					oppDirection -= 4;
				}
				frames = Random.Range(FRAMES_MIN, FRAMES_MAX + 1);
				lastCollision[oppDirection] = frames + REVERSE_PENALTY;
			}
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
			for (int i = 0; i < 4; i++) {
				lastCollision[i]--;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		frames = 0;
		// back away from given direction
		switch (direction) {
			case 2:
				transform.Translate(Vector2.up * MOVEMENT_PER_FRAME);
				break;
			case 3:
				transform.Translate(Vector2.right * MOVEMENT_PER_FRAME);
				break;
			case 0:
				transform.Translate(Vector2.down * MOVEMENT_PER_FRAME);
				break;
			case 1:
				transform.Translate(Vector2.left * MOVEMENT_PER_FRAME);
				break;
		}
		int oppDirection = direction + 2;
		if (oppDirection >= 4) {
			oppDirection -= 4;
		}
		lastCollision[direction] = FRAMES_TABU;
		lastCollision[oppDirection] -= frames + REVERSE_PENALTY;
	}
}
