using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("List of target game objects")] public List<GameObject> targets;

    [SerializeField, Tooltip("Spawn Rate of the targets")] private float _spawnRate = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}