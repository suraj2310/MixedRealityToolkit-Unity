﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEditor;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    [CustomEditor(typeof(MixedRealityTeleport))]
    public class MixedRealityTeleportEditor : Editor
    {
        private static MixedRealityTeleport mixedRealityTeleport;
        private static SerializedProperty teleportMakerPrefab;
        private static SerializedProperty useCustomMappingProperty;
        private static bool useCustomMapping;

        private void OnEnable()
        {
            mixedRealityTeleport = (MixedRealityTeleport)target;


            teleportMakerPrefab = serializedObject.FindProperty("teleportMarker");
            useCustomMappingProperty = serializedObject.FindProperty("useCustomMapping");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            useCustomMapping = useCustomMappingProperty.boolValue;

            EditorGUILayout.LabelField("Teleport Options", new GUIStyle("Label") { fontStyle = FontStyle.Bold });

            mixedRealityTeleport.EnableTeleport = EditorGUILayout.Toggle("Enable Teleport", mixedRealityTeleport.EnableTeleport);

            mixedRealityTeleport.EnableStrafe = EditorGUILayout.Toggle("Enable Strafe", mixedRealityTeleport.EnableStrafe);
            mixedRealityTeleport.StrafeAmount = EditorGUILayout.FloatField("Strafe Amount", mixedRealityTeleport.StrafeAmount);

            mixedRealityTeleport.EnableRotation = EditorGUILayout.Toggle("Enable Rotation", mixedRealityTeleport.EnableRotation);
            mixedRealityTeleport.RotationSize = EditorGUILayout.FloatField("Rotation Amount", mixedRealityTeleport.RotationSize);

            EditorGUILayout.PropertyField(teleportMakerPrefab);

            EditorGUILayout.LabelField("Teleport Controller Mappings", new GUIStyle("Label") { fontStyle = FontStyle.Bold });

            useCustomMapping = EditorGUILayout.Toggle("Use Custom Mappings", useCustomMapping);
            useCustomMappingProperty.boolValue = useCustomMapping;

            if (useCustomMapping)
            {
                EditorGUILayout.TextField("Horizontal Strafe", mixedRealityTeleport.LeftThumbstickX);
                EditorGUILayout.TextField("Forward Movement", mixedRealityTeleport.LeftThumbstickY);
                EditorGUILayout.TextField("Horizontal Rotation", mixedRealityTeleport.RightThumbstickX);
                EditorGUILayout.TextField("Rotation", mixedRealityTeleport.RightThumbstickY);
            }
            else
            {
                EditorGUILayout.EnumPopup("Horizontal Strafe", mixedRealityTeleport.HorizontalStrafe);
                EditorGUILayout.EnumPopup("Forward Movement", mixedRealityTeleport.VerticalRotation);
                EditorGUILayout.EnumPopup("Horizontal Rotation", mixedRealityTeleport.VerticalRotation);
                EditorGUILayout.EnumPopup("Rotation", mixedRealityTeleport.HorizontalRotation);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
