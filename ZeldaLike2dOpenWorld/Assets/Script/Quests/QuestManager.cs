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

        Text questTypeText = newQuestPanel.transform.Find("QuestType").GetComponent<Text>();
        if (quest.isPrincipal)
        {
            questTypeText.text = "Principal";
            questTypeText.color = Color.red;
        }
        else
        {
            questTypeText.text = "Annexe";
            questTypeText.color = Color.blue;
        }

        int questCount = questPanelParent.childCount;
        if (questCount > 1) 
        {
            newQuestPanel.transform.localPosition = new Vector3(491, 325 - (questCount * 225), 0);
        }
    }

    public void OpenQuestPanel(int questID)
    {
        Quests quest = quests.Find(q => q.id == questID);
        Debug.Log("Ouverture du panneau pour la quête : " + quest.name);

        questInfoNameText.text = quest.name;
        questInfoLocationText.text = quest.location;
        questInfoDescriptionText.text = quest.description;

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
    }
}