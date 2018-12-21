using UnityEngine;
using System.Collections;

public class StartupGPSRandom : MonoBehaviour {

	public GameObject wall;
	public GameObject trap;

	protected const float WALL_DISTANCE = 0.25F;
	protected const float HALF_WALL_DISTANCE = 0.5F * WALL_DISTANCE;
	protected const float QUARTER_WALL_DISTANCE = 0.5F * HALF_WALL_DISTANCE;

	private const int numRows = 30;
	private const int numCols = 40;
	private const int trapCount = 300;

	private int[,] horizontalWalls = new int[numRows + 1, numCols];

	private int[,] verticalWalls = new int[numRows, numCols + 1];

	private int[,] visited = new int[numRows, numCols];

	private int[,] traps = new int[trapCount, 2];

	private int[] dr = {-1, 0, 1, 0};
	private int[] dc = {0, 1, 0, -1};

	// Use this for initialization
	void Start() {
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

		horizontalWalls[numRows, numCols - 1] = 0;
		verticalWalls[0, 0] = 0;

		for (int i = 0; i < traps.GetLength(0); i++) {
			traps[i, 0] = Random.Range(0, numRows * 2);
			traps[i, 1] = Random.Range(0, numCols * 2);
		}

		DFS(0, 0);

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
	}

	void DFS(int mazeRow, int mazeCol) {

		visited[mazeRow, mazeCol] = 1;

		while (true) {
			bool[] moves = getValidMoves(mazeRow, mazeCol);
			int numValidMoves = 0;
			int indexValidMove = -1;

			int arrLength = moves.GetLength(0);

			for (int i = 0; i < arrLength; i++) {
				if (moves[i]) {
					numValidMoves++;
					indexValidMove = i;
				}
			}

			if (numValidMoves == 0) {
				break;
			}
			else if (numValidMoves > 1) {
				int triedMove = Random.Range(0, arrLength);
				while (!moves[triedMove]) {
					triedMove = Random.Range(0, arrLength);
				}
				indexValidMove = triedMove;
			}

			switch (indexValidMove) {
				case 0:
					horizontalWalls[mazeRow, mazeCol] = 0;
					break;
				case 1:
					verticalWalls[mazeRow, mazeCol + 1] = 0;
					break;
				case 2:
					horizontalWalls[mazeRow + 1, mazeCol] = 0;
					break;
				case 3:
					verticalWalls[mazeRow, mazeCol] = 0;
					break;
			}

			DFS(mazeRow + dr[indexValidMove], mazeCol + dc[indexValidMove]);
		}
	}

	bool[] getValidMoves(int mazeRow, int mazeCol) {
		bool[] moves = new bool[4];
		for (int i = 0; i < 4; i++) {
			moves[i] = checkValidMove(mazeRow + dr[i], mazeCol + dc[i]);
		}
		return moves;
	}

	bool checkValidMove(int mazeRow, int mazeCol) {
		if (mazeRow < 0 || mazeCol < 0 || mazeRow >= numRows || mazeCol >= numCols) {
			return false;
		}
		return (visited[mazeRow, mazeCol] == 0);
	}
}
