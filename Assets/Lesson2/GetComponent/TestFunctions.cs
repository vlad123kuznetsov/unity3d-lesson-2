using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class TestFunctions : MonoBehaviour
{
	private Transform rootTransform;
	
	private void Update()
	{
		/*
		//by name
		var firstGoByName = GameObject.Find("special");
		UnityEngine.Debug.Log(firstGoByName.name);
		EstimateWorkTime(() => GameObject.Find("special"));
		
		//by type
		var firstGoByType = FindObjectOfType<Image>();
		UnityEngine.Debug.Log(firstGoByType.name);
		EstimateWorkTime(() => FindObjectOfType<Image>());
		
		//by tag
		var firstGoByTag = GameObject.FindGameObjectWithTag("special");
		UnityEngine.Debug.Log(firstGoByTag.name);
		EstimateWorkTime(() => GameObject.FindGameObjectWithTag("special"));
		
		//by type
		var allGoByType = FindObjectsOfType<Image>();
		foreach (var allGo in allGoByType)
		{
			UnityEngine.Debug.Log(allGo.name);
		}
		EstimateWorkTime(() => FindObjectsOfType<Image>());

		//get component
		var justGetComponent = rootTransform.GetComponent<Image>();
		UnityEngine.Debug.Log(justGetComponent.name);
		EstimateWorkTime(() => rootTransform.GetComponent<Image>());
		
		//find object in children with root transform
		var go = rootTransform.GetComponentInChildren<Image>();
		UnityEngine.Debug.Log(go.name);
		EstimateWorkTime(() => go.GetComponentsInChildren<Image>());
		
		
		//find object in parent with root transform
		var go = rootTransform.GetComponentInParent<Image>();
		UnityEngine.Debug.Log(go.name);
		EstimateWorkTime(() => go.GetComponentsInParent<Image>());
		
		//by name with root transform
		var go = rootTransform.transform.Find("special");
		UnityEngine.Debug.Log(go.name);
		EstimateWorkTime(() => rootTransform.transform.Find("special"));
		
		
		//by name with complex pass
		var go = rootTransform.transform.Find("");
		UnityEngine.Debug.Log(go.name);
		EstimateWorkTime(() => rootTransform.transform.Find(""));
		*/
		
	}

	private float EstimateWorkTime(Action action)
	{
		Stopwatch watch = new Stopwatch();
		watch.Start();
		action();
		watch.Stop();
		UnityEngine.Debug.Log(watch.ElapsedMilliseconds.ToString());
		return watch.ElapsedMilliseconds;
	}
}
