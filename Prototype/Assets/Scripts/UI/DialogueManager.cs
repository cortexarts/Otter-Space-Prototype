using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Xml;
using System.IO;

public struct Phrase
{
    public string character;
    public string text;
}

public struct Dialogue
{
    public int index;
    public List<Phrase> phrases;
}

public class DialogueManager : MonoBehaviour
{
    public Text m_Name;
    public Text m_Text;
    public TextAsset source;
    public float letterPause = 0.05f;
    public float DialoguePause = 0.1f;
    public int dialogueIndex = 0;
    private int phraseIndex = 0;
    private string message = "";

    public List<Dialogue> dialogues = new List<Dialogue>();

    private IntroCanvasManager m_IntroCanvasManager;

    void Start()
    {
        ParseDialogue();
        m_IntroCanvasManager = GetComponent<IntroCanvasManager>();
    }

    public void ParseDialogue()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(source.text);
        XmlNodeList dialogueList = xmlDoc.GetElementsByTagName("dialogue");

        foreach(XmlNode dialogueInfo in dialogueList)
        {
            XmlNodeList dialogueContent = dialogueInfo.ChildNodes;
            Dialogue currentXMLDialogue;
            currentXMLDialogue.phrases = new List<Phrase>();
            int.TryParse(dialogueInfo.Attributes["index"].Value, out currentXMLDialogue.index);

            foreach(XmlNode dialogueItems in dialogueContent)
            {
                if(dialogueItems.Name == "phrase")
                {
                    Phrase currentXMLPhrase;
                    currentXMLPhrase.character = dialogueItems.Attributes["name"].Value;
                    currentXMLPhrase.text = dialogueItems.InnerText;
                    currentXMLDialogue.phrases.Add(currentXMLPhrase);
                }
            }

            dialogues.Add(currentXMLDialogue);
        }
    }

    public void CreateDialogue()
    {
        Phrase currentPhrase;
        currentPhrase = dialogues[dialogueIndex].phrases[phraseIndex];
        message = currentPhrase.text;
        m_Name.text = currentPhrase.character;
    }

    public void PlayDialogue(int a_Index)
    {
        dialogueIndex = a_Index;
        m_Name.text = "";
        m_Text.text = "";
        CreateDialogue();
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach(char letter in message.ToCharArray())
        {
            m_Text.text += letter;
            yield return new WaitForSeconds(letterPause);
        }

        if(phraseIndex < dialogues[dialogueIndex].phrases.Count - 1)
        {
            yield return new WaitForSeconds(DialoguePause);
            phraseIndex++;
            PlayDialogue(dialogueIndex);
        }
        else
        {
            yield return new WaitForSeconds(DialoguePause);
            m_IntroCanvasManager.ToNextState();
        }
    }
}
