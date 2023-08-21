using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Takip edilecek karakter nesnesi
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Örnek bir offset değeri
    public float smoothSpeed = 0.125f; // Kamera takip yumuşaklığı

    void LateUpdate()
    {
        // Hedef konuma ulaşmak için hedef konumu hesapla
        Vector3 desiredPosition = target.position + offset;

        // Kamera konumunu yumuşakça güncelle
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Kamera daima hedefi takip etsin
        transform.LookAt(target);
    }
}