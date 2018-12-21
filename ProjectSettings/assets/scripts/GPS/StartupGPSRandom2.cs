using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartupGPSRandom2 : MonoBehaviour {

	public GameObject wall;
	public GameObject trap;
	public GameObject guard;

	private float WALL_DISTANCE;
	private float HALF_WALL_DISTANCE;
	private float QUARTER_WALL_DISTANCE;

	private int numRows;
	private int numCols;
	private int trapCount;
	private int numGuards;

	private int[,] horizontalWalls;

	private int[,] verticalWalls;

	private int[,] visited;

	private int[,] traps;

	private int[,] guards;

	private List<Border> borderList;

	// Use this for initialization
	void Start() {
		FixedParameters fp = FixedParameters.GetInstance();
		WALL_DISTANCE = fp.WALL_DISTANCE;
		HALF_WALL_DISTANCE = fp.HALF_WALL_DISTANCE;
		QUARTER_WALL_DISTANCE = fp.QUARTER_WALL_DISTANCE;

		numRows = fp.numRows;
		numCols = fp.numCols;
		trapCount = fp.trapCount;
		numGuards = fp.numGuards;


		horizontalWalls = new int[numRows + 1, numCols];

		verticalWalls = new int[numRows, numCols + 1];

		visited = new int[numRows, numCols];

		traps = new int[trapCount, 2];

		guards = new int[numGuards, 2];

		borderList = new List<Border>();



		for (int i = 0; i < horizontalWalls.GetLength(0); i++) {
			for (int j = 0; j < horizontalWalls.GetLength(1); j++) {
				horizontalWalls[i, j] = 1;
			}
		}

		for (int i = 0; i < verticalWalls.GetLength(0); i++) {
			for (int j = 0; j < verticalWalls.GetLength(1); j++) {
				verticalWalls[i, j] = 1;
			}
		}

		for (int i = 0; i < visited.GetLength(0); i++) {
			for (int j = 0; j < visited.GetLength(1); j++) {
				visited[i, j] = 0;
			}
		}

		//horizontalWalls[numRows, numCols - 1] = 0;
		//verticalWalls[0, 0] = 0;

		for (int i = 0; i < traps.GetLength(0); i++) {
			traps[i, 0] = Random.Range(0, numRows * 2);
			traps[i, 1] = Random.Range(0, numCols * 2);
			while (traps[i, 0] == 0 && traps[i, 1] == 0) {
				traps[i, 0] = Random.Range(0, numRows * 2);
				traps[i, 1] = Random.Range(0, numCols * 2);
			}
		}

		for (int i = 0; i < guards.GetLength(0); i++) {
			guards[i, 0] = Random.Range(0, numRows * 2);
			guards[i, 1] = Random.Range(0, numCols * 2);
		}



		ProcessCell(numRows - 1, numCols - 1);
		while (borderList.Count > 0) {
			int index = Random.Range(0, borderList.Count);
			Border borderToProcess = borderList[index];
			Border nextBorder = borderList[borderList.Count - 1];
			borderList[index] = nextBorder;
			borderList.RemoveAt(borderList.Count - 1);
			ProcessWall(borderToProcess.orientation, borderToProcess.arrRow, borderToProcess.arrCol);
		}

		// walls
		for (int i = 0; i < horizontalWalls.GetLength(0); i++) {
			for (int j = 0; j < horizontalWalls.GetLength(1); j++) {
				if (horizontalWalls[i, j] == 1) {
					Instantiate(wall, new Vector2((j * WALL_DISTANCE) + HALF_WALL_DISTANCE, -(i * WALL_DISTANCE)), Quaternion.identity);
				}
			}
		}
		for (int i = 0; i < verticalWalls.GetLength(0); i++) {
			for (int j = 0; j < verticalWalls.GetLength(1); j++) {
				if (verticalWalls[i, j] == 1) {
					Instantiate(wall, new Vector2(j * WALL_DISTANCE, -((i * WALL_DISTANCE) + HALF_WALL_DISTANCE)), Quaternion.Euler(0, 0, 90));
				}
			}
		}

		// traps
		for (int i = 0; i < traps.GetLength(0); i++) {
			int trapRow = traps[i, 0];
			int trapCol = traps[i, 1];
			GameObject newWall = (GameObject)Instantiate(trap, new Vector2(trapCol * HALF_WALL_DISTANCE + QUARTER_WALL_DISTANCE,
				                                                           -(trapRow * HALF_WALL_DISTANCE) - QUARTER_WALL_DISTANCE), Quaternion.identity);
			newWall.GetComponent<TrapGPS>().trapStateOn = ((trapRow + trapCol) % 3) + 1;
		}

		// guards
		for (int i = 0; i < guards.GetLength(0); i++) {
			int guardRow = traps[i, 0];
			int guardCol = traps[i, 1];
			Instantiate(guard, new Vector2(guardCol * HALF_WALL_DISTANCE + QUARTER_WALL_DISTANCE,
				                           -(guardRow * HALF_WALL_DISTANCE) - QUARTER_WALL_DISTANCE), Quaternion.identity);
		}

	}

	void ProcessWall(int orientation, int row, int col) {
		if (orientation == 0) {
			if (CheckState(row - 1, col) + CheckState(row, col) == 1) {
				horizontalWalls[row, col] = 0;
				ProcessCell(row - 1, col);
				ProcessCell(row, col);
			}
		}
		else {
			if (CheckState(row, col - 1) + CheckState(row, col) == 1) {
				verticalWalls[row, col] = 0;
				ProcessCell(row, col - 1);
				ProcessCell(row, col);
			}
		}
	}

	int CheckState(int row, int col) {
		if (row < 0 || row >= numRows || col < 0 || col >= numCols) {
			return -1000;
		}
		return visited[row, col];
	}

	void ProcessCell(int row, int col) {
		if (visited[row, col] == 1) {
			return;
		}
		visited[row, col] = 1;
		AddBorderHorizontal(row, col);
		AddBorderVertical(row, col);
		AddBorderHorizontal(row + 1, col);
		AddBorderVertical(row, col + 1);
	}

	void AddBorderHorizontal(int row, int col) {
		if (horizontalWalls[row, col] == 1) {
			borderList.Add(new Border(0, row, col));
		}
	}

	void AddBorderVertical(int row, int col) {
		if (verticalWalls[row, col] == 1) {
			borderList.Add(new Border(1, row, col));
		}

	}
}

class Border {
	public int orientation;
	public int arrRow;
	public int arrCol;

	public Border (int orientationIn, int arrRowIn, int arrColIn) {
		orientation = orientationIn;
		arrRow = arrRowIn;
		arrCol = arrColIn;
	}

	public override string ToString() {
		return "(" + orientation + " " + arrRow + " " + arrCol + ")";
	}
}