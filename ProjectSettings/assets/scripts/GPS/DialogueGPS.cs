using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueGPS : MonoBehaviour {

	public GameObject dialogueTextBox;
	public GameObject rightDialogueImage;
	public GameObject instructions;

	public Sprite capn;
	public Sprite doc;
	public Sprite engie;
	public Sprite helms;

	private SharedValues sharedValues = SharedValues.GetInstance();
	private int currentDialogueState = 0;
	private int[] nextDialogueState = {-1};

	private int requireInitialInstructions;

	private string[,] dialogues = {
		{"capn", "hi"},
	};


	// Use this for initialization
	void Start () {
		FixedParameters fp = FixedParameters.GetInstance();
		requireInitialInstructions = fp.requireInitialInstructions;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("return")) {
			if (currentDialogueState != -1) {
				if (nextDialogueState[currentDialogueState] == -1) {
					SetUIState(false);
					if (requireInitialInstructions != 0) {
						SetInstructionState(true);
					}
					else {
						SetInstructionState(false);
						sharedValues.hasGameStarted = true;
					}
					currentDialogueState = -1;
				}
				else {
					SetDialogue(dialogues[nextDialogueState[currentDialogueState], 0], dialogues[nextDialogueState[currentDialogueState], 1]);
					currentDialogueState = nextDialogueState[currentDialogueState];
				}
			}
			else {
				SetUIState(false);
				SetInstructionState(false);
				sharedValues.hasGameStarted = true;
			}
		}
		if (Input.GetKeyDown("f1")) {
			if (!instructions.GetComponent<Image>().enabled) {
				SetInstructionState(true);
				sharedValues.hasGameStarted = false;
			}
			else {
				SetInstructionState(false);
				if (currentDialogueState == -1) {
					sharedValues.hasGameStarted = true;
				}
			}
		}
	}

	public void StartDialogue(int index) {
		SetUIState(true);
		SetDialogue(dialogues[index, 0], dialogues[index, 1]);
		currentDialogueState = index;
		sharedValues.hasGameStarted = false;
	}

	void SetDialogue(string rightImage, string dialogue) {
		switch(rightImage) {
			case "capn":
				SetRightImage(capn);
				break;
			case "doc":
				SetRightImage(doc);
				break;
			case "engie":
				SetRightImage(engie);
				break;
			case "helms":
				SetRightImage(helms);
				break;
		}
		dialogueTextBox.GetComponent<Text>().text = dialogue;
	}

	void SetRightImage(Sprite sprite) {
		rightDialogueImage.GetComponent<Image>().sprite = sprite;
	}

	void SetUIState(bool state) {
		dialogueTextBox.SetActive(state);
		rightDialogueImage.SetActive(state);
		GetComponent<Image>().enabled = state;
	}

	void SetInstructionState(bool state) {
		instructions.GetComponent<Image>().enabled = state;
	}

}
