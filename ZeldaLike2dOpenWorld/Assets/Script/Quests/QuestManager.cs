using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public List<Quests> quests = new List<Quests>();
    public GameObject questPanelTemplate;
    public Transform questPanelParent;
    public Text questInfoNameText;
    public Text questInfoLocationText;
    public Text questInfoTypeText;
    public Text questInfoDescriptionText;

    public void AddQuest(Quests quest)
    {
        if (!quests.Contains(quest))
        {
            quests.Add(quest);
            UpdateQuestUI(quest);
        }
    }

    public void RemoveQuest(Quests quest)
    {
        quests.Remove(quest);
    }

    public void UpdateQuestUI(Quests quest)
    {
        GameObject newQuestPanel = Instantiate(questPanelTemplate, questPanelParent);
        newQuestPanel.transform.Find("QuestName").GetComponent<Text>().text = quest.name;
        newQuestPanel.transform.Find("QuestLocation").GetComponent<Text>().text = quest.location;

        if (quest.isPrincipal)
        {
            newQuestPanel.transform.Find("QuestType").GetComponent<Text>().text = "Principal";
            newQuestPanel.transform.Find("QuestType").GetComponent<Text>().color = Color.red;
        }
        else
        {
            newQuestPanel.transform.Find("QuestType").GetComponent<Text>().text = "Annexe";
            newQuestPanel.transform.Find("QuestType").GetComponent<Text>().color = Color.blue;
        }

        // Récupération du bouton et assignation correcte de la quête
        Button questButton = newQuestPanel.GetComponent<Button>();
        Quests questCopy = quest; // Fixe la quête pour éviter le problème de référence
        if (questButton != null)
        {
            questButton.onClick.AddListener(() => OpenQuestPanel(questCopy));
        }

        // Ajustement de la position
        int questCount = questPanelParent.childCount;
        if (questCount > 1) 
        {
            newQuestPanel.transform.localPosition = new Vector3(491, 325 - (questCount * 225), 0);
        }

    }

    public void OpenQuestPanel(Quests quest)
    {
        Debug.Log("Ouverture du panneau pour la quête : " + quest.name); // Debug pour vérifier

        questInfoNameText.text = quest.name;
        questInfoLocationText.text = quest.location;

        if (quest.isPrincipal)
        {
            questInfoTypeText.text = "Principal";
            questInfoTypeText.color = Color.red;
        }
        else
        {
            questInfoTypeText.text = "Annexe";
            questInfoTypeText.color = Color.blue;
        }

        questInfoDescriptionText.text = quest.description;
    }

}