using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> content = new List<Item>();

    [SerializeField] TextMeshProUGUI[] inventoryStatusTexts; 
    [SerializeField] private Image itemImageUI;
    [SerializeField] private Sprite emptyItemImage;

    private int contentCurrentIndex = 0;
    public AudioSource audioSource;

    public PlayerEffects playerEffects;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of Inventory in the scene.");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        UpdateInventoryUI();
    }

    public void ConsumeItem()
    {
        if (content.Count == 0) return;
        Item currentItem = content[contentCurrentIndex];
        
        if(currentItem.isBonus)
        {
            if(currentItem.speedGiven != 0) playerEffects.AddMoveSpeed(currentItem.speedGiven, currentItem.speedDuration);
            if(currentItem.jumpForceGiven != 0) playerEffects.AddJumpForce(currentItem.jumpForceGiven, currentItem.jumpForceDuration);
            if(currentItem.climbSpeedGiven != 0) playerEffects.AddClimbSpeed(currentItem.climbSpeedGiven, currentItem.climbSpeedDuration);
        }
        else ExchangeManager.instance.TakeItem(currentItem);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void RecieveItem(Item item)
    {
        content.Add(item);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if (content.Count == 0) return;
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count - 1) contentCurrentIndex = 0;
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0) return;
        contentCurrentIndex--;
        if (contentCurrentIndex < 0) contentCurrentIndex = content.Count - 1;
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
        }
        else itemImageUI.sprite = emptyItemImage;

        for (int i = 0; i < inventoryStatusTexts.Length; i++)
        {
            int numberOfItem = 0;
            foreach (var item in content)
            {
                if (item.id == i + 1)
                {
                    numberOfItem++;
                }
            }
            inventoryStatusTexts[i].text = numberOfItem.ToString();
        }
    }
}