using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CheckData : MonoBehaviour
{
    public TMP_InputField idInputField;
    public TMP_InputField pwdInputField;

    public void SaveGameData()
    {
        string id = idInputField.text;
        string pwd = pwdInputField.text;

        // game_data.csv 파일 경로
        string gameDataFilePath = "/Users/han-seung-yeop/Space Lost/Assets/Wargame/Data/game_data.csv";
        string FilePath = "/Users/han-seung-yeop/Space Lost/Assets/Wargame/Data/";
        // 입력된 ID와 PWD가 game_data.csv 파일의 ID/PWD와 일치하는지 확인
        if (CheckGameCredentials(id, pwd, gameDataFilePath))
        {
            Debug.Log("일치");
            // 현재 시간을 로그인 시간으로 저장
            string currentTime = System.DateTime.Now.ToString();
            string loginTimeData = string.Format("Login Time: {0}", currentTime);

            // ID.CSV 파일 생성
            string userFilePath = Path.Combine(FilePath, id + ".csv");

            // ID.CSV 파일에 로그인 시간 저장
            File.WriteAllText(userFilePath, loginTimeData + "\n");

            // 캐릭터 번호, 외계인 Kill, 운석 파괴 값을 저장할 공간 추가
            string gameData = string.Format("Character: {0}, Alien Kills: {1}, Meteor Destroyed: {2}", 0, 0, 0);
            File.AppendAllText(userFilePath, gameData + "\n");
        }
    }

    private bool CheckGameCredentials(string id, string pwd, string gameDataFilePath)
    {
        string[] lines = File.ReadAllLines(gameDataFilePath);

        foreach (string line in lines)
        {
            string[] values = line.Split(',');
            if (values.Length >= 2 && values[0] == id && values[1] == pwd)
            {
                return true;
            }
        }

        return false;
    }
}
