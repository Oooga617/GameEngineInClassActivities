using UnityEngine;
// Use the CreateAssetMenu attribute to allow creating instances of this ScriptableObject from the Unity Editor.
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterProperties", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public string name;

   
}