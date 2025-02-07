using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClickHandler : MonoBehaviour, IPointerClickHandler
{
    public Button button;
    public int buttonNb;
    public InventoryUI inventoryUI;
    public ItemEffect itemEffect;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    void OnLeftClick()
    {
        Debug.Log("Clic gauche sur le bouton !");
        inventoryUI.AddItemToFastSlot(buttonNb);
    }

    void OnRightClick()
    {
        Debug.Log("Clic droit sur le bouton !");
        itemEffect.UseItem(inventoryUI.itemInInventoryButtons[buttonNb]);
    }
}