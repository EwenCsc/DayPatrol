using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
class ThiefCar : MonoBehaviour
{
    Checkpoint[] checkpoints = null;
    NavMeshAgent agent = null;
    int currentCheckpoint = -1;


    private void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>().OrderBy(c => c.id).ToArray();
        agent = GetComponent<NavMeshAgent>();
        currentCheckpoint = 0;
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (currentCheckpoint < checkpoints.Length)
        {
            if ((currentCheckpoint == -1 || agent.remainingDistance <= 0.1f))
            {
                currentCheckpoint++;
                if (currentCheckpoint < checkpoints.Length)
                {
                    agent.SetDestination(checkpoints[currentCheckpoint].transform.position);
                }
            }
            yield return null;
        }
        agent.SetDestination(transform.position);
        yield return null;
    }
}
