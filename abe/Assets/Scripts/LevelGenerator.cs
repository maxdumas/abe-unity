using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{
    public MasterController Controller;
    public Transform UpperBound;
    public Transform LowerBound;
    public float MinObstacleFrequency = 10f;
    public float GridUnitSize = 2f; // Obstacles will snap grid with this unit size
    public GameObject Obstacle;

    private float _levelRadius;
    private float _screenHalfWidth;
    private float _nextX;

    // Use this for initialization
    private void Start()
    {
        Vector3 tl = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 tr = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.nearClipPlane));
        _screenHalfWidth = (tl - tr).magnitude/2f;

        _levelRadius = Controller.LevelCircumference/(Mathf.PI*2f);

        _nextX = transform.position.x + _screenHalfWidth + GridUnitSize;
    }

    // Update is called once per frame
    private void Update()
    {
        // We want to generate obstacles in between the y-coordinates of upperbound and lowerbound with some regularity.
        // Remember - the loop will never be repeated, as each player starts on opposite ends of it, and once they pass a new loop with half circumference is created

        
        float xPos = transform.position.x + _screenHalfWidth + GridUnitSize;

        if (xPos >= _nextX)
        {
            _nextX = xPos + Random.Range(GridUnitSize, MinObstacleFrequency*GridUnitSize);

            // Generate our obstacle
            float range = UpperBound.position.y - LowerBound.position.y;
            float yPos = Mathf.Floor(Random.Range(LowerBound.position.y, UpperBound.position.y) / GridUnitSize) * GridUnitSize;

            Instantiate(Obstacle, new Vector3(xPos, yPos, 0f), Quaternion.identity);
        }
    }
}
