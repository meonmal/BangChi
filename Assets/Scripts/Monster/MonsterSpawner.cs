using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    //public GameObject monster;
    //public static MonsterSpawner  Instance;

    //public Queue<GameObject> m_queue = new Queue<GameObject>();

    //public float posX = 30.0f;
    //public float posY = -4.0f;

    //public Vector3 RandomVector;


    //public void Start()
    //{
    //    Instance = this;

    //    for (int i = 0; i < 10; i++)
    //    {
    //        GameObject t_object = Instantiate(monster, this.gameObject.transform);
    //        m_queue.Enqueue(t_object);
    //        t_object.SetActive(false);
    //    }

    //    StartCoroutine(MonsterSpawn());
    //}

    //public void InsertQueue(GameObject p_object)
    //{
    //    m_queue.Enqueue(p_object);
    //    p_object.SetActive(false);
    //}

    //public GameObject GetQueue()
    //{
    //    GameObject t_object = m_queue.Dequeue();
    //    t_object.SetActive(true);

    //    return t_object;
    //}

    //IEnumerator MonsterSpawn()
    //{
    //    while (true)
    //    {
    //        if(m_queue.Count != 0)
    //        {

    //            RandomVector = new Vector3(posX, 0.0f, posY);
    //            GameObject t_object = GetQueue();
    //            t_object.transform.position = gameObject.transform.position + RandomVector;
    //        }
    //        yield return new WaitForSeconds(0f);
    //    }
    //}


    //public Transform[] spawnPoints; // ���� ��ġ �迭
    //public GameObject[] monsterPrefabs; // ���� ������ �迭

    //public float spawnInterval = 3f; // ���� ���� ����
    //public float initialSpawnDelay = 2f; // �ʱ� ���� ���� �ð�

    //private List<GameObject> monsterPool; // ���� ������Ʈ Ǯ
    //private List<int> availableSpawnPoints; // ���� ������ ��ġ �ε��� ����Ʈ

    //private void Start()
    //{
    //    // ���� ������Ʈ Ǯ �ʱ�ȭ
    //    monsterPool = new List<GameObject>();

    //    // ���͸� �ʱ⿡ ���� ����
    //    SpawnAllMonsters();
    //    // ���� ������ ��ġ �ε��� ����Ʈ �ʱ�ȭ
    //    availableSpawnPoints = new List<int>();
    //    for (int i = 0; i < spawnPoints.Length; i++)
    //    {
    //        availableSpawnPoints.Add(i);
    //    }

    //    // �ʱ� ���� ���� �ð� �� ���� ���� ����
    //    Invoke("StartSpawning", initialSpawnDelay);
    //}

    //private void StartSpawning()
    //{
    //    StartCoroutine(SpawnMonsters());
    //}
    //private void SpawnAllMonsters()
    //{
    //    foreach (Transform spawnPoint in spawnPoints)
    //    {
    //        // ���͸� ������Ʈ Ǯ���� �������ų� ����
    //        GameObject monster = GetOrCreateMonsterFromPool();

    //        // ���͸� ���� ��ġ�� ����
    //        monster.transform.position = spawnPoint.position;
    //        monster.SetActive(true);
    //    }
    //}
    //private IEnumerator SpawnMonsters()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(spawnInterval);

    //        // ���� ������ ��ġ�� �ִ��� Ȯ��
    //        if (availableSpawnPoints.Count == 0)
    //            continue;

    //        // ���� ��ġ �ε����� �����ϰ� ����
    //        int spawnIndex = Random.Range(0, availableSpawnPoints.Count);
    //        int spawnPointIndex = availableSpawnPoints[spawnIndex];

    //        // �ش� ���� ��ġ�� ���Ͱ� �̹� �����Ǿ� �ִ��� Ȯ��
    //        if (IsMonsterSpawnedAtPoint(spawnPointIndex))
    //            continue;

    //        // ���͸� ������Ʈ Ǯ���� �������ų� ����
    //        GameObject monster = GetOrCreateMonsterFromPool();

    //        // ���͸� ���õ� ���� ��ġ�� ����
    //        monster.transform.position = spawnPoints[spawnPointIndex].position;
    //        monster.SetActive(true);

    //        // ������ ��ġ �ε����� ���� ������ ��ġ �ε��� ����Ʈ���� ����
    //        availableSpawnPoints.RemoveAt(spawnIndex);
    //    }
    //}
    //private bool IsMonsterSpawnedAtPoint(int spawnPointIndex)
    //{
    //    // �ش� ���� ��ġ�� ���Ͱ� �ִ��� Ȯ���ϴ� ������ ����
    //    // �̹� ���Ͱ� �ִٸ� false�� ��ȯ�ϰ�, ���ٸ� true�� ��ȯ�Ͽ� ������ ����

    //    bool hasMonster = false;

    //    // �ش� ���� ��ġ�� ���Ͱ� �ִ��� �˻�
    //    // ���ÿ����� monsterPool ����Ʈ�� ����Ͽ� �ش� ��ġ�� ���� ������ �Ǵ�
    //    GameObject monster = monsterPool.Find(m => m != null && m.activeSelf && m.transform.position == spawnPoints[spawnPointIndex].position);
    //    if (monster == null)
    //    {
    //        hasMonster = true;
    //    }

    //    return hasMonster;
    //}
    //// ���͸� ������Ʈ Ǯ���� �������ų� ����
    //private GameObject GetOrCreateMonsterFromPool()
    //{
    //    GameObject monster = monsterPool.Find(m => !m.activeSelf);
    //    if (monster == null)
    //    {
    //        // ��� ���� �������� ��ȸ�ϸ� ������Ʈ Ǯ�� �߰�
    //        foreach (GameObject monsterPrefab in monsterPrefabs)
    //        {
    //            GameObject newMonster = Instantiate(monsterPrefab);
    //            newMonster.SetActive(false);
    //            monsterPool.Add(newMonster);
    //        }
    //        // �ٽ� ���͸� ������
    //        monster = monsterPool.Find(m => !m.activeSelf);
    //    }
    //    return monster;
    //}
}
