using UnityEngine;
using System.Collections;

public class BlockHoleScript : MonoBehaviour {

	public GameObject block;
	public GameObject hole;
	public GameObject selfobject;

	public Sprite virus1;
	public Sprite virus2;
	public Sprite virus3;

	private SharedValues sharedValues = SharedValues.GetInstance();

	private float HALF_WALL_DISTANCE;
	private float QUARTER_WALL_DISTANCE;

	private int numRows;
	private int numCols;

	public int numHoles;

	private int [,] holes;
	private int [,] blocks;

	// Use this for initialization
	void Start () {
		FixedParameters fp = FixedParameters.GetInstance();
		HALF_WALL_DISTANCE = fp.HALF_WALL_DISTANCE;
		QUARTER_WALL_DISTANCE = fp.QUARTER_WALL_DISTANCE;

		numRows = fp.numRows;
		numCols = fp.numCols;
		numHoles = fp.numHoles;

		holes = new int[numHoles, 2];
		blocks = new int[numHoles, 2];

		for (int i = 0; i < numHoles; i++) {
			holes[i, 0] = Random.Range(0, numRows);
			holes[i, 1] = Random.Range(0, numCols * 2);
			blocks[i, 0] = Random.Range(numRows, numRows * 2);
			blocks[i, 1] = Random.Range(0, numCols * 2);
		}
		SpawnNewBlockHolePair();
	}
	
	public void SpawnNewBlockHolePair() {
		if (sharedValues.holesSpawned < numHoles) {
			SpawnHole(sharedValues.holesSpawned);
			SpawnBlock(sharedValues.holesSpawned);
			sharedValues.holesSpawned++;
		}
		else {
			sharedValues.win = true;
			sharedValues.isGameOver = true;
			sharedValues.holesSpawned++;
		}
	}

	void SpawnHole(int index) {
		int holeRow = holes[index, 0];
		int holeCol = holes[index, 1];
		GameObject newhole = (GameObject)Instantiate(hole, new Vector2(holeCol * HALF_WALL_DISTANCE + QUARTER_WALL_DISTANCE,
			                                      -(holeRow * HALF_WALL_DISTANCE) - QUARTER_WALL_DISTANCE), Quaternion.identity);
		newhole.GetComponent<HoleScript>().bhscriptContainer = selfobject;
		newhole.GetComponent<HoleScript>().GetScript();
		int virusSprite = Random.Range(0, 3);
		Sprite toUse = virus1;
		switch (virusSprite) {
			case 0:
				toUse = virus1;
				break;
			case 1:
				toUse = virus2;
				break;
			case 2:
				toUse = virus3;
				break;
		}
		newhole.GetComponent<SpriteRenderer>().sprite = toUse;
	}

	void SpawnBlock(int index) {
		int blockRow = blocks[index, 0];
		int blockCol = blocks[index, 1];
		Instantiate(block, new Vector2(blockCol * HALF_WALL_DISTANCE + QUARTER_WALL_DISTANCE,
			              -(blockRow * HALF_WALL_DISTANCE) - QUARTER_WALL_DISTANCE), Quaternion.identity);

	}
}
