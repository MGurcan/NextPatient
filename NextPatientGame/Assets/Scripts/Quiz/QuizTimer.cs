using UnityEngine;
using UnityEngine.UI;

public class QuizTimer : MonoBehaviour
{
    public float totalTime = 10f; // Toplam s�re (saniye cinsinden)
    public float warningTime = 10f; // Uyar� i�in belirlenen s�re (saniye cinsinden)
    public float currentTime;
    public Text timerText;

    public bool isTimerRunning = false;

    public delegate void QuizFinished();
    public static event QuizFinished OnQuizFinished;
    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            // Zaman� g�ncelle
            currentTime -= Time.deltaTime;

            // S�re bitti�inde ne olaca��n� burada kontrol edebilirsiniz
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                StopTimer();
                // Quiz bitti�inde olay� tetikle
                if (OnQuizFinished != null)
                {
                    OnQuizFinished();
                }
                // S�re bitti�inde yap�lacak i�lemler
                // �rne�in: Quiz oyununu durdurabilir veya sonu�lar� g�sterebilirsiniz.
            }

            // Zaman� ekrana g�stermek i�in formatlay�p UI elementine atay�n
            timerText.text = FormatTime(currentTime);

            // S�re 10 saniyenin alt�na indi�inde metni k�rm�z� yap
            if (currentTime <= warningTime)
            {
                timerText.color = Color.red;
            }
            else
            {
                // S�re 10 saniyenin alt�nda de�ilse metni beyaz yap (ya da ba�ka bir renk)
                timerText.color = Color.white;
            }
        }
        
    }

    // Zaman� dakika ve saniye format�nda g�stermek i�in bu fonksiyonu kullanabilirsiniz
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Zaman� ba�latmak i�in bu metod kullan�l�r
    public void StartTimer()
    {
        currentTime = totalTime;
        isTimerRunning = true;
    }

    // Zaman� durdurmak i�in bu metod kullan�l�r
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void AddExtraTime(float extraTime)
    {
        currentTime += extraTime;
    }
}
