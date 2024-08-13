using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : RecyclObject
{
    public GameObject prefab;

    public int poolSize = 64;

    T[] pool;

    Queue<T> readyQueue;


    public virtual void Initialize()
    {
        if(pool == null)
        {
            pool = new T[poolSize];
            readyQueue = new Queue<T>(poolSize);

            GenerateObjects(0, poolSize, pool);
        }
        else
        {
            foreach(T obj in pool)
            {
                obj.gameObject.SetActive(false);
            }
        }
    }

    void GenerateObjects(int start, int end, T[] result)
    {
        for (int i = start; i < end; i++)
        {
            GameObject obj = Instantiate(prefab, transform);    // pool의 자식으로 오브젝트 생성
            obj.name = $"{prefab.name}_{i}";    // 이름 변경(숫자이용해서 구분하기)

            T comp = obj.GetComponent<T>();
            comp.onDisable += () =>         // 람다함수를 comp의 onDisable 델리게이트에 등록 = comp가 비활성화 되면 아래 코드가 실행된다.
            {
                readyQueue.Enqueue(comp);   // 레디큐에 컴포넌트 추가해 놓기
            };
            OnGenerateObject(comp);

            result[i] = comp;       // 배열에 만들어진 것을 모두 저장
            obj.SetActive(false);   // 비활성화 시키기
        }
    }

    /// <summary>
    /// 오브젝트 하나가 생성되었을 때 실행되는 함수(빈함수)
    /// </summary>
    /// <param name="comp">생성된 오브젝트의 컴포넌트</param>
    protected virtual void OnGenerateObject(T comp)
    {
    }

    //void DisableAction()
    //{
    //    readyQueue.Enqueue(comp); // 스코프가 맞지 않다
    //}

    /// <summary>
    /// 풀에서 비활성중인 오브젝트를 하나 리턴하는 함수
    /// </summary>
    /// <param name="position">배치될 위치(월드좌표)</param>
    /// <param name="eulerAngle">초기 회전</param>
    /// <returns>활성화된 오브젝트</returns>
    public T GetObject(Vector3? position = null, Vector3? eulerAngle = null)
    {
        if (readyQueue.Count > 0)
        {
            // 아직 비활성화 된 오브젝트가 남아있다.
            T comp = readyQueue.Dequeue();          // 큐에서 하나 꺼내고
            comp.gameObject.SetActive(true);        // 활성화 시키기
            comp.transform.position = position.GetValueOrDefault();                      // 위치와 회전 적용
            comp.transform.rotation = Quaternion.Euler(eulerAngle.GetValueOrDefault());
            return comp;    // 리턴
        }
        else
        {
            // 모든 오브젝트가 활성화되어 있다. => 남아있는 오브젝트가 없다.
            ExpandPool();                           // 풀을 두배로 늘리기
            return GetObject(position, eulerAngle); // 새롭게 꺼내기 요청
        }

    }

    /// <summary>
    /// 풀을 두배로 확장시키는 함수
    /// </summary>
    void ExpandPool()
    {
        // 최대한 실행되지 않아야 함. 개발 중 편의를 위한 함수
        Debug.LogWarning($"{gameObject.name} 풀 사이즈 증가. {poolSize} -> {poolSize * 2}");

        int newSize = poolSize * 2;         // 새 풀의 크기 설정
        T[] newPool = new T[newSize];       // 새 풀의 배열 만들기
        for (int i = 0; i < poolSize; i++)
        {
            newPool[i] = pool[i];           // 이전 풀의 내용을 새 풀에 저장
        }

        GenerateObjects(poolSize, newSize, newPool);    // 새 풀의 남은 부분에 오브젝트 생성해서 추가

        pool = newPool;     // 새 풀 크기 저장
        poolSize = newSize; // 새 풀을 정식 풀로 지정
    }



}
