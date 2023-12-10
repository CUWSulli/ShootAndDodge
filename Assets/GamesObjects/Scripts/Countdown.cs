using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    //Manages the initial countdown
    //Theres probably a better way to do this but this is what I worked out lol
    //It simply takes 5 different UI elements and sets them active then unactive on a timer
    public GameObject second1;
    public GameObject second2;
    public GameObject second3;
    public GameObject second4;
    public GameObject second5;
    void Start()
    {
        Invoke("startsec1", 10);
        Invoke("startsec2", 8);
        Invoke("startsec3", 6);
        Invoke("startsec4", 4);
        Invoke("startsec5", 2);

        Invoke("stopsec1", 10.5f);
        Invoke("stopsec2", 8.5f);
        Invoke("stopsec3", 6.5f);
        Invoke("stopsec4", 4.5f);
        Invoke("stopsec5", 2.5f);
    }

    private void startsec1()
    {
        second1.SetActive(true);
    }
    private void startsec2()
    {
        second2.SetActive(true);
    }
    private void startsec3()
    {
        second3.SetActive(true);
    }
    private void startsec4()
    {
        second4.SetActive(true);
    }
    private void startsec5()
    {
        second5.SetActive(true);
    }

    private void stopsec1()
    {
        second1.SetActive(false);
    }
    private void stopsec2()
    {
        second2.SetActive(false);
    }
    private void stopsec3()
    {
        second3.SetActive(false);
    }
    private void stopsec4()
    {
        second4.SetActive(false);
    }
    private void stopsec5()
    {
        second5.SetActive(false);
    }
}
