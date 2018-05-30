using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionLerpDemo : MonoBehaviour
{
	[SerializeField] private GameObject cube1;

	private Quaternion toRotation;
	
	private void Awake()
	{
		var relativePosition = cube1.transform.position - Camera.main.transform.position;
		toRotation = Quaternion.LookRotation(relativePosition);
	}
	
	private void Update()
	{
		var idle = Quaternion.Euler(0, 0, 90);
		var rotation = Quaternion.Euler(0, 0, 170);

		var result = idle * Quaternion.Inverse(rotation);
		
		var rotationStep = Quaternion.Slerp(Camera.main.transform.rotation, toRotation, Time.deltaTime);
		Camera.main.transform.rotation = rotationStep;
	}
}
