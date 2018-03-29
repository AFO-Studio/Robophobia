using UnityEngine;

public class scrollCloud : MonoBehaviour
{
    private Vector3 startPosition;

    public float scrollSpeed;
	public float tileSizeZ;

	void Start()
	{
		startPosition = transform.position;
	}

	void Update()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.right * newPosition;
	}
}