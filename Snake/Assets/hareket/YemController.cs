using UnityEngine;

public class YemController : MonoBehaviour
{
    [SerializeField] private snake_controller _snake;
    [SerializeField] private float _minx, _maxx, _miny, _maxy; // Yem konumunu belirlemek için sınırlar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("snake") || other.CompareTag("segment"))
        {
            _snake.CreateSegment(); // Yılanı uzat
            Destroy(gameObject); // Yemi yok et

            Vector2 newPosition = GetRandomPosition(); // Yeni konumu al
            _snake.TeleportTo(newPosition); // Yılanı yeni konuma ışınlama
        }
    }

    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(_minx, _maxx);
        float y = Random.Range(_miny, _maxy);
        return new Vector2(x, y);
    }
}



