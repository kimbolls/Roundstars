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
    // [Serializable]
    // public class Question
    // {
    //     public string description;
    //     public string choice1,choice2,choice3;
    //     public string trueanswer;
    // }
    // [Serializable]
    // public class QuestionList
    // {
    //     public Question[] question;
    // }
  [System.Serializable]
    public class Question
    {
        public string name;
        public string type;
        public string[] possibleAnswer;
        public string correctAnswer;
    }
[System.Serializable]
    public class QuestionList
    {
        public Question[] questions;
    }
    // int 5 = 5;
    public int col = 5;
    // public QuestionList myQuestionList = new QuestionList();
    
    // Start is called before the first frame update
    void Start()
    {
       ReadCSV2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void ReadCSV1()
    // {

    //     string[] data = textAssetData.text.Split(new string[] {",","\n"}, StringSplitOptions.None);

    //     int tableSize = data.Length / 5-1;
    //     myQuestionList.question = new Question[tableSize];

    //     for(int i = 0; i <tableSize; i++)
    //     {
    //         myQuestionList.question[i] = new Question();
    //         myQuestionList.question[i].description = data[5* (i+1)];
    //         myQuestionList.question[i].choice1 = data[5* (i+1) + 1];
    //         myQuestionList.question[i].choice2 = data[5* (i+1) + 2];
    //         myQuestionList.question[i].choice3 = data[5* (i+1) + 3];
    //         myQuestionList.question[i].trueanswer = data[5* (i+1) + 4];
    //     }
    // }

    void ReadCSV2()
    {
        QuestionList employeesInJson = JsonUtility.FromJson<QuestionList>(jsonFile.text);
        // Debug.Log(jsonFile.text);
        Debug.Log(employeesInJson);
        foreach (Question a in employeesInJson.questions)
        {
            Debug.Log("Found employee: " + a.type + " " + a.name + a.possibleAnswer[2]);
        }
    }
}
