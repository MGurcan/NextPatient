using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCredit : MonoBehaviour
{
    private float delay = 18.0f; // Bekleme süresi

    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Office");
    }

}