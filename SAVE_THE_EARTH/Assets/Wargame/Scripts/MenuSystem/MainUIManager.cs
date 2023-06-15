using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace WargameSystem.MenuSystem
{
    public class MainUIManager : MonoBehaviour
    {
        public int characterCount; // 캐릭터 개수
        int characterNum = 0; // 현재 선택된 캐릭터 번호

        public void ChooosingChageScene(string name)
        {
            CharacterSelector.instance.characterNum = characterNum; // CharacterSelector의 characterNum에 현재 선택된 캐릭터 번호를 저장

            SceneManager.LoadScene(name); // 지정된 이름의 씬으로 전환
        }

        public void ChangeScene(string name)
        {
            SceneManager.LoadScene(name); // 지정된 이름의 씬으로 전환
        }

        public void AddcharacterNum()
        {
            characterNum++; // 캐릭터 번호 증가
            characterNum %= characterCount; // 캐릭터 번호가 characterCount를 넘어가면 다시 0으로 설정
            Debug.Log(characterNum); // 현재 선택된 캐릭터 번호를 로그로 출력
        }

        public void QuitGame()
        {
            Application.Quit(); // 게임 종료
        }
    }
}
