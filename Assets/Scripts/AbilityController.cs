using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController: MonoBehaviour
{
    // Start is called before the first frame update
    public static AbilityBase selected_ability;
    public GameObject[] abilities;
    private DataController dataController;
    private AbilityData[] selectedAbilityData;
    private int MAX_ABILITY_NUMBERS_IN_PANEL = 4;
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Input: character已经加载完该角色的技能信息
    public void SetCurrnetPlayerAbilitiesToPanel(CharacterBase character){
        ClearAbilityPanel();
        // List<AbilityBase> currentPlayerAbilities = dataController.get
        for (int i = 0; i < MAX_ABILITY_NUMBERS_IN_PANEL; i++)
        {
            if (i >= character.ability_list.Count){
                abilities[i].SetActive(false);
                continue;
            }
            AddAbilityToPanel(character.ability_list[i]);
        }
    }


    private void ClearAbilityPanel(){
        //to do
    }

    private void AddAbilityToPanel(AbilityBase ability){
        //to do
    }


}
