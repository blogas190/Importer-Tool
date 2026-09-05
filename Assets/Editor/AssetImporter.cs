using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetImporterLogic
{
    public void Import(string assetName, string imagePath, bool isAnimated, SpriteAlignment pivotLocation)
    {
        string folder = (isAnimated ? "Animated" : "Static") + "Objects";
        string parentPath = $"Assets/{folder}";

        if(!AssetDatabase.IsValidFolder(parentPath))
        {
            AssetDatabase.CreateFolder("Assets",$"{folder}");
        }
        string id = AssetDatabase.CreateFolder(parentPath, assetName);
        string assetPath = $"{AssetDatabase.GUIDToAssetPath(id)}/{assetName}.png";
        File.Copy(imagePath, assetPath, true);
        AssetDatabase.Refresh();

        TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
        importer.textureType = isAnimated ? TextureImporterType.Default : TextureImporterType.Sprite;
        importer.spriteImportMode = SpriteImportMode.Single;
        importer.sRGBTexture = isAnimated ? true : false;
        TextureImporterSettings settings = new TextureImporterSettings();

        importer.ReadTextureSettings(settings);

        settings.spriteAlignment = (int)pivotLocation;

        importer.SetTextureSettings(settings);

        importer.SaveAndReimport();

    }
}
