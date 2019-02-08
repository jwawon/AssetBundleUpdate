using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class LoadAssetBundles : MonoBehaviour
{
    AssetBundle myLoadedAssetbundle;
    //Local Path: C:\Users\Jwawon\UnityProject\AssetBundles\test
    //GCP Path: https://storage.googleapis.com/crawler_data/OctosAssetTest/1.0.1/test
    public string path;
    
    public string assetName;
    void Start()
    {
        // LoadAssetBundle(path);
        // InstatiateObjectFromBundle(assetName);
        StartCoroutine(GetAssetBundle(path));
    }

    IEnumerator GetAssetBundle(string bundleUrl){
        using (UnityWebRequest uwr =  UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl))
        {
            yield return uwr.SendWebRequest();
            if(uwr.isNetworkError || uwr.isHttpError){
                Debug.Log(uwr.error);
            }
            else{
                myLoadedAssetbundle = DownloadHandlerAssetBundle.GetContent(uwr);
                InstatiateObjectFromBundle(assetName);

            }
        }
    }
    void LoadAssetBundle(string bundleUrl){
        myLoadedAssetbundle = AssetBundle.LoadFromFile(bundleUrl);
        Debug.Log(myLoadedAssetbundle == null ? "Failed to load AssetBundle" : "AssetBundle successfully loaded");   
    }

    void InstatiateObjectFromBundle(string assetName){
        var prefab = myLoadedAssetbundle.LoadAsset(assetName);
        Instantiate(prefab);

    }
}
