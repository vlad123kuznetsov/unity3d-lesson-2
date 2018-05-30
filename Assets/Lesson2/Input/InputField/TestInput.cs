using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
 public class User
 {
 	public string Name;
 	public int Age;
 }
 
 public class UserManager : MonoBehaviour
 {
 	public void SaveUser(User user)
 	{
 		PlayerPrefs.SetString("user", JsonUtility.ToJson(user));
 		PlayerPrefs.Save();
 	}
 }

public class TestInput : MonoBehaviour, IInput
{
	[SerializeField] private float speed = 10.0F;
	[SerializeField] private float rotationSpeed = 100.0F;
	
	private IInput input;

	private void Awake()
	{
		var inputGo = new GameObject {name = "input"};
		input = inputGo.AddComponent<KeyboardInput>();
	}
	
	private void Update()
	{
		if (Mathf.Abs(input.Horizontal) > Mathf.Epsilon)
		{
			var translation = input.Horizontal * speed;
			var rotation = input.Vertical * rotationSpeed;

			Debug.Log(input.Horizontal.ToString());

			translation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate(translation, 0, 0);
			transform.Rotate(0, rotation, 0);
		}
	}

	public float Horizontal { get; private set; }
	public float Vertical { get; private set; }
}

public class KeyboardInput : MonoBehaviour, IInput
{
	private float yAxis;
	private float xAxis;
	
	private void Update()
	{
		yAxis = Input.GetAxis("Vertical");
		xAxis = Input.GetAxis("Horizontal");
	}

	public float Horizontal
	{
		get { return xAxis; }
	}

	public float Vertical
	{
		get { return yAxis; }
	}
}

public interface IInput
{
	float Horizontal { get; }
	float Vertical { get; }
}