using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snake_controller : MonoBehaviour
{
   private Vector2 _direction;
   [SerializeField] private GameObject _segmentPrefab;
   private List<GameObject> _segments = new List<GameObject>();

   void Start()
   {
       Reset();
       Debug.Log(_direction);
       ResetSegment();
   }
 public void TeleportTo(Vector2 position)
    {
        transform.position = position; // Yılanı yeni konuma taşı
        ResetSegment(); // Segmentleri yeni konuma göre ayarla (eğer gerekliyse)
    }
   void Update()
   {
       GetUserInput();
   }

   private void FixedUpdate()
   {
       SnakeMove();
       MoveSegment();
   }

   public void CreateSegment()
   {
       GameObject _newsegment = Instantiate(_segmentPrefab);
       _newsegment.transform.position = _segments[_segments.Count - 1].transform.position;
       _segments.Add(_newsegment);
   }

   private void RestartGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   private void Reset()
   {
       _direction = Vector2.right;
       Time.timeScale = 0.1f;
   }

   private void ResetSegment()
   {
       for (int i = 1; i < _segments.Count; i++)
       {
           Destroy(_segments[i]);
       }
       _segments.Clear();
       _segments.Add(gameObject);
       for (int i = 0; i < 3; i++)
       {
           CreateSegment();
       }
   }

   private void MoveSegment()
   {
       for (int i = _segments.Count - 1; i > 0; i--)
       {
           _segments[i].transform.position = _segments[i - 1].transform.position;
       }
   }

   private void SnakeMove()
   {
       float x, y;
       x = transform.position.x + _direction.x;
       y = transform.position.y + _direction.y;
       transform.position = new Vector2(x, y);
   }

   private void GetUserInput()
   {
       if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
       {
           _direction = Vector2.up;
       }
       else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
       {
           _direction = Vector2.down;
       }
       else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
       {
           _direction = Vector2.left;
       }
       else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
       {
           _direction = Vector2.right;
       }
   }

 
}


