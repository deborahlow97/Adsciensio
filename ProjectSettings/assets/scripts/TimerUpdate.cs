using UnityEngine;
using System.Collections;

public class TimerUpdate : MonoBehaviour {

	private SharedValues sharedValues = SharedValues.GetInstance();

	void Update() {
		if (sharedValues.hasGameStarted && !sharedValues.isGameOver) {
			sharedValues.wallFrames--;
			if (!sharedValues.areWallsShown && sharedValues.wallFrames < 0) {
				sharedValues.areWallsShown = true;
			}

			sharedValues.timeLeft--;

			sharedValues.trapDisplayStateTime--;
			if (sharedValues.trapDisplayStateTime < 0) {
				sharedValues.trapDisplayState++;
				if (sharedValues.trapDisplayState == 4) {
					sharedValues.trapDisplayState = 1;
				}
				sharedValues.trapDisplayStateTime = 180;
			}

			/*
			sharedValues.confusedTime--;
			if (sharedValues.confusedTime <= 0) {
				sharedValues.confusedFactor = 1;
			}
			*/

			sharedValues.stunnedTime--;
			if (sharedValues.stunnedTime <= 0) {
				sharedValues.isStunned = false;
			}
		}
	}
}
