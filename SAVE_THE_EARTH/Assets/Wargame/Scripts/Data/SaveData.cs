using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveData : MonoBehaviour
{
    public TMP_InputField idInputField;
    public TMP_InputField pwdInputField;

    public void SaveGameData()
    {
        Debug.Log("성공");
        string id = idInputField.text;
        string pwd = pwdInputField.text;

        // Check if ID already exists in the CSV file
        string filePath = "/Users/han-seung-yeop/Documents/GitHub/SAVE-THE-EARTH/SAVE_THE_EARTH/Assets/Wargame/Data/game_data.csv";

        if (!File.Exists(filePath))
        {
            // Create the file and write the header
            string header = "ID,Password\n";
            File.WriteAllText(filePath, header);
        }

        // Read the existing lines from the CSV file
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] splitLine = line.Split(',');
            if (splitLine.Length > 0 && splitLine[0] == id)
            {
                Debug.Log("다른 아이디로 가입하세요!");
                return; // Exit the method without saving
            }
        }

        // Prepare data to be written to the CSV file
        string data = string.Format("{0},{1}", id, pwd);

        // Append the data to the CSV file
        File.AppendAllText(filePath, data + "\n");
    }


}
