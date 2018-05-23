using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;
using UnityEngine.UI;

public enum ScreenCorner
{
	BottomLeft,
	BottomRight,
	TopLeft,
	TopRight
}

public class ScreenUtils
{
	public static Vector3 CornerPosition(ScreenCorner corner)
	{
		var worldRect = WorldRect();
		float xPosition, yPosition;
		
		if (corner == ScreenCorner.BottomLeft || corner == ScreenCorner.TopLeft)
		{
			xPosition = worldRect.xMin;
		}
		else
		{
			xPosition = worldRect.xMax;
		}
		
		
		if (corner == ScreenCorner.TopLeft || corner == ScreenCorner.TopRight)
		{
			yPosition = worldRect.yMax;
		}
		else
		{
			yPosition = worldRect.yMin;
		}
			
		return new Vector3(xPosition, yPosition);
	}
	
	public static Rect WorldRect()
	{
		return WorldRect(Camera.main);
	}

	public static Rect WorldRect(Camera camera)
	{
		var topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
		var bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
		return new Rect(bottomLeft, topRight - bottomLeft);
	}
}

public class GamePlay : MonoBehaviour
{
	[SerializeField] private GameObject cubeGo;
	[SerializeField] private Text bestScoretxt;
	[SerializeField] private Text currentScoreTxt;
	[SerializeField] private Text livestxt;
	[SerializeField] private int maxLives;
	[SerializeField] private float speedPerSeconds = -10;
	
	private int bestScore;
	private int currentScore;
	private int lives;

	private float _timePassed = 0;
	private float _spawnInterval = 3;

	private List<GameObject> _goList = new List<GameObject>();
	private bool gamePaused;

	private Coroutine game;
	
	private void Awake()
	{
		lives = maxLives;
		game = StartCoroutine(GamePlayCoroutine());
		StartCoroutine(UpdateRoutine());
	}

	private IEnumerator GamePlayCoroutine()
	{
		while (true)
		{
			SpawnNewCubes();
			MoveCubesToBottom();
			RemoveDeadCubes();
			yield return new WaitForEndOfFrame();
		}
	}

	private IEnumerator UpdateRoutine()
	{
		while (true)
		{
			if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(1))
			{
				Debug.Log("click");
			}
			var position = Input.mousePosition;
			var worldPositon = Camera.main.ScreenToWorldPoint(position);

			var hits = Physics.RaycastAll(new Ray(worldPositon, Vector3.forward));
			foreach (var raycastHit in hits)
			{
				_goList.Remove(raycastHit.collider.gameObject);
				Destroy(raycastHit.collider.gameObject);
			}

			yield return null;
		}
	}

	private void RemoveDeadCubes()
	{
		var cubeToRemove = _goList.Where(cube => CheckForDeath(cube)).ToList();
		_goList.RemoveAll(p => cubeToRemove.Contains(p));
	}

	private void SpawnNewCubes()
	{
		_timePassed += Time.deltaTime;
		if (_timePassed >= _spawnInterval)
		{
			SpawnCube();
			_timePassed = 0;
		}
	}

	private void MoveCubesToBottom()
	{
		foreach (var cube in _goList)
		{
			if (cube != null)
			{
				cube.transform.Translate(new Vector3(0, speedPerSeconds * Time.deltaTime, 0));
			}
		}
	}

	private void DecreaseLives()
	{
		lives--;
		livestxt.text = "Lives " + lives;
	}
	
	private bool CheckForDeath(GameObject go)
	{
		var bottomY = ScreenUtils.CornerPosition(ScreenCorner.BottomLeft).y;
		if (go.transform.position.y > bottomY) 
			return false;
		
		DecreaseLives();
		Destroy(go);

		if (lives == 0)
		{
			gamePaused = true;
		}
			
		return true;
	}

	private void SpawnCube()
	{
		var leftX = ScreenUtils.CornerPosition(ScreenCorner.BottomLeft).x;
		var rightX = ScreenUtils.CornerPosition(ScreenCorner.BottomRight).x;
		var topY = ScreenUtils.CornerPosition(ScreenCorner.TopLeft).y;
		
		var rnd = UnityEngine.Random.Range(leftX, rightX);
		var cube = Instantiate(cubeGo, new Vector3(rnd, topY, 0), Quaternion.identity);
		_goList.Add(cube);
	}
	
}
