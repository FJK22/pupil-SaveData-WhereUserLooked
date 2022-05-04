using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PupilLabs;
using System;
using UnityEngine.UI;
using System.IO;

public class OnCollisionEye : TimeSync
{
    public GazeVisualizer gazeVisualizer;
    public GazeData gazeData;
    public Transform gazeOriginCamera;
    public GazeController gazeController;

    private void OnEnable()
    {
        if (gazeController)
        {
            gazeController.OnReceive3dGaze += OnReceive;
        }
    }
    private void OnReceive(GazeData obj)
    {
        gazeData = obj;
    }
    // Update is called once per frame
    void Update()
    {
        if(gazeData != null)
        {
            Vector3 origin = gazeOriginCamera.position;
            Vector3 direction = gazeOriginCamera.TransformDirection(gazeData.GazeDirection);

            if(Physics.SphereCast(origin, 0.1f, direction, out RaycastHit hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Instructions")
                {
                    LookedAtInstructions(); //Calls the function to save the data into csv file
                }
                if (hit.collider.tag == "AllExperiments")
                {
                    LookedAtExperiments(); //Calls another function to save the data into another csv file
                }
            }

            //This script saves data into two csv files but if you are interested to save it to only one file you can make this check:

            /*
            if(hit.collider.tag == "Instructions")
            {
                LookedAt("Instructions"); //We will then need to create a function called LookedAt that takes a string. See below the function LookedAt(); You can remove the comments if you are interested to use that function.
            }
            else if (hit.collider.tag == "AllExperiments")
            {
                LookedAt("Experiments");
            }
            else 
            {
                LookedAt("Else");
            }

            */
        }
    }

    /*
    void LookedAt(string LookedWhere)
    {
        string date = System.DateTime.Now.ToString("yyyy_MM_dd");
        string path = $"{Application.dataPath}/Data/" + "LookedAt.csv";

        double pupilTime = GetPupilTimestamp();
        double unityTime = Time.realtimeSinceStartup;

        if (!File.Exists(path))
        {
            string header = "Pupil Timestamp,Unity Time,Looked At" + Environment.NewLine;

            File.AppendAllText(path, header);
        }

        string values = $"{pupilTime}, {unityTime}, {LookedWhere}" + Environment.NewLine;

        File.AppendAllText(path, values);
    }
    */

    void LookedAtInstructions()
    {
        string date = System.DateTime.Now.ToString("yyyy_MM_dd");

        // Your path to save the data. Application.dataPath means that we will save the data under the Assets folder of your project. 
        //I have also included a folder under the Assets folder and I am saving the data in LookedAtInstructions.csv
        string path = $"{Application.dataPath}/Data/" + "LookedAtInstructions.csv"; 

        double pupilTime = GetPupilTimestamp();
        double unityTime = Time.realtimeSinceStartup;

        if (!File.Exists(path))
        {
            string header = "Pupil Timestamp,Unity Time,Looked At" + Environment.NewLine;

            File.AppendAllText(path, header);
        }

        string values = $"{pupilTime}, {unityTime}, {"Instructions"}" + Environment.NewLine;

        File.AppendAllText(path, values);
    }
    void LookedAtExperiments()
    {
        string date = System.DateTime.Now.ToString("yyyy_MM_dd");

        // Your path to save the data. Application.dataPath means that we will save the data under the Assets folder of your project. 
        //I have also included a folder under the Assets folder and I am saving the data in LookedAtInstructions.csv
        string path = $"{Application.dataPath}/Data/" + "LookedAtExperimentsModels.csv";

        double pupilTime = GetPupilTimestamp();
        double unityTime = Time.realtimeSinceStartup;

        if (!File.Exists(path))
        {
            string header = "Pupil Timestamp,Unity Time,Looked At" + Environment.NewLine;

            File.AppendAllText(path, header);
        }

        string values = $"{pupilTime}, {unityTime}, {"Experiments Models"}" + Environment.NewLine;

        File.AppendAllText(path, values);
    }

}
