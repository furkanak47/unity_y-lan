using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class beyaztavuksayisi : MonoBehaviour
{
    // Kutuya giren tavuk sayısı
    public int whitetotalChickenCount = 0;
    // Tavuğun tetikleyicide ne kadar süre kaldığını tutar
    private float chickenStayTime = 0f;
    // Bir tavuğun tetikleyicide kalabileceği maksimum süre
    public float maxChickenStayTime = 0.5f;

    // Kutunun içindeki collider ile başka bir nesne çarpıştığında tetiklenir
    private void OnTriggerStay2D(Collider2D other)
    {
        // Eğer çarpışan nesne "chicken" tag'ine sahipse
        if (other.CompareTag("chicken"))
        {
            // Tavuğun tetikleyicide kalma süresini güncelle
            chickenStayTime += Time.deltaTime;

            // Eğer tavuk tetikleyicide belirlenen süreden daha fazla kalırsa
            if (chickenStayTime >= maxChickenStayTime)
            {
                // Tavuk kutuya girdiğinde toplam tavuk sayısını artır
                whitetotalChickenCount++;
                Debug.Log("Tavuk kutuya girdi. Toplam tavuk sayısı:BEYAZ TAVUK " + whitetotalChickenCount);
                
                // Tavuk tetikleyiciden çıktığı için tetikleyicide kaldığı süreyi sıfırla
                chickenStayTime = 0f;
            }
        }
    }
}

