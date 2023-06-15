using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public List<Kkuing> characterList; // 캐릭터 목록을 저장하는 리스트
    public static CharacterSelector instance; // 싱글톤 인스턴스
    public int characterNum; // 선택된 캐릭터 번호

    private void Awake()
    {
        if (CharacterSelector.instance != null)
            Destroy(gameObject); // 인스턴스가 이미 존재하면 현재 게임 오브젝트를 파괴
        instance = this; // 현재 인스턴스를 싱글톤 인스턴스로 설정
        DontDestroyOnLoad(gameObject); // 씬 전환 시에도 게임 오브젝트가 파괴되지 않도록 설정
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로드 이벤트에 OnSceneLoaded 메서드를 연결
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
            Instantiate(characterList[CharacterSelector.instance.characterNum]); // "Game" 씬이 로드되면 선택된 캐릭터를 인스턴스화
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 게임 오브젝트가 파괴될 때 씬 로드 이벤트에서 OnSceneLoaded 메서드를 연결 해제
    }
}
