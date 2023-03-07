using System;
using UnityEngine;
using UnityEngine.AI;


public class Ai_Controller : MonoBehaviour
{

    public Transform goal1;
    public Transform goal2;
    public Transform goal3;
    public Transform goal4;

    private Transform player;
    private PlayerScript playerScript;

    Vector3 goal1V;
    Vector3 goal2V;
    Vector3 goal3V;
    Vector3 goal4V;

    public NavMeshAgent agent;

    [Header("AI Attributes")]
    public float aiMoveTime;
    public float aiTimer;
    public float aiListeningTime;
    public float aiListeningTimer;

    public int goalInt;

    bool hunt;

    private float movementScore;


    void Start()
    {

        goal1V = goal1.position;
        goal2V = goal2.position;
        goal3V = goal3.position;
        goal4V = goal4.position;

        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        player = GameObject.Find("Player").GetComponent<Transform>();

        goalInt = UnityEngine.Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update()
    {

        playerScript.movementScore = Mathf.Round(playerScript.movementScore);
        movementScore = Mathf.Clamp(playerScript.movementScore, 0, 200);

        aiTimer -= Time.deltaTime;
        aiListeningTimer -= Time.deltaTime;

        if (movementScore >= 50)
        {
            hunt = true;
        }
        else
        {
            hunt = false;
        }


        if (aiTimer <= 0 && !hunt)
        {
            if (goalInt == 0)
            {
                agent.SetDestination(goal1V);
                aiTimer = aiMoveTime;
                goalInt = UnityEngine.Random.Range(0, 3);
            }
            else if (goalInt == 1)
            {
                agent.SetDestination(goal2V);
                aiTimer = aiMoveTime;
                goalInt = UnityEngine.Random.Range(0, 3);
            }
            else if (goalInt == 2)
            {
                agent.SetDestination(goal3V);
                aiTimer = aiMoveTime;
                goalInt = UnityEngine.Random.Range(0, 3);
            }
            else if (goalInt == 3)
            {
                agent.SetDestination(goal4V);
                aiTimer = aiMoveTime;
                goalInt = UnityEngine.Random.Range(0, 3);
            }

        }

        if (hunt)
        {
            agent.speed = 10;
            Hunt();
        }
        else
        {
            agent.speed = 4;
        }

    }



    public void Hunt()
    {

        if(aiListeningTimer < 0)
        {
            agent.SetDestination(player.position);
            aiListeningTimer = aiListeningTime;
        }
        

    }
}
