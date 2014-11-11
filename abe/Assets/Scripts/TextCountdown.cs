using UnityEngine;

public class TextCountdown : MonoBehaviour
{
    public float LifeTime;
    public Vector3 CurrentVelocity = Vector3.zero;
    public TextMesh Text;

    public Transform Player
    {
        private get { return _player; }
        set
        {
            _player = value;
            transform.position = Player.transform.position + new Vector3(-2f, 5f, 0f);
            transform.parent = Player;
            _endPos = Player.transform.position + new Vector3(2f, 5f, 0f);
        }
    }
    private Transform _player;

    private Vector3 _endPos;

	// Use this for initialization
	void Awake ()
	{
	    Text = GetComponent<TextMesh>();
        //transform.position = PlayerCamera.ViewportToWorldPoint(new Vector3(-2f, 0.5f, PlayerCamera.nearClipPlane)) + 10f * PlayerCamera.transform.forward;
        //_endPos = PlayerCamera.ViewportToWorldPoint(new Vector3(4f, 0.5f, PlayerCamera.nearClipPlane)) + 10f * PlayerCamera.transform.forward;

        Destroy(gameObject, LifeTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = Vector3.SmoothDamp(transform.position, _endPos, ref CurrentVelocity, LifeTime);
	}
}
