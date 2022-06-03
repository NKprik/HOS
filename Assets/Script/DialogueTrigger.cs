using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		/*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }*/
		
	}

}
