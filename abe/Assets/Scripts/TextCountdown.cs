using UnityEngine;
using System.Collections;

public class TextCountdown : MonoBehaviour
{
    public float LifeTime;
    public Vector3 CurrentVelocity = Vector3.zero;
    public TextMesh Text;

    public Vector3 _endPos;

	// Use this for initialization
	void Awake ()
	{
	    Text = GetComponent<TextMesh>();
	    transform.position = Camera.main.ViewportToWorldPoint(new Vector3(-2f, 0.5f, Camera.main.nearClipPlane)) + 10f * Camera.main.transform.forward;
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
	    _endPos = Camera.main.ViewportToWorldPoint(new Vector3(4f, 0.5f, Camera.main.nearClipPlane)) + 10f * Camera.main.transform.forward;
        //_endPos = new Vector3(_endPos.x, _endPos.y, 0f);

        Destroy(gameObject, LifeTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = Vector3.SmoothDamp(transform.position, _endPos, ref CurrentVelocity, LifeTime);
	}
}
