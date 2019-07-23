using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour
{
    public GameData gameData;
    private string abilityDataFileName = "abilities.json";
    private string playerCharacterDataFileName = "playerCharacters.json";
    private string configDataFileName = "config.json";
    private TurnController turnController;
    
    void Start()
    {
        DontDestroyOnLoad (gameObject);
        gameData = new GameData();
        LoadAbilityData();
        LoadPlayerCharacterData();
        LoadConfigData();
        turnController = this.GetComponent<TurnController>();
        turnController.GameStart();
    }

    // Update is called once per frame
    public GameData GetGameData(){
        return gameData;
    }

    public AbilityData[] GetAbilityData(){
        return gameData.abilityData;
    }

    public AbilityData GetAbilityDataById(int id){
        foreach (AbilityData data in gameData.abilityData)
        {
            if (data.id == id) return data;
        }
        return null;
    }

    public CharacterData[] GetPlayerCharacterData(){
        return gameData.playerCharacterData;
    }

    public ConfigData GetConfigData(){
        return gameData.configData;
    }



    private void LoadAbilityData(){
        string filePath = Path.Combine(Application.streamingAssetsPath, abilityDataFileName);
        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath); 
            AbilityData[] loadedData = JsonHelper.FromJson<AbilityData>(dataAsJson);
            gameData.abilityData = loadedData;
        }
        else
        {
            Debug.LogError("Ability data file not exsit!");
        }
    }

    private void LoadPlayerCharacterData(){
        string filePath = Path.Combine(Application.streamingAssetsPath, playerCharacterDataFileName);
        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath); 
            CharacterData[] loadedData = JsonHelper.FromJson<CharacterData>(dataAsJson);
            gameData.playerCharacterData = loadedData;
        }
        else
        {
            Debug.LogError("Character data file not exsit!");
        }
    }
    private void LoadConfigData(){
        string filePath = Path.Combine(Application.streamingAssetsPath, configDataFileName);
        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath); 
            ConfigData loadedData = JsonUtility.FromJson<ConfigData>(dataAsJson);
            gameData.configData = loadedData;
        }
        else
        {
            Debug.LogError("Character data file not exsit!");
        }
    }


}
