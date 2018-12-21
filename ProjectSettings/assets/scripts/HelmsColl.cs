using UnityEngine;
using System.Collections;

public class HelmsColl : MonoBehaviour {

	public GameObject logic;
	public GameObject dialogue;

	void OnTriggerEnter2D(Collider2D other) {
		if (logic.GetComponent<StartupMain>().dialogueState == 0) {
			dialogue.GetComponent<DialogueMain>().StartDialogue(1);
			logic.GetComponent<StartupMain>().dialogueState++;
		}
		else if (logic.GetComponent<StartupMain>().dialogueState == 3) {
			dialogue.GetComponent<DialogueMain>().StartDialogue(14);
			logic.GetComponent<StartupMain>().dialogueState++;
		}
	}
}
