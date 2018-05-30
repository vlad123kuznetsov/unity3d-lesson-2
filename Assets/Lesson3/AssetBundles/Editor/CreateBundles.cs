using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateBundles : MonoBehaviour {

	[MenuItem("Assets/CreateBundles")]
	public static void CreateBundlesS()
	{
		var path = Application.dataPath + "/bundles";
		if(!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}

		BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);
	}
}
