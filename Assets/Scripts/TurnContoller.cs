using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    // Start is called before the first frame update
    private AbilityController abilityController;
    private PlayerCharacterController playerCharacterController;
    private EnemyController enemyController;
    public List<CharacterBase> thisTurn;
    public List<CharacterBase> nextTurn;
    private bool battleFinished = false;
    private CharacterBase currentCharacter;
    public void GameStart()
    {
        abilityController = FindObjectOfType<AbilityController>();
        playerCharacterController = FindObjectOfType<PlayerCharacterController>();
        enemyController = FindObjectOfType<EnemyController>();
        InitCharacter();
        InitEnemy();
        InitTurnList();
        BattleStart();
    }

    private void InitCharacter()
    {
        playerCharacterController.initPlayerCharacters();
    }

    private void InitEnemy()
    {
        enemyController.initEnemy();
    }

    private void InitTurnList()
    {
        thisTurn = new List<CharacterBase>();
        thisTurn.AddRange(playerCharacterController.GetPlayerCharacters());
        thisTurn.AddRange(enemyController.getEnemies());
        thisTurn.Sort((x, y) => x.data.speed.CompareTo(y.data.speed));
        nextTurn = new List<CharacterBase>(thisTurn);
    }

    private void CharacterTurnStarts(CharacterBase character)
    {
        abilityController.SetCurrnetPlayerAbilitiesToPanel(character);
    }

    private void BattleStart()
    {
        currentCharacter = thisTurn[0];
        if (thisTurn[0] is PlayerCharacter)
        {
            PlayerCharacterTurnStart((PlayerCharacter)thisTurn[0]);
        }
        else if (thisTurn[0] is EnemyBase)
        {
            EnemyTurnStart((EnemyBase)thisTurn[0]);
        }

        //wait player action
    }


    private void PlayerCharacterTurnStart(PlayerCharacter playerCharacter)
    {

    }

    private void EnemyTurnStart(EnemyBase enemy)
    {

    }

    private void NextTurn()
    {
        //todo -- 本轮结束
        thisTurn.RemoveAt(0);
        currentCharacter = thisTurn[0];
    }

    private void NextOne()
    {
        //todo -- 下一位角色
    }

    private void CharacterSkip()
    {
        //todo -- 玩家选择了skip该角色
    }



}
