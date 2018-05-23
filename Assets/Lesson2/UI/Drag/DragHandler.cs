using UnityEngine;
using UnityEngine.UI;


public class ProceduralEventsHandlers : MonoBehaviour
{
	[SerializeField] private Button btn;

	private void OnEnable()
	{
		btn.onClick.AddListener(Handler);
	}

	private void OnDisable()
	{
		btn.onClick.RemoveListener(Handler);
	}

	private void Handler()
	{
		Debug.Log("click");
	}
}