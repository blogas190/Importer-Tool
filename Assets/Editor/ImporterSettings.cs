using UnityEngine;
public class ImporterSettings
{
    public string assetName {get; private set;} = "";
    public Texture2D assetImage {get; private set;} = null;
    public string imagePath {get; private set;} = "";
    public bool assetIsAnimated {get; private set;} = false;
    public SpriteAlignment pivotLocation {get; private set;}

    public void SetName(string name)
    {
        assetName = name;
    }
    public void SetImage(Texture2D asset)
    {
        assetImage = asset;
    }

    public void SetPath(string path)
    {
        imagePath = path;
    }
    public void IsAnimated (bool isStatic)
    {
        assetIsAnimated = isStatic;
    }
    public void SetPivot(int index)
    {
        if(index == 0)
        {
            pivotLocation = SpriteAlignment.TopLeft;
        }
        else
        {
            pivotLocation = SpriteAlignment.Center;
        }
    }

}
