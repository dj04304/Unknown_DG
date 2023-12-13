using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

/// <summary>
/// JSON으로 Player 관리 해보기
/// </summary>
public class PlayerJsonLoad : MonoBehaviour
{
    public static PlayerJsonLoad Instance;

    public CharacterData characterData;
    // 이 위치에 Load
    public Character character;

    private void Awake()
    {
        Instance = this;
    }

    [ContextMenu("To Json Data")]
    public void SavePlayerDataToJson(CharacterData dataToSave)
    {
        // 타임스탬프로 파일 구분해줌
        string timeStamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");

        // 파일 이름
        string fileName = "JSON/playerData_" + timeStamp + ".json";

        // JSON형태로 포맷팅
        string jsonData = JsonUtility.ToJson(dataToSave);
        
        // 경로 저장
        string path = Path.Combine(Application.dataPath, fileName);
    
        File.WriteAllText(path, jsonData);

    }

    [ContextMenu("Load Json Data")]
    void LoadPlayerDataFromJson()
    {
        // Json 파일이 저장된 디렉토리 경로
        string directoryPath = Path.Combine(Application.dataPath, "Json");

        // 디렉토리에 있는 모든 Json 파일 가져오기
        string[] jsonFiles = Directory.GetFiles(directoryPath, "playerData_*.json");

        // 파일이 하나 이상 존재하는 경우 첫 번째 파일을 로드
        if (jsonFiles.Length > 0)
        {
            string filePath = jsonFiles[0];
            string jsonData = File.ReadAllText(filePath);

            // ScriptableObject는 JsonUtility로 직접 역직렬화할 수 없다..
            // 대신 ScriptableObject.CreateInstance<CharacterData>()를 사용하여 새 인스턴스를 만든다.
            // ScriptableObject를 생성하고 데이터를 불러옴
            CharacterData loadedCharacterData = ScriptableObject.CreateInstance<CharacterData>();
            JsonUtility.FromJsonOverwrite(jsonData, loadedCharacterData);

            // Character 클래스에 불러온 데이터 할당
            character.CharacterData = loadedCharacterData;
            // 역직렬화된 JSON 데이터를 ScriptableObject에 적용합니다.
            //JsonUtility.FromJsonOverwrite(jsonData, character.CharacterData);
        }
        else
        {
            Debug.LogWarning("Data Not Found");
        }
    }


}
