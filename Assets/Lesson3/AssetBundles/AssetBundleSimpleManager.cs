using System.Collections;
using UnityEngine;

namespace Lesson3.AssetBundles
{
    public class AssetBundleSimpleManager : MonoBehaviour
    {
        private const string remoteUrl = "";
        private int version = 1;

        private void Awake()
        {
            StartCoroutine(LoadFromWeb());
        }
    
        private IEnumerator LoadFromWeb()
        {
            while (!Caching.ready)
            {
                yield return null;
            }
        
            using (var req = WWW.LoadFromCacheOrDownload(remoteUrl, version))
            {
                yield return req;

                CreateGameObject(req.assetBundle.LoadAsset<GameObject>("prefab"));
            }
        }

        private void CreateGameObject(GameObject go)
        {
            Instantiate(go);
        }
    }
}