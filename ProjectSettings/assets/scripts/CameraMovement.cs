using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject player;

	private bool isOverview = false;
	private Vector3 offset;
	private Vector3 mazeCentre;
	private float nextSize;
	private Camera playerCamera;

	private SharedValues sharedValues = SharedValues.GetInstance();

	// Use this for initialization
	void Start() {
		FixedParameters fp = FixedParameters.GetInstance();
		float x = fp.numCols * fp.WALL_DISTANCE / 2.0F;
		float y = -fp.numRows * fp.WALL_DISTANCE / 2.0F;
		mazeCentre = new Vector3(x, y, -10);
		nextSize = Mathf.Max(x * 0.5625F, -y * 1.125F);
		offset = transform.position - player.transform.position;
		playerCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown("space") && sharedValues.hasGameStarted && !sharedValues.isGameOver) {
			isOverview = !isOverview;
			float tempSize = nextSize;
			nextSize = playerCamera.orthographicSize;
			playerCamera.orthographicSize = tempSize;
		}

		if (!isOverview) {
			transform.position = player.transform.position + offset;
		}

		else {
			transform.position = mazeCentre;
		}
	}
}
