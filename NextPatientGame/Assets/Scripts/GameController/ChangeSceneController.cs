using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{
    public GameObject OfficeHolder;
    public GameObject LibraryHolder;

    /*
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene);
    }
    */

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            if(OfficeHolder.activeSelf)
            {
                ActiveComponent("Library");
            }
            else if(LibraryHolder.activeSelf)
            {
                ActiveComponent("Office");
            }
            
        }
    }

    public void ActiveComponent(string scene)
    {
        if(scene == "Office")
        {
            LibraryHolder.SetActive(false);
            OfficeHolder.SetActive(true);
            
        }
        else if(scene == "Library")
        {
            OfficeHolder.SetActive(false);
            LibraryHolder.SetActive(true);
        }
    }

}
