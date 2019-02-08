using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BundleBuilder : Editor
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles(){
        string path = EditorUtility.SaveFolderPanel("Save AssetBundles to folder", "", "");
        //Save to C drive

        // BuildPipeline.BuildAssetBundles(@"C:\Users\Jwawon\UnityProject\AssetBundles", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
    }


}
