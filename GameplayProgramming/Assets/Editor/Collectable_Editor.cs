using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Collectable_)), CanEditMultipleObjects]
public class Collectable_Editor : Editor
{
    public SerializedProperty
        type_Prop,
        powerup_type_Prop,
        coin_value_Prop;

    private void OnEnable()
    {
        type_Prop = serializedObject.FindProperty("type");
        powerup_type_Prop = serializedObject.FindProperty("powerup_type");
        coin_value_Prop = serializedObject.FindProperty("coin_value");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(type_Prop);

        Collectable_.Type type = (Collectable_.Type)type_Prop.enumValueIndex;

        switch(type)
        {
            case Collectable_.Type.COIN:
                EditorGUILayout.IntSlider(coin_value_Prop, 1, 20,
                    new GUIContent("Coin Value"));

                break;


            case Collectable_.Type.POWERUP:
                EditorGUILayout.PropertyField(powerup_type_Prop);

                break;



        }

        serializedObject.ApplyModifiedProperties();

        //base.OnInspectorGUI();
    }




}

