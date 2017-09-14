using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    IOManager: Writes or reads files from the local files. This is only being used when the games closes so all 
    the scores don't get written away.
*/

public class IOManager : MonoBehaviour
{
    private System.IO.FileStream _ScoreFile;


    //Make sure that this object can always be called.
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    //Creates a file at a given location with a given name.
    public void CreateFile(string filePath, string fileName)
    {
        _ScoreFile = System.IO.File.Create(@Application.dataPath + filePath + fileName + ".RPL");
    }

    
    //Deletes a file at a given location with a given name.
    public void DeleteFile()
    {

    }


    //Reads a file's content and returns that.
    public string ReadFile(string filePath, string fileName, int line = 0, bool readAll = false)
    {
        using (System.IO.StreamReader reader = new System.IO.StreamReader(@Application.dataPath + filePath + fileName + ".RPL"))
        {
            if(readAll)
            {

            }
            reader.Close();
        };
        return "";
    }


    //Writes content away in a file, returns true with success returns false when something went wrong.
    public bool AppendFile(string filePath, string fileName, string content)
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@Application.dataPath + filePath + fileName + ".RPL"))
        {
            writer.WriteLine(content);
            writer.Close();
        };
        return false;
    }
}
