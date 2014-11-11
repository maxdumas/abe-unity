using UnityEngine;
using System.Collections;

public class TrackTarget : MonoBehaviour
{
    public Transform Target;
    public bool TrackHorizontal = true;
    public bool TrackVertical = true;
    public bool TrackDepth = true;

    private Vector3 _initialOffset;

	// Use this for initialization
	void Start ()
	{
        _initialOffset = transform.position - Target.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 trackPosition = new Vector3
	    {
	        x = TrackHorizontal ? (Target.position.x + _initialOffset.x) : transform.position.x,
	        y = TrackVertical ? (Target.position.y + _initialOffset.y) : transform.position.y,
	        z = TrackDepth ? (Target.position.z + _initialOffset.z) : transform.position.z
	    };

        transform.position = trackPosition;
	}
}
