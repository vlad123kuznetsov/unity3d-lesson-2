using Lesson3.ScriptableObject;
using UnityEditor;
using UnityEngine;

public class CreateInventoryItemList : MonoBehaviour {

	[MenuItem("Assets/Create/Inventory Item List")]
	public static InventoryItemList Create()
	{
		var asset = ScriptableObject.CreateInstance<InventoryItemList>();

		AssetDatabase.CreateAsset(asset, "Assets/InventoryItemList.asset");
		AssetDatabase.SaveAssets();
		return asset;
	}
}
