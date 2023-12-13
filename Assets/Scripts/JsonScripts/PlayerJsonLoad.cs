using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

/// <summary>
/// JSON���� Player ���� �غ���
/// </summary>
public class PlayerJsonLoad : MonoBehaviour
{
    public static PlayerJsonLoad Instance;

    public CharacterData characterData;
    // �� ��ġ�� Load
    public Character character;

    private void Awake()
    {
        Instance = this;
    }

    [ContextMenu("To Json Data")]
    public void SavePlayerDataToJson(CharacterData dataToSave)
    {
        // Ÿ�ӽ������� ���� ��������
        string timeStamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");

        // ���� �̸�
        string fileName = "JSON/playerData_" + timeStamp + ".json";

        // JSON���·� ������
        string jsonData = JsonUtility.ToJson(dataToSave);
        
        // ��� ����
        string path = Path.Combine(Application.dataPath, fileName);
    
        File.WriteAllText(path, jsonData);

    }

    [ContextMenu("Load Json Data")]
    void LoadPlayerDataFromJson()
    {
        // Json ������ ����� ���丮 ���
        string directoryPath = Path.Combine(Application.dataPath, "Json");

        // ���丮�� �ִ� ��� Json ���� ��������
        string[] jsonFiles = Directory.GetFiles(directoryPath, "playerData_*.json");

        // ������ �ϳ� �̻� �����ϴ� ��� ù ��° ������ �ε�
        if (jsonFiles.Length > 0)
        {
            string filePath = jsonFiles[0];
            string jsonData = File.ReadAllText(filePath);

            // ScriptableObject�� JsonUtility�� ���� ������ȭ�� �� ����..
            // ��� ScriptableObject.CreateInstance<CharacterData>()�� ����Ͽ� �� �ν��Ͻ��� �����.
            // ScriptableObject�� �����ϰ� �����͸� �ҷ���
            CharacterData loadedCharacterData = ScriptableObject.CreateInstance<CharacterData>();
            JsonUtility.FromJsonOverwrite(jsonData, loadedCharacterData);

            // Character Ŭ������ �ҷ��� ������ �Ҵ�
            character.CharacterData = loadedCharacterData;
            // ������ȭ�� JSON �����͸� ScriptableObject�� �����մϴ�.
            //JsonUtility.FromJsonOverwrite(jsonData, character.CharacterData);
        }
        else
        {
            Debug.LogWarning("Data Not Found");
        }
    }


}
