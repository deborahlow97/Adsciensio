using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueMain : MonoBehaviour {

	public GameObject dialogueTextBox;
	public GameObject rightDialogueImage;
	public GameObject logic;

	public Sprite capn;
	public Sprite doc;
	public Sprite engie;
	public Sprite helms;
	public Sprite player;

	private SharedValues sharedValues = SharedValues.GetInstance();
	private int currentDialogueState = -1;

	// extra spaces to align the first line of dialogue with a line ending with 0








	private string[,] dialogues = {
		{"end", "=============================================== HELMSMAN PREQUEST DIALOGUE ======================================================"},
		{"blank", "Note: to advance the text, hit \"Enter\""},
		{"helms", "Hello there! It’s great that you’re passing by!\nUnfortunately our spaceship, the SS Adscensio, isn’t in its best condition."},
		{"helms", "What was once the epitome of technological advancement is now stranded deep in the vast emptiness of space."},
		{"helms", "What tragedy.."},
		{"player", "Um hello. Who are you? And what happened?"},
		{"helms", "My name is Finnick and I am the chief helmsman of the SS Adscensio."},
		{"helms", "But what good is a helmsman when we are just floating around in nothingness, at risk of being hit by a stray piece of asteroid debris anytime??"},
		{"helms", "It all started when a computer virus infected the SS Adscensio and and started sabotaging all her systems."},
		{"player", "The situation sounds severe.\nIs there anything I can do to help?\nI really wish to help!!!"},
		{"helms", "We only have about 2 weeks worth of oxygen and supplies left. We’re desperate.\nYou can try fixing the systems I suppose - we’ve tried fixing it but it never worked..."},
		{"player", "Let me try!\nI...I really want to do this."},
		{"helms", "Okay... lets go."},
		{"end", "=============================================== HELMSMAN POSTQUEST DIALOGUE ========================================================"},
		{"helms", "You...you did it.\nWhat...How...?"},
		{"player", "I don’t know.\nIt wasn’t that hard, I suppose."},
		{"helms", "What????\nHow??"},
		{"helms", "We spent weeks trying to fix the systems and you did it in such a short period of time...\nI don’t...\n...how?"},
		{"helms", "But thank you! Thank you so much! With this there is still hope...\nI can see my beloved Martha back on Earth.\nThe thought of never seeing her again was..."},
		{"helms", "You need to go and help the others with their systems!! Go to Kaden the head engineer, he’s at his wits end. Go!"},
		{"player", "I really am glad that I could help you.\nI really am so happy that I could be of use to you."},
		{"end", "=============================================== ENGINEER PREQUEST DIALOGUE ========================================================="},
		{"engie", "Hmms so the last tomato goes here and this last potato goes into here and the waste I collected from Finnick’s toilet goes here and\n-KABOOM-"},
		{"engie", "Ouch...so much for creating new food. We’re gonna starve damnit -"},
		{"player", "Hi sorry for interrupting! Are you Kaden the head engineer?\nFinnick the helmsman sent me up here to help you.\nI really want to help out."},
		{"engie", "Oh, help, yes I need much help, as you can see.\nFood is running out quickly and we need new food so yes definitely help is greatly welcomed."},
		{"engie", "......"},
		{"engie", "Oh, it's YOU. How can YOU help? You’ve been nothing but......ah never mind."},
		{"player", "Um...Sorry. I really don’t know what you are talking about.\nBut I helped Finnick fix the system downstairs!\nIf that helps."},
		{"engie", "YOU fixed the system downstairs?\nThat’s......"},
		{"engie", "Okay, I suppose you can try to fix the system here.\nWhat is the harm in trying after all...even if it is YOU who’s doing it."},
		{"player", "Um I still don’t understand why you are so angry with me but I really want to...no I need to help out. It’s something I feel I must do."},
		{"engie", "Ah whatever, go on ahead and try.\nI’m sure you’ll fail anyways - trust me I’ve tried so many times."},
		{"engie", "This system is more complex than Finnick’s system by the way - I’ve attached it to my food making machine so it has more machinery and software installed.\nLet’s go now."},
		{"end", "=============================================== ENGINEER POSTQUEST DIALOGUE ========================================================="},
		{"engie", "This is...This is...What????!!!\nHow could you fix it in such a short time?\nYOU of all people!!\nI’m speechless..."},
		{"engie", "But then again, you’re Jor....\nAh never mind..."},
		{"player", "It wasn’t that difficult... but I’m really glad that I could have been of use!!!"},
		{"player", "I don’t know why but ever since I met Finnick and now you... I feel that I’m obliged to help the crew of SS Adscensio. As though if I don’t...something bad will happen."},
		{"engie", "WE ALL DIE, that’s the BAD thing obviously!!\nMost of our systems are down, which means we are on the brink of starvation and prone to all kinds of unknown diseases in dangerous space."},
		{"engie", "......"},
		{"engie", "I NEVER WANTED TO COME UP TO SPACE.\nI NEVER WANTED TO COME UP TO SPACE.\nI NEVER WANTED TO COME UP TO SPACE."},
		{"engie", "......"},
		{"engie", "Most of all I never wanted to be on a ship with an arrogant, greedy and incompetent crewmate."},
		{"engie", "......"},
		{"engie", "But it's okay.\nThere is hope now for the crew, thanks to you.\nYou should go help Captain Taylor. She is struggling the most among all of us."},
		{"end", "=============================================== CAPTAIN PREQUEST DIALOGUE ========================================================="},
		{"capn", "......"},
		{"player", "Hello? Captain Taylor? I’ve been sent up here to help by Kaden the head Engineer."},
		{"capn", "......"},
		{"player", "Captain..?"},
		{"capn", "How far will you go to achieve your dreams, Jortan?"},
		{"player", "Jortan? Who is Jortan?"},
		{"capn", "Jortan, the world tells you to never stop at anything until your dreams have been achieved.\nBeautiful advice, but at what cost?"},
		{"capn", "As a young bright-eyed student at the Academy back on Earth, I dreamt of leading a crew to distant planets and galaxies, discovering wondrous things that would gain the respect of the Academy."},
		{"capn", "Oh, how I yearned for the recognition!"},
		{"capn", "To be known as a pioneer in space exploration, to be looked at with awe by fellow peers in the Academy."},
		{"capn", "To be admired by those who looked down on me in the past, beating me each day into submission."},
		{"capn", "To be loved by my father who viewed me as worthless as he rose through the ranks in the Academy."},
		{"capn", "......"},
		{"capn", "But look at us now.\nStranded.\nStarving.\nDying.\nBecause I took a foolish risk of entering the unknown despite knowing the dangers."},
		{"capn", "Jortan, you too had followed your dreams.\nBut at what cost?"},
		{"player", "Um, you might have gotten the wrong person. I don’t think I am who you think I am. I just really want to help you. Please, let me help you fix your system. The crew of Adscensio can all be saved!!!! Please."},
		{"player", "I know I can do it. Please."},
		{"capn", "......"},
		{"capn", "Kaden sent you up here?\nWell this will be the hardest system you’ll have to fix."},
		{"capn", "......"},
		{"capn", "Let us go."},
		{"end", "=============================================== CAPTAIN POSTQUEST DIALOGUE ========================================================="},
		{"capn", "You...did it. You really did it."},
		{"player", "It really wasn’t that difficult."},
		{"capn", "Well... There’s nothing more left to do here, Jortan.You’ve done your part..."},
		{"player", "I’m so glad that the Adscensio is safe now!\nThe crew can go home now, right?"},
		{"capn", "......"},
		{"player", "Captain?\nAre you okay?"},
		{"capn", "......"},
		{"player", "What’s wrong?"},
		{"capn", "......"},
		{"capn", "We’re not really safe, Jortan.\nIn fact, we never could be saved right from the start."},
		{"player", "...What?"},
		{"capn", "We’re not real, Jortan.\nThe virus that has been attacking our system was easy for you to beat because...\nBecause you, as our chief programmer, designed it."},
		{"player", "I...\nI...\ndesigned the virus???"},
		{"capn", "Yes YOU.\nSnap back to reality Jortan.\nCan’t you see?\nYOU were our chief programmer, Jortan."},
		{"capn", "You were once a member of the Adscensio, our lives would never have been in danger until you decided to take matters into your hands."},
		{"capn", "This world, this spaceship and the virus which you have been trying to fight for us - they are all not real.\nThis entire thing...it is a program which YOU have created."},
		{"capn", "We are all characters in your little program, telling you exactly what you want to hear."},
		{"player", "W-W-What...? No... it can’t be..."},
		{"capn", "Jortan, your name itself... it’s an anagram of the virus “Trojan”.\nHow could we be so blind this whole time?\nWe trusted you, but look what you’ve done to us"},
		{"capn", "The supposed viruses attacking this spaceship, it has all been designed by you."},
		{"capn", "That’s why it could be easily defeated by YOU."},
		{"capn", "All so you can feel like a saviour.\nAct as the saviour you long to be. The saviour you never were in real life."},
		{"player", "In real life...? I...I don’t understand..."},
		{"capn", "We are all dead in reality, Jortan."},
		{"capn", "The Adscensio never made it out."},
		{"capn", "We were left stranded in deep nothingness."},
		{"capn", "We all starved to death."},
		{"capn", "The ship was wrecked by a passing asteroid debris. Life support failed leaving us no hope for survival."},
		{"player", "I...What did I do?"},
		{"capn", "I asked you before, Jortan. What cost would you pay to achieve your dreams?\nMine was to bring risk to the entire crew, but you..."},
		{"capn", "You, Jortan, planted the deadly virus into the spaceship."},
		{"capn", "You, Jortan, claimed that it would bring us unto a higher technological level, unsurpassed by any other spaceship."},
		{"capn", "You, Jortan, blinded by the fame it could bring you, refused to stop it even as our systems failed one by one."},
		{"capn", "Even at the end...even when all your crew were dying, you refused to stop the malicious virus that you’ve put all your hope on, convinced that it would still work."},
		{"capn", "You, Jortan, killed us."},
		{"capn", "And you were so guilty after all your friends died...you, a lone man left stranded in space.\nWhat have you done??"},
		{"capn", "You needed penance. Penance for your wrongdoings. You locked your consciousness into this program."},
		{"capn", "How many times have you went through with this program? Trying to set things right in this virtual world when you've failed in reality? I wonder."},
		{"player", "I..."},
		{"player", "I remember..."},
		{"capn", "Now as programmed, you will have to restart.\nWhat punishment.\nStuck in an endless loop of false hope which will never come to pass."},
		{"player", "I..."},
		{"end", "=============================================== EPIC COUNTER SCENE HERE ========================================================="},
	};


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("return")) {
			if (currentDialogueState != -1) {
				if (dialogues[currentDialogueState + 1, 0] == "end") {
					SetUIState(false);
					sharedValues.hasGameStarted = true;
					currentDialogueState = -1;
					logic.GetComponent<StartupMain>().dialogueState++;
				}
				else {
					currentDialogueState++;
					SetDialogue(dialogues[currentDialogueState, 0], dialogues[currentDialogueState, 1]);
				}
			}
		}
		if (Input.GetKeyDown("i")) {
			StartDialogue(1);
			logic.GetComponent<StartupMain>().dialogueState--;
		}
		if (Input.GetKeyDown("o")) {
			StartDialogue(14);
			logic.GetComponent<StartupMain>().dialogueState--;
		}
		if (Input.GetKeyDown("j")) {
			StartDialogue(22);
			logic.GetComponent<StartupMain>().dialogueState--;
		}
		if (Input.GetKeyDown("k")) {
			StartDialogue(35);
			logic.GetComponent<StartupMain>().dialogueState--;
		}
		if (Input.GetKeyDown("n")) {
			StartDialogue(47);
			logic.GetComponent<StartupMain>().dialogueState--;
		}
		if (Input.GetKeyDown("m")) {
			StartDialogue(69);
			logic.GetComponent<StartupMain>().dialogueState--;
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
			case "player":
				SetRightImage(player);
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

}
