using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TheLastSymphony
{
    [CustomEditor(typeof(TLS_SO_EnemiesData))]
    public class TLS_EnemiesDataEditor : Editor
    {
        private TLS_SO_EnemiesData enemiesData;
        private int preEnemyType = 0;

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            enemiesData = (TLS_SO_EnemiesData)target;

            SerializedObject serializedObject = new SerializedObject(enemiesData);
            serializedObject.Update();

            SerializedProperty serializedPropertyEnemyType = serializedObject.FindProperty("enemyType");

            EditorGUILayout.PropertyField(serializedPropertyEnemyType);

            if(preEnemyType != serializedPropertyEnemyType.intValue)
            {
                enemiesData.ResetData();
                preEnemyType = serializedPropertyEnemyType.intValue;
            }

            if(serializedPropertyEnemyType.intValue == (int)EnemyType.Skeleton)
            {
                SerializedProperty serializedPropertyEnemy = serializedObject.FindProperty("skeleton");

                EditorGUILayout.PropertyField(serializedPropertyEnemy);
            }

            if(serializedPropertyEnemyType.intValue == (int)EnemyType.HellHound)
            {
                SerializedProperty serializedPropertyEnemy = serializedObject.FindProperty("hellHound");

                EditorGUILayout.PropertyField(serializedPropertyEnemy);
            }

            if(serializedPropertyEnemyType.intValue == (int)EnemyType.BringerOfDeath)
            {
                SerializedProperty serializedPropertyEnemy = serializedObject.FindProperty("bringerOfDeath");

                EditorGUILayout.PropertyField(serializedPropertyEnemy);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}