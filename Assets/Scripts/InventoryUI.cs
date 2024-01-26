using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;

    public GameObject InventoryPanel;
    bool InventoryActive = false;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inventory = Inventory.Instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inventory.onSlotCountChange += SlotChange;
        InventoryPanel.SetActive(InventoryActive);
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryActive = !InventoryActive;
            InventoryPanel.SetActive(InventoryActive);
        }
    }

    public void AddSlot()
    {
        inventory.SlotCnt++;
    }
}
