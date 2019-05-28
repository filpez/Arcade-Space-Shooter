using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoresTable : MonoBehaviour
{
    public Transform entriesContainer;
    public Transform entriesPrefab;

    List<Transform> entriesTransformList;
    List<HighscoresEntry> entriesList;

    static HighscoresEntry newEntry;

    public float templateHeight = 75;

    void Awake()
    {
        entriesList = Load().entriesList;
        if (entriesList == null)
             entriesList = new List<HighscoresEntry>();

        if (newEntry != null){
            int index = 0;
            while (index < entriesList.Count && entriesList[index].score > newEntry.score){
                index++;
            }
            entriesList.Insert(index, newEntry);
            entriesList = entriesList.GetRange(0, Mathf.Min(10, entriesList.Count));
        }
        else{
            Button keepScoreButton = transform.Find("Panel").Find("SaveButton").GetComponent<Button>();
            Text dontKeepScoreButtonText = transform.Find("Panel").Find("DontSaveButton").Find("Text").GetComponent<Text>();

            keepScoreButton.gameObject.SetActive(false);
            dontKeepScoreButtonText.text = "Main Menu";
        }

        entriesTransformList = new List<Transform>();
        foreach (HighscoresEntry entry in entriesList){
            CreateEntry(entry, entriesContainer, entriesTransformList);
        }
    }

    public static void OnEndEdit(string newName){
        newEntry.name = newName;
        Debug.Log(newEntry.name);
    }

    void CreateEntry(HighscoresEntry entry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entriesPrefab, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
            default: rankString = rank + "th"; break;
        }
        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        Image bg = entryTransform.GetComponent<Image>();
        Color color = bg.color;
        color.a = rank % 2 == 0 ? 0 : 0.2f;
        bg.color = color;

        entryTransform.Find("ScoreText").GetComponent<Text>().text = entry.score.ToString();


        if (entry == newEntry)
            entryTransform.Find("NameInput").gameObject.SetActive(true);

        entryTransform.Find("NameText").GetComponent<Text>().text = entry.name;

        transformList.Add(entryTransform);
    }


    public void KeepScore(){
        Save();
        newEntry = null;
        SceneManager.LoadScene(0);
    }

    public void DontKeepScore(){
        newEntry = null;
        SceneManager.LoadScene(0);
    }


    void Save(){
        string json = JsonUtility.ToJson(new Highscores() {entriesList = entriesList});
        PlayerPrefs.SetString("highscores", json);
        PlayerPrefs.Save();
    }

    Highscores Load(){
        string json = PlayerPrefs.GetString("highscores");
        return JsonUtility.FromJson<Highscores>( json );
    }
    
    public static void AddNewEntry(int score){
        newEntry = new HighscoresEntry(){ score = score};
    }
    
    class Highscores
    {
        public List<HighscoresEntry> entriesList;
    }

    [System.Serializable]
    class HighscoresEntry
    {
        public int score;
        public string name = "AAA";
    }



    


}



