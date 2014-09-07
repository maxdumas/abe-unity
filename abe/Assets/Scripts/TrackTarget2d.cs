using UnityEngine;
using System.Collections;

public class TrackTarget2d : MonoBehaviour
{
    public Transform Target;
    public bool TrackHorizontal = true;
    public bool TrackVertical = true;
    public bool TrackRotationX = false;
    public bool TrackRotationY = false;
    public bool TrackRotationZ = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 trackPosition = new Vector3
        {
            x = TrackHorizontal ? Target.position.x : transform.position.x,
            y = TrackVertical ? Target.position.y : transform.position.y,
            z = transform.position.z
        };

        transform.position = trackPosition;

	    Vector3 trackRotation = new Vector3
	    {
	        x = TrackRotationX ? Target.rotation.x : transform.rotation.x,
	        y = TrackRotationY ? Target.rotation.y : transform.rotation.y,
	        z = TrackRotationZ ? Target.rotation.z : transform.rotation.z
	    };

	    transform.rotation = Quaternion.Euler(trackRotation);
	}
}
