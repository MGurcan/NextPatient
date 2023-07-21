using UnityEngine;
using UnityEngine.UI;

public class QuizTimer : MonoBehaviour
{
    public float totalTime = 10f; // Toplam süre (saniye cinsinden)
    public float warningTime = 10f; // Uyarý için belirlenen süre (saniye cinsinden)
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
            // Zamaný güncelle
            currentTime -= Time.deltaTime;

            // Süre bittiðinde ne olacaðýný burada kontrol edebilirsiniz
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                StopTimer();
                // Quiz bittiðinde olayý tetikle
                if (OnQuizFinished != null)
                {
                    OnQuizFinished();
                }
                // Süre bittiðinde yapýlacak iþlemler
                // Örneðin: Quiz oyununu durdurabilir veya sonuçlarý gösterebilirsiniz.
            }

            // Zamaný ekrana göstermek için formatlayýp UI elementine atayýn
            timerText.text = FormatTime(currentTime);

            // Süre 10 saniyenin altýna indiðinde metni kýrmýzý yap
            if (currentTime <= warningTime)
            {
                timerText.color = Color.red;
            }
            else
            {
                // Süre 10 saniyenin altýnda deðilse metni beyaz yap (ya da baþka bir renk)
                timerText.color = Color.white;
            }
        }
        
    }

    // Zamaný dakika ve saniye formatýnda göstermek için bu fonksiyonu kullanabilirsiniz
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Zamaný baþlatmak için bu metod kullanýlýr
    public void StartTimer()
    {
        currentTime = totalTime;
        isTimerRunning = true;
    }

    // Zamaný durdurmak için bu metod kullanýlýr
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void AddExtraTime(float extraTime)
    {
        currentTime += extraTime;
    }
}
