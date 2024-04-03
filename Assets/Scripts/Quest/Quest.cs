using UnityEngine;

[System.Serializable]
public class Quest{

    public enum QuestType { Gathering, Talk, Reach };
    public enum QuestStatus { Waitting, Accepted, Completed };

    public string questName;
    public QuestType questType;
    public QuestStatus questStatus;

    public int cashRewards;

    [TextArea(1,3)]
    public string [] questDescription;

    [Header("Gathering Type Quest")]
    public int requireAmount;
    // public Item targetItem;


}

