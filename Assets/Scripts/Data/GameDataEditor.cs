using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class GameDataEditor : EditorWindow
{

    public GameData gameData;
    public AbilityData[] abilityData;
    public CharacterData[] defaultCharacterData;
    public CharacterData[] playerCharacterData;
    public ConfigData configData;
    private string abilityDataProjectFilePath = "/StreamingAssets/abilities.json";
    private string configDataProjectFilePath = "/StreamingAssets/config.json";
    // private string gameDataProjectFilePath = "/StreamingAssets/data.json";
    private string defaultCharacterDataProjectFilePath = "/StreamingAssets/defaultCharacters.json";
    private string playerCharacterDataProjectFilePath = "/StreamingAssets/playerCharacters.json";


    [MenuItem("Window/Game Data Editor")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(GameDataEditor)).Show();
    }

    public void Awake(){
        gameData = new GameData();
    }
    void OnGUI()
    {
        if (gameData != null)
        {
            //load ability
            
            if (gameData.abilityData != null && gameData.abilityData.Length > 0)
            {
                SerializedObject serializedObject = new SerializedObject(this);
                SerializedProperty serializedProperty = serializedObject.FindProperty("abilityData");
                EditorGUILayout.PropertyField(serializedProperty, true);
                serializedObject.ApplyModifiedProperties();
                if (GUILayout.Button("Save Ability Data"))
                {
                    SaveAbilityData();
                }
            }
            //load default character
            if (gameData.defaultCharacterData != null && gameData.defaultCharacterData.Length>0)
            {
                SerializedObject serializedObject = new SerializedObject(this);
                SerializedProperty serializedProperty = serializedObject.FindProperty("defaultCharacterData");
                EditorGUILayout.PropertyField(serializedProperty, true);
                serializedObject.ApplyModifiedProperties();

                if (GUILayout.Button("Save Default Character Data"))
                {
                    SaveDefaultCharacterData();
                }
            }
            //load player character
            if (gameData.playerCharacterData != null && gameData.defaultCharacterData.Length>0)
            {
                SerializedObject serializedObject = new SerializedObject(this);
                SerializedProperty serializedProperty = serializedObject.FindProperty("playerCharacterData");
                EditorGUILayout.PropertyField(serializedProperty, true);
                serializedObject.ApplyModifiedProperties();

                if (GUILayout.Button("Save Player Character Data"))
                {
                    SavePlayerCharacterData();
                }
            }
            //load config
            if (gameData.configData != null && configData!= null)
            {
                SerializedObject serializedObject = new SerializedObject(this);
                SerializedProperty serializedProperty = serializedObject.FindProperty("configData");
                EditorGUILayout.PropertyField(serializedProperty, true);
                serializedObject.ApplyModifiedProperties();

                if (GUILayout.Button("Save Config Data"))
                {
                    SaveConfigData();
                }
            }
            if (GUILayout.Button("Close Everything"))
            {
                gameData = null;
            }
            EditorGUILayout.Space();
            GuiLine();
            EditorGUILayout.Space();
        }

        if (GUILayout.Button("Load Ability Data"))
        {
            LoadAbilityData();
        }
        if (GUILayout.Button("Load Default Character Data"))
        {
            LoadDefaultCharacterData();
        }
        if (GUILayout.Button("Load Player Character Data"))
        {
            LoadPlayerCharacterData();
        }
        if (GUILayout.Button("Load Config Data"))
        {
            LoadConfigData();
        }

    }
    private void LoadAbilityData()
    {
        string filePath = Application.dataPath + abilityDataProjectFilePath;
        // gameData = new GameData();

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            abilityData = JsonHelper.FromJson<AbilityData>(dataAsJson);
        }
        else
        {
            abilityData = new AbilityData[5];
        }
        gameData.abilityData = abilityData;
    }

    private void LoadDefaultCharacterData()
    {
        string filePath = Application.dataPath + defaultCharacterDataProjectFilePath;
        // gameData = new GameData();

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            defaultCharacterData = JsonHelper.FromJson<CharacterData>(dataAsJson);
        }
        else
        {
            defaultCharacterData = new CharacterData[5];
        }
        gameData.defaultCharacterData = defaultCharacterData;
    }

    private void LoadPlayerCharacterData()
    {
        string filePath = Application.dataPath + playerCharacterDataProjectFilePath;
        // gameData = new GameData();
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            playerCharacterData = JsonHelper.FromJson<CharacterData>(dataAsJson);
        }
        else
        {
            playerCharacterData = new CharacterData[5];
        }
        gameData.playerCharacterData = playerCharacterData;
    }
    private void LoadConfigData()
    {
        string filePath = Application.dataPath + configDataProjectFilePath;
        // gameData = new GameData();
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            configData = JsonUtility.FromJson<ConfigData>(dataAsJson);
        }
        else
        {
            configData = new ConfigData();
        }
        gameData.configData = configData;
    }

    // private void SaveData(object[] obj, string path)
    // {
    //     string dataAsJson = JsonHelper.ToJson (obj,true);
    //     string filePath = Application.dataPath + path;
    //     File.WriteAllText (filePath, dataAsJson);
    // }

    private void SaveAbilityData()
    {
        string dataAsJson = JsonHelper.ToJson(abilityData, true);
        string filePath = Application.dataPath + abilityDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }
    private void SaveDefaultCharacterData()
    {
        string dataAsJson = JsonHelper.ToJson(defaultCharacterData, true);
        string filePath = Application.dataPath + defaultCharacterDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }
    private void SavePlayerCharacterData()
    {
        string dataAsJson = JsonHelper.ToJson(playerCharacterData, true);
        string filePath = Application.dataPath + playerCharacterDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }
    private void SaveConfigData()
    {
        string dataAsJson = JsonUtility.ToJson(configData, true);
        string filePath = Application.dataPath + configDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }

    void GuiLine(int i_height = 1)
    {

        Rect rect = EditorGUILayout.GetControlRect(false, i_height);

        rect.height = i_height;

        EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));

    }
}