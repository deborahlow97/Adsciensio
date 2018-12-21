using UnityEngine;
using System.Collections;

public class EngieColl : MonoBehaviour {

	public GameObject logic;
	public GameObject dialogue;

	void OnTriggerEnter2D(Collider2D other) {
		if (logic.GetComponent<StartupMain>().dialogueState == 5) {
			dialogue.GetComponent<DialogueMain>().StartDialogue(22);
			logic.GetComponent<StartupMain>().dialogueState++;
		}
		else if (logic.GetComponent<StartupMain>().dialogueState == 8) {
			dialogue.GetComponent<DialogueMain>().StartDialogue(35);
			logic.GetComponent<StartupMain>().dialogueState++;
		}
	}
}
