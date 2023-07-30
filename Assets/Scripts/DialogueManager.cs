using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI _nameText;
    public TextMeshProUGUI _dialogueText;

    private Queue<string> _sentences;

    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);

        _nameText.text = dialogue.name;

        _sentences.Clear();

        foreach (string sentence in dialogue._sentences)
        {
            _sentences.Enqueue(sentence);
        }
    }
        public void DisplayNextSentence()
        {
            if(_sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = _sentences.Dequeue();
        //Debug.Log(sentence);
        _dialogueText.text = sentence;

        }

        void EndDialogue()
        {
            Debug.Log("End of conversation.");
        }
    
   
}
