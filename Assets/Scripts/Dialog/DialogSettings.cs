using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialog", menuName = "New Dialog/dialog")]
public class DialogSettings : ScriptableObject
{

    [Header("Settings")]
    public GameObject actor;

    [Header("Dialog")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string Portuguese;
    public string English;
    public string Spanish;
}

#if UNITY_EDITOR

    [CustomEditor(typeof(DialogSettings))]
    public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogSettings ds = (DialogSettings)target;

        Languages l = new Languages();
        l.Portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if (GUILayout.Button("Create Dialogue"))
        {
            if (ds.sentence != "")
            {
                ds.dialogues.Add(s);
                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}

#endif