using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckData : MonoBehaviour{
    public static CheckData instance; // CheckData 클래스의 인스턴스를 담는 정적 변수
    public TMP_InputField idInputField; // 사용자의 ID를 입력받는 TMP_InputField 컴포넌트
    public TMP_InputField pwdInputField; // 사용자의 비밀번호를 입력받는 TMP_InputField 컴포넌트
    public TextMeshProUGUI uiText; // 사용자 정보를 표시하는 TextMeshProUGUI 컴포넌트
    public TextMeshProUGUI text1; // 게임 데이터의 최고값을 표시하는 TextMeshProUGUI 컴포넌트
    public TextMeshProUGUI text2; // 게임 데이터의 최고값을 표시하는 TextMeshProUGUI 컴포넌트
    public TextMeshProUGUI text3; // 게임 데이터의 최고값을 표시하는 TextMeshProUGUI 컴포넌트
    public int notlogin; // 로그인 여부를 나타내는 변수
    private int datacheck; // 데이터 확인 여부를 나타내는 변수

    public void NOTLOGINS(){
        instance = this; // CheckData 클래스의 인스턴스를 설정
        notlogin = 1; // 로그인하지 않은 상태로 설정
    }

    public void SaveGameData(){
        string id = idInputField.text; // 입력된 ID 가져오기
        string pwd = pwdInputField.text; // 입력된 비밀번호 가져오기
        string filePath = Path.Combine(Application.dataPath, "Wargame/Data/"); // UserData 파일 경로
        string gameDataFilePath = Path.Combine(Application.dataPath, "Wargame/Data/game_data.csv"); // game_data.csv 파일 경로

        instance = this;
       
        if (CheckGameCredentials(id, pwd, gameDataFilePath)){  // 입력된 ID와 PWD가 game_data.csv 파일의 ID/PWD와 일치하는지 확인
            Debug.Log("일치");
            string currentTime = System.DateTime.Now.ToString(); // 현재 시간을 로그인 시간으로 저장
            string loginTimeData = string.Format("Login Time: {0}", currentTime);
            string userFilePath = Path.Combine(filePath, id + ".csv"); // ID.CSV 파일 경로
            
            if (!File.Exists(userFilePath)){ // ID.CSV 파일에 로그인 시간 저장
                File.WriteAllText(userFilePath, "");
                Debug.Log(userFilePath + " 만듬");
            }
            else Debug.Log("데이터 추가");

            datacheck = 1; // 데이터 확인 완료
        }
        else datacheck = 0; // 데이터 확인 실패
    }

    private bool CheckGameCredentials(string id, string pwd, string gameDataFilePath)
    {
        string[] lines = File.ReadAllLines(gameDataFilePath); // game_data.csv 파일의 모든 줄 읽기
        foreach (string line in lines){ // 각 줄에 대해 ID와 PWD가 일치하는지 확인
            string[] values = line.Split(',');
            if (values.Length >= 2 && values[0] == id && values[1] == pwd) return true; // 일치하는 ID와 PWD가 있을 경우 true 반환
        }

        return false; // 일치하는 ID와 PWD가 없을 경우 false 반환
    }

    public void LoadData(){
        if (datacheck == 1){ // 데이터 확인이 되었을 때
            string filePath = Path.Combine(Application.dataPath, "Wargame/Data/" + idInputField.text + ".csv"); // 사용자의 ID를 기반으로 파일 경로 생성

            if (File.Exists(filePath)){ // 파일이 존재하는지 확인
                string[] lines = File.ReadAllLines(filePath); // 파일의 모든 줄 읽기
                List<string[]> data = new List<string[]>(); // 데이터를 저장할 리스트 생성
                
                foreach (string line in lines){ // 각 줄을 데이터 배열로 변환하여 리스트에 추가
                    string[] values = line.Split(',');
                    data.Add(values);
                }

                if (data.Count >= 5 && data[0].Length >= 3){ // 적어도 6개의 행과 6개의 열이 있는지 확인
                    string highestValue0 = FindHighestNumericValueInColumn(data, 0); // 열 0에서 가장 큰 값을 찾기
                    string highestValue1 = FindHighestNumericValueInColumn(data, 1); // 열 1에서 가장 큰 값을 찾기
                    string highestValue2 = FindHighestNumericValueInColumn(data, 2); // 열 2에서 가장 큰 값을 찾기

                    // 텍스트 필드에 가장 큰 값을 할당
                    uiText.text = idInputField.text + " : Kill Data";
                    text1.text = highestValue0;
                    text2.text = highestValue1;
                    text3.text = highestValue2;
                }
                else{ // 행 또는 열의 수가 부족한 경우 기본 또는 오류 메시지 표시
                    uiText.text = "User: " + idInputField.text;
                    text1.text = "N/A";
                    text2.text = "N/A";
                    text3.text = "N/A";
                }
            }
        }
    }

    private string FindHighestNumericValueInColumn(List<string[]> data, int columnIndex)
    {
        float highestValue = float.MinValue; // 가장 작은 값을 초기 최대값으로 설정

        foreach (string[] row in data){ // 각 행에서 주어진 열의 값을 확인하여 가장 큰 값을 찾기
            if (row.Length > columnIndex){
                string value = row[columnIndex];
                float floatValue;
                if (float.TryParse(value, out floatValue))
                {
                    if (floatValue > highestValue) highestValue = floatValue;
                }
            }
        }

        return highestValue.ToString(); // 가장 큰 값을 문자열로 반환
    }
}
