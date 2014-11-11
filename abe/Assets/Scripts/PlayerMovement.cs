using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public bool Launched
    {
        get { return _launched; }
        set
        {
            _launched = value;
            if (Launched)
                Launch();
        }
    }

    public float Speed = 0f;
    public float MaxSpeed = 35f;
    public float Acceleration = 0.1f;

    //public float InitialAngle = 135f;
    //public float FinalAngle = 90f;

    public bool Invincible;
    public int Flashes = 15;
    public float FlashHold;
    public EngineController Engine;

    private Quaternion _initialRotation;
    private bool _flashing;
    private bool _launched;

    private Renderer _modelRenderer;

    // Use this for initialization
    private void Start()
    {
        _modelRenderer = GetComponentInChildren<MeshRenderer>();
        _initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (!Launched)
            return;

        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

        if (Speed < MaxSpeed)
            Speed += Acceleration;

        if (Invincible && !_flashing)
            StartCoroutine(Flash());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!Launched) return;

        float horizontalAxis = Input.GetAxis("Horizontal");
        float turnAngle = horizontalAxis * 45f;
        transform.rotation = Quaternion.AngleAxis(turnAngle, Vector3.up) * _initialRotation;

        var planarDir = new Vector3(transform.up.x, 0f, transform.up.z);
        rigidbody.velocity = planarDir * Speed;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit!");
        if (other.gameObject.CompareTag("DestroyableObstacle") && !Invincible)
        {
            Speed /= 2f;
            Invincible = true;
        }
    }

    private IEnumerator Flash()
    {
        _flashing = true;
        for (int i = 0; i < Flashes; ++i)
        {
            _modelRenderer.enabled = true;
            yield return new WaitForSeconds(FlashHold);
            _modelRenderer.enabled = false;
            yield return new WaitForSeconds(FlashHold);
        }
        _modelRenderer.enabled = true;
        _flashing = false;
        Invincible = false;
    }

    private void Launch()
    {
    }
}