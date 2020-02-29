using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && !isOpen)
        {
            if (!isOpen)
            {
                // Open the chest
                OpenChest();
            }
            else
            {
                // Chest is already open
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        // Dialog window on
        dialogBox.SetActive(true);
        // Dialog text = context text
        dialogText.text = contents.itemDescription;
        // Add contents to the inventory

        playerInventory.currentItem = contents;
        // Raise the signal to the player to animate
        raiseItem.Raise();
        // Set the chest to opened
        isOpen = true;
        // Raise the context clue
        context.Raise();
    }

    public void ChestAlreadyOpen()
    {
        // Dialog off
        // Set the current item to empty
        // Raise the signal to the player to stop animating
    }
}
