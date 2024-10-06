#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine.SceneManagement;


[CustomEditor(typeof(MainMenu))]
public class MainMenuEditor : Editor
{
    MainMenu tg;

    Dictionary<string, int> scenes = new Dictionary<string, int>();
    private void Awake()
    {
        tg = (MainMenu)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        foreach (EditorBuildSettingsScene buildScene in EditorBuildSettings.scenes)
        {
            if (buildScene.enabled)
            {
                int sceneId = SceneUtility.GetBuildIndexByScenePath(buildScene.path);

                string sceneName = Path.GetFileNameWithoutExtension(buildScene.path);

                if (sceneId == -1) return;
                if (!scenes.ContainsKey(sceneName))
                    scenes.Add(sceneName, sceneId);
            }
        }

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("Start scene id", EditorStyles.boldLabel);
        tg.startScene = EditorGUILayout.Popup(tg.startScene, scenes.Keys.ToArray());

        EditorGUILayout.EndHorizontal();


        EditorGUI.EndChangeCheck();

        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();

        if (PrefabUtility.GetPrefabInstanceStatus(tg.gameObject) == PrefabInstanceStatus.Connected)
        {
            PrefabUtility.RecordPrefabInstancePropertyModifications(tg.GetComponent<MainMenu>());
        }
        else EditorUtility.SetDirty(target);



        base.DrawDefaultInspector();
    }
}

#endif