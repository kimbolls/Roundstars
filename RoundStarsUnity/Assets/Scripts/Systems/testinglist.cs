using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class testinglist : MonoBehaviour
{
    //try making an array of array
    //
    public TextAsset textAssetData;
    public TextAsset jsonFile;
    public int col;
  [System.Serializable]
    public class Question
    {
        public string description;
        public string type;
        public string[] possibleAnswer = new string[3];
        public string correctAnswer;
    }
[System.Serializable]
    public class QuestionList
    {
        public Question[] questions;
    }
    public List<string> uniquetype;
    public QuestionList myQuestionList = new QuestionList();
    
    
    // Start is called before the first frame update
    void Start()
    {
        jsonFile = Resources.Load<TextAsset>("listofquestions(json)");
        textAssetData = Resources.Load<TextAsset>("listofquestions(csv)");
       if(jsonFile != null)
       {
        ReadCSV2();
       }
       if(textAssetData != null)
       {
        ReadCSV1();
       }

       countUnique();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadCSV1()
    {

        string[] data = textAssetData.text.Split(new string[] {",","\n"}, StringSplitOptions.None);

        int tableSize = data.Length / col-1;
        myQuestionList.questions = new Question[tableSize];

        for(int i = 0; i <tableSize; i++)
        {
            myQuestionList.questions[i] = new Question();
            // myQuestionList.questions[i].description = data[col* (i+1) + 1];
            // myQuestionList.questions[i].possibleAnswer[0] = data[col* (i+1) + 2];
            // myQuestionList.questions[i].possibleAnswer[1] = data[col* (i+1) + 3];
            // myQuestionList.questions[i].possibleAnswer[2] = data[col* (i+1) + 4];
            // myQuestionList.questions[i].correctAnswer = data[col* (i+1) + 5];
            myQuestionList.questions[i].type = data[col* (i+1)];
            myQuestionList.questions[i].description = data[col* (i+1) + 1];
            myQuestionList.questions[i].possibleAnswer[0] = data[col* (i+1) + 2];
            myQuestionList.questions[i].possibleAnswer[1] = data[col* (i+1) + 3];
            myQuestionList.questions[i].possibleAnswer[2] = data[col* (i+1) + 4];
            myQuestionList.questions[i].correctAnswer = data[col* (i+1) + 5];
        }
    }

    void ReadCSV2()
    {

        QuestionList employeesInJson = JsonUtility.FromJson<QuestionList>(jsonFile.text);
        // Debug.Log(jsonFile.text);
        // Debug.Log(employeesInJson);
        foreach (Question a in employeesInJson.questions)
        {
            // Debug.Log("Found employee: " + a.type + " " + a.description + a.possibleAnswer[2]);
        }
    }

    void countUnique()
    {
        int totalquestions = myQuestionList.questions.Length;
        uniquetype = new List<string>();
        for(int i = 0; i < totalquestions; i++)
        {
            if(!uniquetype.Contains(myQuestionList.questions[i].type))
            {
                uniquetype.Add(myQuestionList.questions[i].type);
            }
        }

        for(int i = 0; i <uniquetype.Count;i++)
        {
            Debug.Log(uniquetype[i]);
        }
    }
}
