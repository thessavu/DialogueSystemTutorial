using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public Queue<string> _sentences;
    void Start()
    {
        _sentences = new Queue<string>();
    }

   
}
