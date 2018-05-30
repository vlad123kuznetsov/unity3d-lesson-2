using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	private void Awake()
	{
		LoadAsync();
		StartCoroutine(LoadAsync());
		LoadAll();
		Unload();
	}

	private void LoadSync()
	{
		var prefab1 = Resources.Load<GameObject>("prefab");
	}

	private IEnumerator LoadAsync()
	{
		var prefabLoadRequest = Resources.LoadAsync<GameObject>("prefab");
		while (prefabLoadRequest.isDone)
		{
			yield return null;
		}

		Debug.Log((prefabLoadRequest.asset as GameObject).name);
	}

	private void LoadAll()
	{
		var prefabs = Resources.LoadAll<GameObject>("subfolder");
		foreach (var prefab in prefabs)
		{
			Debug.LogError(prefab.name);
		}
	}

	private void Unload()
	{
		Resources.UnloadUnusedAssets();
	}
}
