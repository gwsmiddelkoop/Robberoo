using UnityEngine;

public class BackgroundManager : MonoBehaviour {

	[Range(1f, 20f)]
	public float scrollSpeed = 1f;

	public float scrollOffset;

	Vector2 startPos;

	float newPos;

	void Start ()
	{
		startPos = transform.position;
	}
	
	void LateUpdate ()
	{
		newPos = Mathf.Repeat (Time.time * - scrollSpeed, scrollOffset);

		transform.position = startPos + Vector2.right * newPos;
	}
}
