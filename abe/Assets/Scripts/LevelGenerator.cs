using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{
    public Transform RightBound;
    public Transform LeftBound;
    public float MinObstacleFrequency = 10f;
    public float GridUnitSize = 2f; // Obstacles will snap grid with this unit size
    public GameObject Obstacle;
    public float GeneratorDistance; // Distance from player at which to generate an obstacle

    private float _nextZ;

    // Use this for initialization
    private void Start()
    {
        _nextZ = transform.position.z + GeneratorDistance + GridUnitSize;
    }

    // Update is called once per frame
    private void Update()
    {
        float zPos = transform.position.z + GeneratorDistance + GridUnitSize;

        if (zPos >= _nextZ)
        {
            _nextZ = zPos + Random.Range(GridUnitSize, MinObstacleFrequency*GridUnitSize);

            // Generate our obstacle
            //float range = RightBound.position.x - LeftBound.position.x;
            float xPos = Mathf.Floor(Random.Range(LeftBound.position.x, RightBound.position.x) / GridUnitSize) * GridUnitSize;

            Instantiate(Obstacle, new Vector3(xPos, 0f, zPos), Quaternion.identity);
        }
    }
}
