using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpriteAssetPostprocessor : AssetPostprocessor
{
    public readonly List<string> Paths = new List<string>()
    {
        "Assets/GameAsset/UI/Sprites",
    };

    private void OnPreprocessTexture()
    {
        bool isSpriteAsset = false;
        foreach (var path in Paths)
        {
            if (assetPath.Contains(path))
            {
                isSpriteAsset = true;
                break;
            };
        }
        
        if(!isSpriteAsset) return;
        
        TextureImporter textureImporter = (TextureImporter)assetImporter;

        textureImporter.textureType = TextureImporterType.Sprite;
        textureImporter.spriteImportMode = SpriteImportMode.Single;
        textureImporter.alphaIsTransparency = true;
        textureImporter.mipmapEnabled = false; 
    }
}
