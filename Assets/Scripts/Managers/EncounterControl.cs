using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class EncounterControl : MonoBehaviour
{
    //Temp variable that says whether the mouse controls hand traversal or not
    public bool mouseMode = false;

    //Create a single, static instance of this manager that will be referenced 
    public static EncounterControl Instance { get; private set; }

    //Variables dictated by the passed Encounter
    public Encounter currEncounter;
    public Enemy currEnemy;
    public Player currPlayer;

    public bool playerWonLast;

    //Card Prefab
    [SerializeField]
    private CardPrefab cardBlueprint;

    //Currently selected card
    public CardPrefab hoveredCard { get; set; }

    //All UI elements
    public GameObject playerSpritePlaceholder;
    public GameObject enemySpritePlaceholder;
    public GameObject playerHealthBarSprite;
    public GameObject enemyHealthBarSprite;

    public Slider playerHealthBar;
    public Slider enemyHealthBar;

    private SpriteRenderer discardSpriteRenderer;


    public List<GameObject> allObjects = new List<GameObject>();

    //Holds the index of the card that is being selected
    public int position;

    //List of all cards that in the player hand
    public List<CardPrefab> visibleHand;
    public List<AbstractCard> deck;

    //Relays if the enemy can currently play a card or perform an action
    public bool enemyTurn;

    //Relays if the player can currently draw a card
    public bool drawTurn;

    //Variable to hold if the next bullet negates enemy defends
    public bool takeAimActive;

    public bool combat;

    //If the instance is the first one, it becomes the Instance.
    //Otherwise is is destroyed
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            combat = false;
            playerWonLast = false;
        }
    }

    //Begin the passed Encounter instance
    public void startEncounter(Encounter encounter)
    {
        setUI(true);
        currEnemy = encounter.enemy;
        currPlayer = encounter.player;
        currEncounter = encounter;

        currPlayer.addBullets(encounter.weapon.bullets);
        WeaponMono.Instance.activateWeapon(encounter.weapon);

        EnemyStateMachine enemyStateMachine = enemySpritePlaceholder.GetComponent<EnemyStateMachine>();
        enemyStateMachine.encounterController = this;
        enemyStateMachine.enemy = currEnemy;

        position = -1;
        visibleHand = new List<CardPrefab>();

        enemyTurn = true;
        drawTurn = true;

        takeAimActive = false;

        reapplyHand();
    }

    //Destroy all card prefabs and created a new list of prefabs to visually represent the current hand
    public void reapplyHand()
    {
        foreach (CardPrefab card in visibleHand)
        {
            Destroy(card.gameObject);
        }
        visibleHand = new List<CardPrefab>();

        for (int i = 0; i < currEncounter.player.hand.Count; i++)
        {
            CardPrefab newCard = Instantiate(cardBlueprint, cardPosition(i), Quaternion.identity) as CardPrefab;
            newCard.setData(currPlayer.hand[i], i);
            visibleHand.Add(newCard);
        }
    }

    //Calculate the card prefab position depending on hand size
    public Vector2 cardPosition(int num)
    {
        if (currEncounter.player.hand.Count > 1)
        {
            return new Vector2((currPlayer.hand.Count * 1.45F) / (float)(currPlayer.hand.Count - 1) * (num - ((float)(currPlayer.hand.Count) / 3)) + num, -4);
        }
        else
        {
            return new Vector2(0, -4);
        }

    }

    //Check every update whether the player draws or plays a card
    void Update()
    {
        if (combat)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

            //Calculate the current health of the enemy and player
            playerHealthBar.value = (float)currPlayer.health / currPlayer.maxHealth;
            enemyHealthBar.value = (float)currEnemy.health / currEnemy.maxHealth;

            if (currPlayer.health == 0)
            {
                EncounterControl.Instance.playerWonLast = false;
                DisableOverworld.Instance.enableOverworld(true);
                endEncounter(currEnemy);
            }
            else if (currEnemy.health == 0)
            {
                EncounterControl.Instance.playerWonLast = true;
                DisableOverworld.Instance.enableOverworld(true);
                endEncounter(currPlayer);
            }

            //If the enemy has a turn, randomly pick an action and pause the enemy turn for the returned seconds
            if (enemyTurn)
            {
                StartCoroutine(wait(currEnemy.trySomething() + currEnemy.costAdjust, currEnemy));
            }

            if (drawTurn && currPlayer.hand.Count < currPlayer.maxHandSize)
            {
                currPlayer.Draw();
                StartCoroutine(wait(currEncounter.weapon.drawDelay, currPlayer));
                reapplyHand();
            }
            if (currEncounter != null)
            {
                //Exit the card selection if the player clicks S
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currPlayer.Shuffle();
                    SoundManager.playSound(SoundType.Reload);
                }
                //Exit the card selection if the player clicks S
                else if (Input.GetKeyDown(KeyCode.DownArrow) && !mouseMode)
                {
                    position = -1;
                    if (hoveredCard != null)
                    {
                        hoveredCard.deselected();
                        hoveredCard = null;
                    }
                }
                //Move the index of the selected card right when the playef clicks D
                else if (Input.GetKeyDown(KeyCode.RightArrow) && !mouseMode)
                {
                    if (position == -1 || position == currPlayer.hand.Count - 1)
                    {
                        position = 0;
                    }
                    else
                    {
                        position += 1;
                    }
                    //Move the index of the selected card left when the playef clicks A
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && !mouseMode)
                {
                    if (position == -1 || position == 0)
                    {
                        position = currPlayer.hand.Count - 1;
                    }
                    else
                    {
                        position -= 1;
                    }
                }

                //If a card is selected, the player has an action, and the user clicks the mouse  => Call the card's use() method and discard it
                else if (hoveredCard != null)
                {

                    //For any number key pressed (0-9), call the time slot with the associated index
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        playCardToSlot(0);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        playCardToSlot(1);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha3))
                    {
                        playCardToSlot(2);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha4))
                    {
                        playCardToSlot(3);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha5))
                    {
                        playCardToSlot(4);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha6))
                    {
                        playCardToSlot(5);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha7))
                    {
                        playCardToSlot(6);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha8))
                    {
                        playCardToSlot(7);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha9))
                    {
                        playCardToSlot(8);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha0))
                    {
                        playCardToSlot(9);
                    }

                }
            }

            //Visually show which card is selected and set hoveredCard to the currently selected card
            if (position < visibleHand.Count && position >= 0)
            {
                if (hoveredCard != null)
                {
                    hoveredCard.deselected();
                }
                hoveredCard = visibleHand[position];
                hoveredCard.selected();
            }
        }

    }

    //Turn on or off all UI elements
    private void setUI(bool state)
    {
        //deckPlaceholder.SetActive(state);
        //discardPilePlaceholder.SetActive(state);

        combat = state;
        foreach (GameObject item in allObjects)
        {
            item.SetActive(state);
        }
    }

    //Turn off player turn for the passed cost
    public IEnumerator wait(float sec, AbstractPlayer player)
    {
        if (player is Enemy)
        {
            EncounterControl.Instance.enemyTurn = false;
        }
        else
        {
            EncounterControl.Instance.drawTurn = false;
        }

        //While there is time left
        float duration = sec;
        while (duration > 0)
        {

            //Alter the time by the time since last frame
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                duration = 0;
            }

            yield return null;
        }
        if (player is Enemy)
        {
            EncounterControl.Instance.enemyTurn = true;
        }
        else
        {
            EncounterControl.Instance.drawTurn = true;
        }
    }

    //The encounter ends whenever player or enemy reach 0 health
    public void endEncounter(AbstractPlayer winner)
    {
        setUI(false);

        //Deactivate all visible cards
        GameObject[] visibleCards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject card in visibleCards)
        {
            Destroy(card);
        }

        //Deactivate all time slots
        GameObject[] visibleSlots = GameObject.FindGameObjectsWithTag("TimeSlot");
        foreach (GameObject slot in visibleSlots)
        {
            Destroy(slot);
        }

        //Deactivate all visible bullets
        GameObject[] allBullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in allBullets)
        {
            Destroy(bullet);
        }

        DefenseManager.Instance.makeInvisible(Type.Small);
    }

    //Play the current card to the time slot at the provided index
    public void playCardToSlot(int index)
    {

        //If the time slot does not exist or if it has a card already in it
        if (WeaponMono.Instance.allSlots[index] == null || WeaponMono.Instance.allSlots[index].occupied)
        {
            return;
        }

        //Start the specific time slot's timer with the card that is currently selected
        StartCoroutine(WeaponMono.Instance.allSlots[index].wait(hoveredCard.thisCard.COST, currPlayer, hoveredCard.thisCard));

        //Discard the card
        currPlayer.Discard(hoveredCard.thisCard);

        //Reapply the visuals for the player's hand
        position = (position == 0) ? position + 1 : position - 1;
        reapplyHand();
    }
}
