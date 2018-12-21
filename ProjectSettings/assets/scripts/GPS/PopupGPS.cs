using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PopupGPS : MonoBehaviour {

	public GameObject PopupTextBox;
	public Image fadeToBlack;
	public Image skull;
	public AudioSource musicSource;
	public AudioClip gameOver;

	private SharedValues sharedValues = SharedValues.GetInstance();
	private int displayedState = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (displayedState == 0 && sharedValues.hasGameStarted) {
			if (sharedValues.win) {
				SetUIState(true);
				PopupTextBox.GetComponent<Text>().text = "You win!\nPress \"Enter\" to continue";
				sharedValues.crossWinState = sharedValues.crossWinState | (1 << sharedValues.level);
				displayedState = 2;
			}
			else if (sharedValues.hasGameStarted && sharedValues.isGameOver) {
				SetUIState(true);
				PopupTextBox.GetComponent<Text>().text = "You and your crew all died.\nPress \"r\" to restart";
				skull.enabled = true;
				musicSource.clip = gameOver;
				musicSource.Play();
				displayedState = 1;
			}
		}
		if (displayedState == 1) {
			Color nextColour = fadeToBlack.color;
			if (nextColour.a != 1) {
				nextColour.a = nextColour.a + 0.009F;
				if (nextColour.a > 0.99F) {
					nextColour.a = 1;
				}
				fadeToBlack.color = nextColour;
			}
		}
		if (displayedState == 2 && Input.GetKeyDown("return")) {
			SceneManager.LoadScene("main");
		}
	}

	void SetUIState(bool state) {
		PopupTextBox.SetActive(state);
		GetComponent<Image>().enabled = state;
	}

}
