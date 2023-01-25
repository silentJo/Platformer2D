
using UnityEngine.UI;

[System.Serializable]
public class Exchange
{
    public int id;
    public Item requestedItem;
    public Image NPCIcon;
    public Image requestIcon;
    public Image questDoneIcon;
    public Image stageDoneIcon;
    public Image pannel;
    public string requestedNumber;
    public bool isQuestDone;
    public int numberReceived = 0;
}
