using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI _nameText;
    public TextMeshProUGUI _dialogueText;

    public Animator _animator;

    private Queue<string> _sentences;

    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _animator.SetBool("IsOpen", true);

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

        //stops all sentences from animating if moved on ahead
        StopAllCoroutines();
        //starts animation of sentences
        StartCoroutine(TypeSentence(sentence));

        //Debug.Log(sentence);
       // _dialogueText.text = sentence;

        }

    IEnumerator TypeSentence(string sentence)
    {

        _dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter;

            //wait before next letter (a single frame)
            yield return null;
        }
    }

        void EndDialogue()
        {
            //Debug.Log("End of conversation.");
            _animator.SetBool("IsOpen", false);
    }
    
   
}
