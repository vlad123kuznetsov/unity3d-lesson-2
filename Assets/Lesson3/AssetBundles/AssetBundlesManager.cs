using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class AssetBundlesManager : MonoBehaviour
{
    private const string remoteUrl = "";
    private const string localUrl = "";
    private const string bundleName = "";

    private void Awake()
    {
        if (File.Exists(Application.dataPath + "/" + bundleName))
        {
            StartCoroutine(LoadFromFile());
        }
        else
        {
            StartCoroutine(LoadFromWeb());
        }
    }
    
    private IEnumerator LoadFromFile()
    {
        var req = AssetBundle.LoadFromFileAsync(Application.dataPath + "/" + bundleName);
        while (!req.isDone)
        {
            yield return null;
        }

        var bundle = req.assetBundle;
        
        CreateGameObject(bundle.LoadAsset<GameObject>("prefab"));
    }

    private IEnumerator LoadFromWeb()
    {
        var req = UnityWebRequest.Get(remoteUrl);

        yield return req;

        CacheBundle(req);
        
        var bytes = req.downloadHandler.data;
        var bundle = AssetBundle.LoadFromMemory(bytes);
        
        CreateGameObject(bundle.LoadAsset<GameObject>("prefab"));
    }

    private void CacheBundle(UnityWebRequest req)
    {
        var bytes = req.downloadHandler.data;
        File.WriteAllBytes(Application.dataPath + "/" + bundleName, bytes);
    }

    private void CreateGameObject(GameObject go)
    {
        Instantiate(go);
    }
}
