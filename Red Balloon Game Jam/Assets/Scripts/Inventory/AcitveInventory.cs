using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcitveInventory : MonoBehaviour
{
    private int activeSlotIndex = 0;

    private PlayerControls playerControls;

    private void Awake() {
        playerControls = new PlayerControls();
    }

    private void Start() {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void ToggleActiveSlot(int num) {
        ToggleActiveHighlight(num - 1);
    }

    private void ToggleActiveHighlight(int index) {
        activeSlotIndex = index;

        foreach (Transform inventorySlot in this.transform) {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        this.transform.GetChild(index).GetChild(0).gameObject.SetActive(true);
    }
}
