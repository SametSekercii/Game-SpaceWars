using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1LaserPooler : MonoBehaviour
{
    public static Lv1LaserPooler Instance;
    public GameObject Lv1LaserPrefab;
    List<GameObject> Lv1LaserList=new List<GameObject> ();
    public int amountoflist;
    List<GameObject> Lv1LaserList2 = new List<GameObject>();

    void Start()
    {
        Instance = this;
        CreateLv1LaserPool();
        CreateLv1LaserPool2();
    }

    public void CreateLv1LaserPool()
    {

        for (int i = 0; i < amountoflist; i++)
        {
            var Laser1=Instantiate(Lv1LaserPrefab);
            Laser1.SetActive(false);
            Lv1LaserList.Add(Laser1);
        }
    }
    public void CreateLv1LaserPool2()
    {

        for (int i = 0; i < amountoflist; i++)
        {
            var Laser1 = Instantiate(Lv1LaserPrefab);
            Laser1.SetActive(false);
            Lv1LaserList2.Add(Laser1);
        }
    }

    public GameObject getLasersFromPool1()
    {
        for(int i = 0; i < amountoflist; i++)
        {
            if (!Lv1LaserList[i].activeSelf) 
                return Lv1LaserList[i];
        }
        return null;

    }
    public GameObject getLasersFromPool2()
    {
        for (int i = 0; i < amountoflist; i++)
        {
            if (!Lv1LaserList2[i].activeSelf)
                return Lv1LaserList2[i];
        }
        return null;

    }




}
