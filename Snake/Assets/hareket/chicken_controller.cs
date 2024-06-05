using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken_controller : MonoBehaviour
{
    [SerializeField] private snake_controller _snake;
    [SerializeField] private float _minx, _maxx, _miny, _maxy;

    void Start()
    {
        RandomChickenPosition();
    }

    private void RandomChickenPosition()
    {
        transform.position = new Vector2(
            Mathf.Round(Random.Range(_minx, _maxx)) + 0.5f,
            Mathf.Round(Random.Range(_miny, _maxy)) + 0.5f
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("snake")||other.CompareTag("segment"))
        {
            RandomChickenPosition();
            _snake.CreateSegment();
           
        }
    }
}






