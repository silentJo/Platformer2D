using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ExchangeManager : MonoBehaviour
{
    public static ExchangeManager instance;

    [SerializeField] private List<Exchange> exchanges = new List<Exchange>();
    
    [SerializeField] private Image NPCIcon;
    [SerializeField] private Image requestIcon;
    [SerializeField] private Image pannel;
    [SerializeField] private Text requestedNumber;

    [SerializeField] private Animator animator;

    public Exchange currentExchange;
    public int numberOfQuests = 0;
    public int numberOfValidatedQuests = 0;
    public bool isStageDone;

    AudioSource audioSource;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ExchangeManager dans la scène");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        numberOfQuests = (exchanges != null ) ? exchanges.Count : 0;
    }

    private void Update()
    {
        if (currentExchange.isQuestDone) currentExchange.requestIcon.sprite = currentExchange.questDoneIcon.sprite;
    }

    public void StartDialogue(Exchange exchange)
    {
        animator.SetBool("IsOpen", true);

        if(exchange!=null)
        {
            currentExchange = exchanges.Find(e => e.id == exchange.id);
            if (currentExchange == null) 
            { 
                exchanges.Add(exchange);
                numberOfQuests++;
            }
            currentExchange = exchanges.Find(e => e.id == exchange.id);

            NPCIcon.sprite = currentExchange.NPCIcon.sprite;
            requestedNumber.text = (currentExchange.isQuestDone) ? "" : currentExchange.requestedNumber;
            requestIcon.sprite = currentExchange.requestIcon.sprite;
            pannel.sprite = currentExchange.pannel.sprite;
            CheckStageDone();
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    public void TakeItem(Item item)
    {
        if (!currentExchange.isQuestDone)
        {
            if (item.id != currentExchange.requestedItem.id)
            {
                Inventory.instance.RecieveItem(item);
            }
            else
            {
                audioSource.Play();
                currentExchange.numberReceived++;
            }
            CheckQuestDone();
        }
        else
        {
            audioSource.Play();
            Inventory.instance.RecieveItem(item);
        }
    }

    public void CheckQuestDone()
    {
        if (currentExchange.numberReceived == int.Parse(currentExchange.requestedNumber))
        {
            currentExchange.isQuestDone = true;
            numberOfValidatedQuests++;
        }
    }

    public void CheckStageDone()
    {
        isStageDone = (numberOfValidatedQuests == numberOfQuests);
        if (isStageDone)
        { 
            currentExchange.questDoneIcon.sprite = currentExchange.stageDoneIcon.sprite;
            EcologyManager.s_Instance.SwitchWorld();
        }
    }
}
