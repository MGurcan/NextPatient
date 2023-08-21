using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	public GameObject gamePauserObject;
    public GameObject gameStarterScene;
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
				if(this.thisIndex  == 0 && SceneManager.GetActiveScene().name.Equals("PauseScene"))
				{
                    gamePauserObject.GetComponent<PauseGame>().pause();

                }
                else if (this.thisIndex == 2 && SceneManager.GetActiveScene().name.Equals("PauseScene"))
                {
                    gamePauserObject.GetComponent<PauseGame>().Exit();

                }
                else if (this.thisIndex == 0 && (SceneManager.GetActiveScene().name.Equals("StartScene") || SceneManager.GetActiveScene().name.Equals("FinishScene")))
                {
                    gamePauserObject.GetComponent<PauseGame>().NewGame();

                }
                else if (this.thisIndex == 1 && SceneManager.GetActiveScene().name.Equals("FinishScene"))
                {
                    gamePauserObject.GetComponent<PauseGame>().Exit();

                }
                else if (this.thisIndex == 2 && SceneManager.GetActiveScene().name.Equals("StartScene"))
                {
                    gamePauserObject.GetComponent<PauseGame>().Exit();

                }
                else if (this.thisIndex == 1 && SceneManager.GetActiveScene().name.Equals("StartScene"))
                {
                    gamePauserObject.GetComponent<PauseGame>().ContinueGame();

                }
            }
            else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}

    }
}
