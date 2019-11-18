using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;



public class Networking : MonoBehaviour
{
    SimpleCharacterControl character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<SimpleCharacterControl>();
        string path = "Assets/Resources/test.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine("Done");
        writer.Close();
    }

    public static Texture2D LoadJPG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

    // Update is called once per frame
    void Update()
    {
        string path = "Assets/Resources/test.txt";
        StreamReader reader = new StreamReader(path);
        string info = reader.ReadToEnd();
        reader.Close();

        if (info.StartsWith("Wave"))
        {
            character.Wave();
            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine("Done");
            writer.Close();
        }
        if (info.StartsWith("Show Image"))
        {
            byte[] bytes = File.ReadAllBytes(("C:\\Users\\sh479140\\LabAgent_Mixamo\\Assets\\Resources\\Images\\image.jpg"));

            GameObject rawImage = GameObject.Find("ProfilePicture");

            Texture2D thisTexture = new Texture2D(100, 100);
            thisTexture.LoadImage(bytes);
            thisTexture.name = "image.jpg";
            rawImage.GetComponent<RawImage>().texture = thisTexture;

            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine("Done");
            writer.Close();
        }
        if (info.StartsWith("Look Toward"))
        {
            info = info.Substring(12);
            string[] str_values = info.Split(',');
            int x = Int32.Parse(str_values[0].Trim());
            int y = Int32.Parse(str_values[1].Trim());

            character.LookToward(x, y);
            //480 x 640

            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine("Done");
            writer.Close();
        }
    }
}
