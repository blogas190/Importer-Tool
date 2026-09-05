using UnityEngine;
using UnityEditor;
using System.IO;

public class ImporterWindow : EditorWindow
{
    ImporterSettings settings = new ImporterSettings();
    AssetImporterLogic assetImporter = new AssetImporterLogic();
    int toolbarIndex = 0;
    string[] toolbarStrings = {"Top Left","Center"};

    [MenuItem("Tools/Importer")]
    public static void ShowWindow()
    {
        GetWindow<ImporterWindow>("Importer");
    }
    void OnGUI()
    {
        GUILayout.Label("Select import file", EditorStyles.boldLabel);
        GUILayout.Space(10f);
        if(GUILayout.Button("Select"))
        {
            settings.SetPath(EditorUtility.OpenFilePanel("Select an image","","png"));
            Texture2D texture = new Texture2D(2,2);
            texture.LoadImage(File.ReadAllBytes(settings.imagePath));
            settings.SetImage(texture);
        }
        GUILayout.Space(10f);
        GUILayout.Label($"Selected File at path {settings.imagePath}");
        GUILayout.Space(10f);
        if(settings.assetImage != null)
        {
            GUI.DrawTexture(GUILayoutUtility.GetRect(200,200),settings.assetImage);   
        }
        if(string.IsNullOrEmpty(settings.assetName))
        {
            settings.SetName(Path.GetFileNameWithoutExtension(settings.imagePath));
        }
        settings.SetName(GUILayout.TextField(settings.assetName));
        GUILayout.Space(30f);
        settings.IsAnimated(GUILayout.Toggle(settings.assetIsAnimated,"Is Animated"));
        GUILayout.Space(10f);
        GUILayout.Label("Pivot Location");
        if(!settings.assetIsAnimated)
        {
            settings.SetPivot(toolbarIndex = EditorGUILayout.Popup(toolbarIndex,toolbarStrings));
        }
        GUILayout.Space(50f);
        if(GUILayout.Button("Import"))
        {
            assetImporter.Import(settings.assetName, settings.imagePath, settings.assetIsAnimated, settings.pivotLocation);
        }
    }
}
