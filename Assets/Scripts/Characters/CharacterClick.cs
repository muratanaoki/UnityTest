using UnityEngine;
using PixelCrushers.DialogueSystem;

public class CharacterClick : MonoBehaviour
{
    public string conversationTitle;

    private void OnMouseDown()
    {
        if (DialogueManager.IsConversationActive)
        {
            DialogueManager.StopConversation();
        }
        else
        {
            DialogueManager.StartConversation(conversationTitle);
        }
    }
}
