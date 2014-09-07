using UnityEngine;
using System.Collections;

public class EngineController : MonoBehaviour
{
    public GameObject LaunchSystem;
    public float LaunchSystemLifetime;

    private ParticleSystem _particles;
    private AudioSource _audio;

    // Use this for initialization
    private void Start()
    {
        _particles = GetComponent<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void Ignite()
    {
        _particles.Play();
        _audio.Play();
        LaunchSystem.SetActive(true);
        Destroy(LaunchSystem, LaunchSystemLifetime);
    }
}