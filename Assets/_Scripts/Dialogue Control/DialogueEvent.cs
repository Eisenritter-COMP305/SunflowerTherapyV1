using UnityEngine;

[CreateAssetMenu(fileName = "DialogueEvent", menuName = "Scene/Dialog Event")]
[System.Serializable]
public class DialogueEvent : ScriptableObject
{
    public Dialogue[] dialogues;
}