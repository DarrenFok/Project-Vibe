using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fuel_Interaction : MonoBehaviour
{
    public Transform Player;
    public Transform FuelCan;
    public float InteractionDistance = 1;
    //public Dialogue dialogue;
    public PlayerMovement Player_Movement;
    public GameObject FuelCanObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.position, FuelCan.position) < InteractionDistance)
        {
            Player_Movement.RestoreFuel();
            //delete the fuel can object once consumed
            Destroy(FuelCanObject);
            Debug.Log("Fuel can consumed!");
        }
    }
}
