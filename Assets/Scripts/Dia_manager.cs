using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dia_manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    public Button nextButton; // Assumes there is a button to go to the next sentence

    private Queue<string> sentences;
    public static Dia_manager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scene");
            return;
        }
        instance = this;
        sentences = new Queue<string>();
        SceneManager.sceneLoaded += OnSceneLoaded;  // Register the OnSceneLoaded method
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;  // Unregister the OnSceneLoaded method
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignUIElements();
        AssignButtonFunction();
    }

    private void AssignUIElements()
    {
        if (nameText == null || dialogueText == null || animator == null || nextButton == null)
        {
            // Assuming the Canvas is named "DiaFond"
            GameObject diaFond = GameObject.Find("DiaFond");

            if (diaFond != null)
            {
                nameText = diaFond.transform.Find("Nom")?.GetComponent<Text>();
                dialogueText = diaFond.transform.Find("Texte")?.GetComponent<Text>();
                animator = diaFond.GetComponent<Animator>();
                nextButton = diaFond.transform.Find("NextBouton")?.GetComponent<Button>();
            }

            if (nameText == null || dialogueText == null || animator == null || nextButton == null)
            {
                Debug.LogError("UI elements or Animator or Button not found in the scene");
            }
        }
    }

    private void AssignButtonFunction()
    {
        if (nextButton != null)
        {
            nextButton.onClick.RemoveAllListeners(); // Clear previous listeners to avoid multiple assignments
            nextButton.onClick.AddListener(DisplayNextSentence);
        }
        else
        {
            Debug.LogError("NextButton is not assigned");
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        AssignUIElements();  // Ensure UI elements are assigned before starting dialogue
        AssignButtonFunction();  // Ensure the button has the correct function assigned

        if (animator != null)
        {
            animator.SetBool("is_open", true);
        }

        if (nameText != null)
        {
            nameText.text = dialogue.name;
        }

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));  // Coroutines are useful to run code concurrently
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        if (animator != null)
        {
            animator.SetBool("is_open", false);
        }
    }
}
