using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<Button> inventoryButtons = new List<Button>();
    public List<Button> fastSlot = new List<Button>();
    public List<Item> itemInFastSlot = new List<Item>() { null, null, null, null, null, null, null, null, null };
    public Inventory inventory;
    public int fastSlotIndex = 0;

    void Start()
    {
        LoadInventoryUI();
    }

    public void LoadInventoryUI()
    {
        int index = 0;
        foreach (var kvp in inventory.content)
        {
            if (kvp.Value > 0) // Check if the item count is greater than 0
            {
                if (index < inventoryButtons.Count)
                {
                    // Find the child object named "Image" and get its Image component
                    Transform imageTransform = inventoryButtons[index].transform.Find("Image");
                    if (imageTransform != null)
                    {
                        Image buttonImage = imageTransform.GetComponent<Image>();
                        if (buttonImage != null)
                        {
                            buttonImage.sprite = kvp.Key.image;
                        }
                    }

                    // Find the child object named "Text" and set its text to the item count
                    Transform textTransform = inventoryButtons[index].transform.Find("Text (Legacy)");
                    if (textTransform != null)
                    {
                        Text buttonText = textTransform.GetComponent<Text>();
                        if (buttonText != null)
                        {
                            buttonText.text = kvp.Value.ToString();
                        }
                    }

                    inventoryButtons[index].gameObject.SetActive(true);
                    index++;
                }
                else
                {
                    break;
                }
            }
        }

        // Disable the remaining buttons if there are more buttons than items in the inventory
        for (int i = index; i < inventoryButtons.Count; i++)
        {
            inventoryButtons[i].gameObject.SetActive(false);
        }

        // Set the opacity of all child images of fastSlot buttons to 0 at startup
        foreach (var button in fastSlot)
        {
            Transform imageTransform = button.transform.Find("Image");
            if (imageTransform != null)
            {
                Image buttonImage = imageTransform.GetComponent<Image>();
                if (buttonImage != null)
                {
                    Color color = buttonImage.color;
                    color.a = 0;
                    buttonImage.color = color;
                }
            }
        }
    }

    private Color originalColor;

    public void HighlightFastSlotButton(int index)
    {
        // Store the original color if not already stored
        if (fastSlot.Count > 0 && originalColor == default(Color))
        {
            Image buttonImage = fastSlot[0].GetComponent<Image>();
            if (buttonImage != null)
            {
                originalColor = buttonImage.color;
            }
        }

        // Reset all buttons to their original color
        foreach (var button in fastSlot)
        {
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = originalColor;
            }
        }

        // Highlight the selected button
        if (index >= 0 && index < fastSlot.Count)
        {
            Image buttonImage = fastSlot[index].GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = new Color(0,0,255); // RGB color (0, 94, 125)
            }
            fastSlotIndex = index;
        }
    }

    public void AddItemToFastSlot(int itemID)
    {
        if (itemID < 0 || itemID >= inventory.listOfItem.Count)
        {
            Debug.LogWarning("Index out of range");
            return;
        }

        Item itemToAdd = inventory.listOfItem[itemID];

        // Remove the item from any existing fast slot
        for (int i = 0; i < itemInFastSlot.Count; i++)
        {
            if (itemInFastSlot[i] == itemToAdd)
            {
                itemInFastSlot[i] = null;
                Transform existingImageTransform = fastSlot[i].transform.Find("Image");
                if (existingImageTransform != null)
                {
                    Image existingButtonImage = existingImageTransform.GetComponent<Image>();
                    if (existingButtonImage != null)
                    {
                        existingButtonImage.sprite = null;
                        Color color = existingButtonImage.color;
                        color.a = 0;
                        existingButtonImage.color = color;
                    }
                }

                // Clear the text for the existing fast slot
                Transform existingTextTransform = fastSlot[i].transform.Find("Text (Legacy)");
                if (existingTextTransform != null)
                {
                    Text existingButtonText = existingTextTransform.GetComponent<Text>();
                    if (existingButtonText != null)
                    {
                        existingButtonText.text = "";
                    }
                }
                break;
            }
        }

        // Add the item to the new fast slot
        itemInFastSlot[fastSlotIndex] = itemToAdd;

        // Find the child object named "Image" and get its Image component
        Transform imageTransform = fastSlot[fastSlotIndex].transform.Find("Image");
        if (imageTransform != null)
        {
            Image buttonImage = imageTransform.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = itemToAdd.image;
                Color color = buttonImage.color;
                color.a = 1;
                buttonImage.color = color;
            }
        }

        // Find the child object named "Text (Legacy)" and set its text to the item count
        Transform textTransform = fastSlot[fastSlotIndex].transform.Find("Text (Legacy)");
        if (textTransform != null)
        {
            Text buttonText = textTransform.GetComponent<Text>();
            if (buttonText != null)
            {
                buttonText.text = inventory.content[itemToAdd].ToString();
            }
        }
    }


}
