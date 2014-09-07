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
            if(Launched)
                Launch();
        }
    }

    public MasterController Controller;
    public float Speed = 0f;
    public float MaxSpeed = 35f;
    public float Acceleration = 0.2f;

    public float InitialAngle = 135f;
    public float FinalAngle = 90f;

    public bool Invincible;
    public int Flashes = 15;
    public float FlashHold;
    public EngineController Engine;

    private bool _flashing;
    private bool _launched;

    // Use this for initialization
    private void Start()
    {
    }

    private void Update()
    {
        if (!Launched) return;

        if(Speed < MaxSpeed)
            Speed += 0.1f;

        if (Invincible && !_flashing)
            StartCoroutine(Flash());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!Launched) return;

        float tiltAngle = Mathf.Lerp(InitialAngle, FinalAngle, Math.Min(1f, Speed * 1.5f/MaxSpeed));

        //float fx = Speed;
        float v = Input.GetAxis("Vertical");
        //float fy = Speed*v;
        float turnAngle = v*45f;

        //rigidbody2D.velocity = new Vector2(fx, fy);
        transform.rotation = Quaternion.AngleAxis(tiltAngle + turnAngle, Vector3.forward);
        rigidbody2D.velocity = transform.up*Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DestroyableObstacle") && !Invincible)
        {
            Speed /= 2f;
            Invincible = true;
        }
    }

    private IEnumerator Flash()
    {
        _flashing = true;
        for(int i = 0; i < Flashes; ++i)
        {
            renderer.enabled = true;
            yield return new WaitForSeconds(FlashHold);
            renderer.enabled = false;
            yield return new WaitForSeconds(FlashHold);
        }
        renderer.enabled = true;
        _flashing = false;
        Invincible = false;
    }

    private void Launch()
    {
    }
}