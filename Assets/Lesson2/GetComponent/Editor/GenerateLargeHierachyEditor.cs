using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenerateLargeHierachy))]
public class GenerateLargeHierachyEditor : Editor 
{	
	public override void OnInspectorGUI()
	{
		if (GUILayout.Button("generate"))
		{
			(target as GenerateLargeHierachy).Generate();
		}
	}
}
