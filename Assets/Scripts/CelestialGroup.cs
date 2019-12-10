using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

// Struct for data members based on the structure of the passed in JSON file.
// If any names of keys in passed JSON file change, update them here.
public struct BodyData
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
    public List<GameObject> Bodies; // Array of objs (CelestialBody type)
    public List<double> BodyTrails; // Storing color of CelestialBody trail
    public const float WorldScale = (float) 1 / 1000000; // Fractional scale on which to create objects in world

    // Testing variable to demonstrate a sped up representation of the data
    // Should otherwise stay at 1 for normal usage/non-demonstrative purposes
    public const float SpeedUp = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Set scale for world and update existing objects in world accordingly
        GameObject earth = GameObject.Find("Earth");
        Vector3 earthScale = earth.transform.localScale;
        earth.transform.localScale = new Vector3(
            earthScale.x * WorldScale,
            earthScale.y * WorldScale,
            earthScale.z * WorldScale);

        GameObject template = GameObject.Find("TemplateCB");
        Vector3 templateScale = template.transform.localScale;
        template.transform.localScale = new Vector3(
            templateScale.x * WorldScale,
            templateScale.y * WorldScale,
            templateScale.z * WorldScale);

        // Call a function to take in and create objects from JSON data in
        // "CleanedData.json" -- using Json.NET do do this
        // NOTE: Each file pertains to a different satellite, so we might need to
        //   do something like "for each file in this directory, clean it and make
        //   an object for it"
        string DataFile = Application.dataPath + "/Scripts/CleanedData.json";
        List<BodyData> tempDataList = ConvertData(DataFile);

        // Instantiate all of the necessary CelestialBody objects into the scene
        // and store them in public array above
        CreateBodies(tempDataList);


        // Destroy template CelestialBody in space once done using it to create Bodies
        // Should be done once all files are read & all bodies are created
        Destroy(GameObject.Find("TemplateCB"));
    }

    // Update is called once per frame
    void Update()
    {
        // Update positional data for each object in Bodies
        // NOTE: this updates positions on each frame, so much so that velocity at this
        //   point doesn't really matter as a metric (there are also issues with scale)
        // Scale and velocity need to be fixed in a way that will account for both (maybe
        //   seeing if at some point curr.transform.position == nextPos and then updating
        //   stuff accordingly. Anywho, stuff for a later date.
        // All of this might also be able to go into CelestialBody.Update(), but we'll see.

        for (int i = 0; i < Bodies.Count; i++)
        {
            // Get current data for object
            GameObject currObj = Bodies[i];
            CelestialBody curr = currObj.GetComponent<CelestialBody>();
            Vector3 currPos = curr.Position[curr.Cycle];
            Vector3 currVel = curr.Velocity[curr.Cycle];

            //test
            Debug.Log("Cycle " + curr.Cycle + ": Pos: " + currPos.ToString() + ", Vel: " + currVel.ToString());

            // Prevent range errors with what range we have
            int nextCycle;
            if (curr.Cycle + 1 >= curr.Position.Count) {
                nextCycle = 0;
            } else {
                nextCycle = curr.Cycle + 1;
            }

            // Update data for object
            Vector3 nextPos = curr.Position[nextCycle];
            Vector3 nextVel = curr.Velocity[nextCycle];

            currObj.transform.position = nextPos;
            currObj.GetComponent<Rigidbody>().velocity = nextVel;
            curr.Cycle = nextCycle;
            

        }
    }

    /* ConvertData() converts a given json file (by filename) and
     * exports the contents into structs for info to add to Bodies later on.
     * @in: string filename (of json file)
     * @out: List<BodyData> (of structs with data about each body for creating CB objs)
     */
    public List<BodyData> ConvertData(string filename)
    {
        // Deserialize JSON into temporary List of structs
        string jsonText = File.ReadAllText(filename);
        List<BodyData> tempStructs = new List<BodyData>();
        tempStructs = JsonConvert.DeserializeObject<List<BodyData>>(jsonText);

        return tempStructs;

    }

    /* CreateBodies() instantiates many CelestialBody gameobjects from data given
     * by tempStructs.
     * @in: List<BodyData> tempStructs (data structs for each body for creating CB objs)
     * @out: void (changes member variable Bodies)
     */
    public void CreateBodies(List<BodyData> tempStructs)
    {
        // Find and create references to parent data/templates
        Transform group = GameObject.Find("CelestialGroup").transform;
        GameObject template = GameObject.Find("TemplateCB");
        
        // The operations below should be done for all files given to the system
        // i.e. for all n files pertaining to celestial bodies with orbital data
        // This also becomes a data/object member storage problem

        GameObject obj = Instantiate(template, new Vector3(), Quaternion.identity, group) as GameObject;
        obj.name = "CBody";

        for (int i = 0; i < tempStructs.Count; i++)
        {
            // Set up current BodyData object to instantiate CB object for
            BodyData curr = tempStructs[i];
            double[] posData = { curr.pfix_state_trans_position0,
                curr.pfix_state_trans_position1,
                curr.pfix_state_trans_position2 };
            double[] velData = { curr.pfix_state_trans_velocity0,
                curr.pfix_state_trans_velocity1,
                curr.pfix_state_trans_velocity2 };

            // Create vectors for starting position and velocity to pass to new object
            Vector3 currPos = new Vector3((float)posData[0] * WorldScale, 
                (float)posData[1] * WorldScale, 
                (float)posData[2] * WorldScale);
            Vector3 currVel = new Vector3((float)velData[0] * WorldScale * SpeedUp,
                (float)velData[1] * WorldScale * SpeedUp,
                (float)velData[2] * WorldScale * SpeedUp);

            obj.GetComponent<CelestialBody>().Position.Add(currPos);
            obj.GetComponent<CelestialBody>().Velocity.Add(currVel);
        }

        Bodies.Add(obj);
        obj = null;
    }
}
