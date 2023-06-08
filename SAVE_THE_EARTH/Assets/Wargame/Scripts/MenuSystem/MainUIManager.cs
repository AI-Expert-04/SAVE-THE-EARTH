using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace WargameSystem.MenuSystem
{
    public class MainUIManager : MonoBehaviour
    {
        public int characterCount;
        int characterNum = 0;

        public void ChooosingChageScene(string name){
            CharacterSelector.instance.characterNum = characterNum;

            // Debug.Log(CharacterSelector.instance.characterNum);
            SceneManager.LoadScene(name);
        }

        public void ChangeScene(string name){
            SceneManager.LoadScene(name);
        }

        public void AddcharacterNum(){
            characterNum++;
            characterNum %= characterCount;
            //if (characterNum >= 3) characterNum = 0;
            Debug.Log(characterNum);
        }

        public void QuitGame(){
            // 해당 씬 종료.
            Application.Quit();
        }
    }
}
