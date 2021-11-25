using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


class people
{
    public string name;
    public int age;

    // constructor
    public people(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}


public class SLManager : MonoBehaviour
{
    people p1 = new people("suyoung", 15);
    
    private void start()
    {
        string jdata = JsonConvert.SerializeObject(p1);
        print(jdata);
    }
}
