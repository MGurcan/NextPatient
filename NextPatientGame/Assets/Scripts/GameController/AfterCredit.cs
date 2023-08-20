using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCredit : MonoBehaviour
{
    private float delay = 18.0f; // Bekleme s�resi

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