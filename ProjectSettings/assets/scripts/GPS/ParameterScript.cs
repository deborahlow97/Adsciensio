using UnityEngine;
using System.Collections;

public class ParameterScript : MonoBehaviour {

	private float wallDistance = 0.25F;

	public int numRows;
	public int numCols;
	public int trapCount;
	public int numGuards;

	public float timeDeduction;
	public float timeInvincible;

	public int numHoles;
	public float gameTime;

	public float timeout;

	public int requireInitialInstructions;

	public int level;

	// Use this for initialization
	void Awake () {
		FixedParameters.generateParameters(wallDistance, numRows, numCols, trapCount, numHoles,
			                               Mathf.CeilToInt(timeout * 60), numGuards, Mathf.CeilToInt(timeDeduction * 60), Mathf.CeilToInt(timeInvincible * 60),
			                               requireInitialInstructions);
	    SharedValues sharedValues = SharedValues.GetInstance();
	    sharedValues.timeLeft = Mathf.CeilToInt(gameTime * 60);
	    sharedValues.level = level;

	    // other stuff
		sharedValues.holesSpawned = 0;
		sharedValues.wallFrames = 0;
		sharedValues.areWallsShown = true;
		sharedValues.trapDisplayState = 1;
		sharedValues.trapDisplayStateTime = 120;
		sharedValues.isStunned = false;
		sharedValues.stunnedTime = 0;
		sharedValues.hasGameStarted = false;
		sharedValues.isGameOver = false;
		sharedValues.win = false;
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
