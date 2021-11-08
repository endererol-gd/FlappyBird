using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{

    private GameObject[] backgrounds;
    private GameObject[] grounds;

    private float LastBGX;
    private float LastGroundX;
    
    
    void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag ("Background");
        grounds = GameObject.FindGameObjectsWithTag ("Ground");

        LastBGX = backgrounds [0].transform.position.x;
        LastGroundX = grounds [0].transform.position.x;

        for(int i = 1; i < backgrounds.Length; i++) {
            if(LastBGX < backgrounds[i].transform.position.x) {
                LastBGX = backgrounds[i].transform.position.x;
            }
        }

        for(int i = 1; i < grounds.Length; i++) {
            if(LastGroundX < grounds[i].transform.position.x) {
                LastGroundX = grounds[i].transform.position.x;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == "Background") {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = LastBGX + width;

            target.transform.position = temp;

            LastBGX = temp.x;

        } else if(target.tag == "Ground") {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = LastGroundX + width;

            target.transform.position = temp;

            LastGroundX = temp.x;
        }
        
    }

}
