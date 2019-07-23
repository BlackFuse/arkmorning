[System.Serializable]
public class CharacterData {
    public int id;
	public string name;
	public string description;
    public int HP{get;set;}
    public int MaxHP;
    public int energy;
    public int MaxEnegy;
    public int speed;
    public int attack;
	public int[] allowedAbilitiesID;
    public AbilityData[] allowedAbilities;
    public AbilityData[] carriedAbilities;

}