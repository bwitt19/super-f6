using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public struct tempBody
{
    public int Column1;
    public double sys_exec_out_time;
    public double pfix_state_trans_position0;
    public double pfix_state_trans_position1;
    public double pfix_state_trans_position2;
    public double pfix_state_trans_velocity0;
    public double pfix_state_trans_velocity1;
    public double pfix_state_trans_velocity2;
}


public class CelestialGroup : MonoBehaviour
{
    // Member variables
    public List<CelestialBody> Bodies; // Array of CelestialBody objects
    public List<double> BodyTrails; // Storing color of CelestialBody trail
    
    // Start is called before the first frame update
    void Start()
    {
        // Call a function to take in and create objects from JSON data in
        //   CleanedData.json -- there should be C# libraries to do this w/ JSON
        ConvertData("Assets/Scripts/CleanedData.json");

        // Instantiate all of the necessary CelestialBody objects into the scene
        //   and store them in public array above
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* Function converts a given json file (by filename) and
     * exports the contents into a CelestialBody object to add to Bodies.
     * @in: string filename (of json file)
     * @out: void (CelestialBody objects are created and added to member List)
     */
    public void ConvertData(string filename)
    {
        // Deserialize JSON into temporary List of structs
        string jsonText = File.ReadAllText(filename);
        List<tempBody> tempStructs = new List<tempBody>();
        tempStructs = JsonConvert.DeserializeObject<List<tempBody>>(jsonText);

        // Add temporary CelestialBody objectst to Bodies 
        CelestialBody tempCB;
        for (int i = 0; i < tempStructs.Count; i++)
        {
            tempBody curr = tempStructs[i];
            tempCB = new CelestialBody
                (curr.Column1,
                curr.pfix_state_trans_position0,
                curr.pfix_state_trans_position1,
                curr.pfix_state_trans_position2,
                curr.pfix_state_trans_velocity0,
                curr.pfix_state_trans_velocity1,
                curr.pfix_state_trans_velocity2
                );
            Bodies.Add(tempCB);
        }

    }
}
