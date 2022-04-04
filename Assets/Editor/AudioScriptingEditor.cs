using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine.Events;

[CustomEditor(typeof(AudioTrigger))]
public class AudioScriptingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        AudioTrigger audioTrigger = (AudioTrigger)target;

        audioTrigger.GetComponent<AudioSource>().hideFlags = HideFlags.HideInInspector;

        base.OnInspectorGUI();

        audioTrigger.audioSource = audioTrigger.GetComponent<AudioSource>();
        audioTrigger.audioSource.rolloffMode = AudioRolloffMode.Linear;

        if (audioTrigger.audioClips == null || audioTrigger.audioClips.Count == 0)
        {
            EditorGUILayout.LabelField("Please select at least 1 clip", EditorStyles.boldLabel);
            return;
        }

        audioTrigger.actionAfterDone = (AudioTrigger.ActionAfterDone)EditorGUILayout.EnumPopup("Action after playing sound", audioTrigger.actionAfterDone);
        if (audioTrigger.actionAfterDone == AudioTrigger.ActionAfterDone.CustomAction)
        {
            serializedObject.Update();
            var thing = EditorGUILayout.PropertyField(serializedObject.FindProperty("customAction"));
            serializedObject.ApplyModifiedProperties();
        }

        if (audioTrigger.audioClips.Count > 1)
        {
            audioTrigger.audioOrder = (AudioTrigger.AudioOrder)EditorGUILayout.EnumPopup("Play Order", audioTrigger.audioOrder);
            audioTrigger.PlayOneClip = EditorGUILayout.Toggle("Play only one clip when trigger", audioTrigger.PlayOneClip);
        }
        GUILayout.Space(15);

        audioTrigger.Volume = EditorGUILayout.Slider("Volume", audioTrigger.Volume, 0f, 1f);
        audioTrigger.SurroundSound = EditorGUILayout.Toggle("Use Surround Sound", audioTrigger.SurroundSound);
        if (audioTrigger.SurroundSound)
        {
            audioTrigger.Range = EditorGUILayout.FloatField("Range",audioTrigger.Range);
        }

        GUILayout.Space(15);

        audioTrigger.audioTriggerType = (AudioTrigger.AudioTriggerType)EditorGUILayout.EnumPopup("Trigger Type", audioTrigger.audioTriggerType);

        switch (audioTrigger.audioTriggerType)
        {
            case AudioTrigger.AudioTriggerType.RandomEnviromental:
                GUILayout.Space(10);
                EditorGUILayout.LabelField("Time between sound(s) being played", EditorStyles.boldLabel);
                audioTrigger.minRandTime = EditorGUILayout.FloatField("Min Random Time", audioTrigger.minRandTime);
                audioTrigger.maxRandTime = EditorGUILayout.FloatField("Max Random Time", audioTrigger.maxRandTime);
                break;
            case AudioTrigger.AudioTriggerType.EventSpecific:
                EditorGUILayout.LabelField("Call the 'PlaySound()' function on this script", EditorStyles.boldLabel);
                break;
        }

        if (GUI.changed)
        {
            audioTrigger.UpdateAudio();
            EditorUtility.SetDirty(target);
        }
    }
}

