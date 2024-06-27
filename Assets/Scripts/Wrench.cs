using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour
{
    //Spawn in wrench 
    public static GameObject SpawnWrench(Team team,Vector2 startPoint, Vector2 endPoint)
    {
        GameObject prefab = (GameObject)Resources.Load("Prefabs/Wrench");

        GameObject newInsance = Instantiate(prefab);

        Wrench wrench = newInsance.GetComponent<Wrench>();
        Debug.Log(wrench);
        wrench.team = team;

        wrench.transform.position = startPoint;
        wrench.endPoint = endPoint;

        wrench.direction = (endPoint - startPoint).normalized;

        return newInsance;
    }

    private Team team;

    private Vector2 direction;
    private Vector2 endPoint;

    private Rigidbody2D rigidbodyComp;

    public void Awake()
    {
        rigidbodyComp = GetComponent<Rigidbody2D>();

        rigidbodyComp.velocity = direction;
    }
}

