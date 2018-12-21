using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovementGPSNonGrid : MonoBehaviour {

	public Text timeDeductionText;

	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	private const float MOVEMENT_PER_FRAME = 0.01875F;
	private SharedValues sharedValues = SharedValues.GetInstance();
	private int timeDeduction;
	private int timeInvincible;
	private int timeInvincibleLeft = 0;

	// Use this for initialization
	void Start() {
		FixedParameters fp = FixedParameters.GetInstance();
		timeDeduction = fp.timeDeduction;
		timeInvincible = fp.timeInvincible;
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update() {
		if (sharedValues.hasGameStarted && !sharedValues.isGameOver) {
			timeInvincibleLeft -= 1;
			if (timeInvincibleLeft > 0) {
				timeDeductionText.text = "-" + (timeDeduction / 60) + " s! Hit by guard";
				if (timeInvincibleLeft % 4 < 2) {
					sr.enabled = true;
				}
				else {
					sr.enabled = false;
				}
			}
			else {
				timeDeductionText.text = "";
			}
		}
	}

	void FixedUpdate() {
		if (sharedValues.hasGameStarted && !sharedValues.isGameOver) {
			float h = Input.GetAxis("Horizontal");

			float v = Input.GetAxis("Vertical");

			Vector2 movement = (Vector2.up * v * MOVEMENT_PER_FRAME) + (Vector2.right * h * MOVEMENT_PER_FRAME);

			transform.Translate(movement);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Enemy") && timeInvincibleLeft < 0) {
			sharedValues.timeLeft -= timeDeduction;
			timeInvincibleLeft = timeInvincible;
		}
	}

}
