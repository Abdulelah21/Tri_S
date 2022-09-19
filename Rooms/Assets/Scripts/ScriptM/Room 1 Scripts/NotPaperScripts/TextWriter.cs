using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text noteText;
    private string textToWrite;
    private int characterIndex;
    private float timePerChar;
    private float timer;
    bool checkNote;

    public AudioSource textWritingSound;

    public void AddWriter(Text noteText, string textToWrite, float timePerChar)
    {
        this.noteText = noteText;
        this.textToWrite = textToWrite;
        this.timePerChar = timePerChar;
        characterIndex = 0;
        checkNote = false;
    }

    private void Update()
    {
        if(noteText != null)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                //Display Next Character
                timer += timePerChar;
                characterIndex++;
                noteText.text = textToWrite.Substring(0, characterIndex);
                textWritingSound.Play();
                if(characterIndex >= textToWrite.Length)
                {
                    // Entire string displayed
                    noteText = null;
                    return;
                }
            }
            checkNote = true;
        }
    }
    public bool NoteIsOpen()
    {
        return checkNote;
    }

}
