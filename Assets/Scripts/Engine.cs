﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Engine : MonoBehaviour {

    public GameObject statesPrefab;
    public GameObject[] states;

    //on starting the game
    void Start() {
        states = GameObject.FindGameObjectsWithTag("Province");
        assignPlayers();    
    }
    void assignPlayers()
    {
        for (int i=0; i<states.Length; i++)
        {
            behaviour b = states[i].GetComponent<behaviour>();
            int r = Random.Range(0, 5);
            b.owner = r;
            b.updateColourOfProvinceRing(r);
        }
    }

    public List<GameObject> stateOf (int i)
    {
        List<GameObject> statesOfSpecified = new List<GameObject>();
        foreach (GameObject state in states)
        {
            behaviour stateCode = state.GetComponent<behaviour>();
            if (stateCode.owner == i)
            {
                statesOfSpecified.Add(state);
            }
        }
        return statesOfSpecified;
    }

    // has the game been won? returns true if yes, false if no.
    public bool isWin() {
        behaviour temp1 = states[0].GetComponent<behaviour>();
        for (int i = 1; i < states.Length - 1; i++){
            behaviour temp2 = states[i].GetComponent<behaviour>();
            if (temp1.owner != temp2.owner){
                return false;
            }
        }
        return true;
    }

}
