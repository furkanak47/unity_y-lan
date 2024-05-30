<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Yılan Oyunu README</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
        }
        .container {
            width: 80%;
            margin: auto;
            overflow: hidden;
        }
        header {
            background: #333;
            color: #fff;
            padding-top: 30px;
            min-height: 70px;
            border-bottom: #77d42a 3px solid;
        }
        header h1 {
            text-align: center;
            margin: 0;
            padding-bottom: 20px;
        }
        .main {
            padding: 20px;
            background: #fff;
            margin-bottom: 20px;
        }
        .main h2, .main h3 {
            color: #333;
        }
        .main p, .main ul {
            color: #666;
        }
        .code-section {
            background: #272822;
            color: #f8f8f2;
            padding: 10px;
            margin: 20px 0;
            border-radius: 5px;
            overflow: auto;
        }
        .code-section code {
            display: block;
            white-space: pre-wrap;
        }
        .screenshot {
            text-align: center;
            margin: 20px 0;
        }
        .screenshot img {
            max-width: 100%;
            height: auto;
            border: 2px solid #333;
        }
    </style>
</head>
<body>
    <header>
        <div class="container">
            <h1>Yılan Oyunu README</h1>
        </div>
    </header>
    <div class="container">
        <div class="main">
            <h2>Proje Açıklaması</h2>
            <p>Bu proje, klasik yılan oyununa dayanan ve ışınlanma mekaniği ile iki farklı panelde yem toplama mekaniğini içeren bir oyundur. Oyuncu, yılanı kontrol ederek mümkün olduğunca çok yem toplamaya çalışır ve oyunun sonunda hangi panelde daha fazla yem toplandığını öğrenir.</p>

            <h2>Oyunun Amacı ve Özellikleri</h2>
            <ul>
                <li>Yılanı kontrol ederek yemleri toplamak.</li>
                <li>Yılanın boyunu uzatarak en uzun yılanı oluşturmak.</li>
                <li>Yılanın duvara veya kendine çarpmasını önlemek.</li>
                <li>Yem toplandığında yılanın rastgele bir konuma ışınlanması.</li>
                <li>İki farklı panelde daha fazla yem toplanmasını sağlamak.</li>
            </ul>

            <h2>Oyun Mekanikleri</h2>
            <p>Oyun, oyuncunun yılanı yön tuşları ile kontrol etmesini sağlar. Yem toplandığında yılan uzar ve rastgele bir konuma ışınlanır. Oyunun sonunda hangi panelde daha fazla yem toplandığına dair bir soru sorulur.</p>

            <h2>Oyunun Dikkat ve Hafıza Geliştirici Özellikleri</h2>
            <p>Bu oyun, oyuncunun dikkat ve hafıza yeteneklerini geliştirir. Oyuncu, yılanın hareketlerini dikkatle takip etmeli ve duvarlara veya kendine çarpmaktan kaçınmalıdır. Ayrıca, hangi panelde daha fazla yem toplandığını hatırlamak, oyuncunun hafıza kapasitesini zorlar.</p>

            <h2>Ekran Görüntüleri</h2>
            <video controls>
                <source src="oyun_videosu.mp4" type="video/mp4">
                Your browser does not support the video tag.
              </video>
              
            <div class="screenshot">
                <img src="oyun_ekrani.png" alt="Yılan Oyunu Ekran Görüntüsü">
            </div>
            <div class="screenshot">
                <img src="oyun_ekrani2.png" alt="Yılan Oyunu Ekran Görüntüsü 2">
            </div>
            <div class="screenshot">
                <img src="oyun_ekrani3.png" alt="Yılan Oyunu Ekran Görüntüsü 3">
            </div>

            <h2>Kod Yapısı ve Açıklamalar</h2>
            <div class="code-section">
                <h3>Beyaz Kutu</h3>
                
                <code>
using System.Collections;
using UnityEngine;

public class beyaztavuksayisi : MonoBehaviour
{
    private int totalChickenCount = 0;
    private float chickenStayTime = 0f;
    public float maxChickenStayTime = 0.5f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("chicken"))
        {
            chickenStayTime += Time.deltaTime;
            if (chickenStayTime >= maxChickenStayTime)
            {
                totalChickenCount++;
                Debug.Log("BEYAZ TAVUK " + totalChickenCount);
                chickenStayTime = 0f;
            }
        }
    }
}
                </code>
            </div>
           
            <div class="code-section">
                <h3>Yılan</h3>
                <code>
using System.Collections;
using UnityEngine;

public class snake_controller : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private GameObject _segmentPrefab;
    private List<GameObject> _segments = new List<GameObject>();

    void Start()
    {
        Reset();
        ResetSegment();
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
        float x = transform.position.x + _direction.x;
        float y = transform.position.y + _direction.y;
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
                </code>
            </div>
            <h2>Sonuç</h2>
            <p>Bu README dosyası, yılan oyununun temel özelliklerini, dikkat ve hafıza gelişimine katkılarını ve kod yapısını açıklamaktadır. Oyun, Unity oyun motoru kullanılarak geliştirilmiş olup, temel C# scriptleri ile oyun mekaniği oluşturulmuştur.</p>
        </div>
    </div>
</body>
</html>
