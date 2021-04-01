using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI{
public class UIModel : MonoBehaviour {}	
	interface IModelLayer{
		void OnClickButton(GameObject thisObj);
	}

    class PlayButton : IModelLayer
    {
        public void OnClickButton(GameObject thisObj)
        {
        	SceneManager.LoadScene("Gameplay");
        }
    }

    class SettingsButton : IModelLayer
    {
        public void OnClickButton(GameObject thisObj)
        {
            Debug.Log("Settings");
        }
    }

    class ExitButton : IModelLayer
    {
        public void OnClickButton(GameObject thisObj)
        {
            Application.Quit();
        }
    }

    class PauseButton : IModelLayer
    {
        public void OnClickButton(GameObject thisObj){
            Animation _anim = thisObj.transform.GetChild(0).gameObject.GetComponent<Animation>();
            _anim.Play("PanelAnimationEnable");
            
            thisObj.GetComponent<UIController>().enabled = false;
            thisObj.GetComponent<Image>().enabled = false;
        }
    }

    class ResumeButton : IModelLayer
    {
        public void OnClickButton(GameObject thisObj){
            Transform PauseButtonOn = thisObj.transform.parent.gameObject.transform.parent;

            Animation _anim = thisObj.transform.parent.gameObject.gameObject.GetComponent<Animation>();
            _anim.Play("PanelAnimationDisabled");
            
            PauseButtonOn.GetComponent<Image>().enabled = true;
            PauseButtonOn.GetComponent<UIController>().enabled = true;
        }
    }

    class MenuButton : IModelLayer
    {
        public void OnClickButton(GameObject thisObj)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    class GakButton : IModelLayer
    {
        public void OnClickButton(GameObject thisObj)
        {
            SceneManager.LoadScene("GAK");
        }
    }

    class ExitBuildingButton : IModelLayer
    {
        public void OnClickButton(GameObject thisObj)
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    class MathTicketData : IModelLayer
    {
        public void OnClickButton(GameObject thisObj)
        {   
            string key = thisObj.name;
            PlayerPrefs.SetString("examKey", key);
            // if(PlayerPrefs.GetString("Math").Equals(0))
            SceneManager.LoadScene("MiniGame");
        }
    }

    class ExamButton : IModelLayer
    {
        public void OnClickButton(GameObject thisObj)
        {   
            SceneManager.LoadScene("Exam");
        }
    }

    class ExitToGAK : IModelLayer
    {
        public void OnClickButton(GameObject thisObj)
        {   
            SceneManager.LoadScene("GAK");
        }
    }

    
}
