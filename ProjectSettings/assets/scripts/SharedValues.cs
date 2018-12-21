using UnityEngine;
using System.Collections;

public class SharedValues {

	private static SharedValues sharedValues = null;

	// these values are specific to one level only
	public int holesSpawned;
	public int wallFrames;
	public bool areWallsShown;
	public int timeLeft;
	public int trapDisplayState;
	public int trapDisplayStateTime;
	public bool isStunned;
	public int stunnedTime;
	public bool hasGameStarted;
	public bool isGameOver;
	public bool win;
	public int level;

	// these values are shared across scenes
	public int crossWinState = 0;
	public int counterNumber = 1843;

	public static SharedValues GetInstance() {
		if (sharedValues == null) {
			sharedValues = new SharedValues();
		}

		return sharedValues;
	}
}
