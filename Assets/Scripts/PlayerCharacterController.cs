using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    private CharacterData[] playerCharacterData;
    public CharacterBase[] playerCharacters;
    private DataController dataController;
    void Start()
    {
        dataController = this.GetComponent<DataController>();
        // initPlayerCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CharacterData[] GetCharacterData(){
       return dataController.GetPlayerCharacterData();
    }

    public CharacterBase[] GetPlayerCharacters(){
        return playerCharacters;
    }

    public void initPlayerCharacters(){
        playerCharacterData = dataController.GetPlayerCharacterData();
        for (int i = 0; i < playerCharacters.Length; i++)
        {
            //玩家选择了少于4个角色进入战斗，将没有用的角色panel暂停
            if (i>=playerCharacterData.Length){
                playerCharacters[i].gameObject.SetActive(false);
                continue;
            }
            playerCharacters[i].initPropertiesByData(playerCharacterData[i]);
        }
    }

    // public AbilityData[] getCarriedAbilities(){
    //     AbilityData[] result;
    //     if (dataController.GetConfigData().debug){
    //         result = new AbilityData[]{ 
    //             dataController.GetAbilityDataById(1),
    //             dataController.GetAbilityDataById(2),
    //             dataController.GetAbilityDataById(3),
    //             dataController.GetAbilityDataById(4),
    //         };
    //         return result;
    //     }
    // }
}
