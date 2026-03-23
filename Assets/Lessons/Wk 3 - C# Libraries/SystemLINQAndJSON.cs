using UnityEngine;
using System.Linq; // for LINQ methods like Where, Select, etc.
using TMPro;
using System.Collections.Generic;
using System.IO; // for JSON


public class SystemLINQAndJSON : MonoBehaviour
{
    [SerializeField] TMP_Text text1, text2, text3;

    [SerializeField] private int[] initialNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    [SerializeField] private string[] initialWords = {};

    void Start()
    {
        ClearText();

        for (int i = 0; i < initialNumbers.Length; i++)
        {
            text1.text = text1.text + " " + initialNumbers[i];
        }

        //Able to use SQL like syntax to query collections of data (arrays, lists, etc.)
        IEnumerable<int> parsedNumbers =
            from number in initialNumbers
            where number % 2 == 0 // filter for even numbers
            select number;
        for (int i = 0; i < parsedNumbers.Count(); i++)
        {
            text2.text = text2.text + " " + parsedNumbers.ElementAt(i);
        }

        
        List<string> parsedWords =
            (from word in initialWords
            where word.Length < 7 
            orderby word descending
            select word).ToList();
        foreach (var word in parsedWords) 
        { text3.text += " " + word; }


        // Wrap for JSON
        WordList wordList = new WordList
        {
            words = parsedWords
        };

        string json = JsonUtility.ToJson(wordList, true);

        // Correct file path and called it words.json
        string path = Path.Combine(Application.persistentDataPath, "words.json");

        File.WriteAllText(path, json);

        Debug.Log("Saved to: " + path);
    }

    private void ClearText()
    {
        text1.text = "";
        text2.text = "";
        text3.text = "";
    }
}
