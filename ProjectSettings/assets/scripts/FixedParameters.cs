using UnityEngine;
using System.Collections;

public class FixedParameters {

	// maze dimensions
	public float WALL_DISTANCE;
	public float HALF_WALL_DISTANCE;
	public float QUARTER_WALL_DISTANCE;

	public int numRows;
	public int numCols;
	public int trapCount;

	public int numHoles;

	public int timeout;

	public int numGuards;

	public int timeDeduction;
	public int timeInvincible;

	public int requireInitialInstructions;

	private static FixedParameters inst;

	public static FixedParameters GetInstance() {
		return inst;
	}

	public static void generateParameters(float wall_dist, int rows, int cols, int traps, int holes,
		                                  int timeout, int numGuards, int timeDeduction, int timeInvincible, int requireInitialInstructions) {
		inst = new FixedParameters();

		inst.WALL_DISTANCE = wall_dist;
		inst.HALF_WALL_DISTANCE = 0.5F * wall_dist;
		inst.QUARTER_WALL_DISTANCE = 0.25F * wall_dist;

		inst.numRows = rows;
		inst.numCols = cols;
		inst.trapCount = traps;

		inst.numHoles = holes;

		inst.timeout = timeout;

		inst.numGuards = numGuards;

		inst.timeDeduction = timeDeduction;
		inst.timeInvincible = timeInvincible;

		inst.requireInitialInstructions = requireInitialInstructions;
	}
}
