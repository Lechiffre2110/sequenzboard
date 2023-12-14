using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    //1. Griffe von A-O
    //2. Kleinbuchstabe s=grün r=blau l=gelb f=lila
    //Sequenz beginnt mit Griff+s und endet mit Griff+f
    //Dazwischen sind x Mal Griff+r und Griff+l
    string generateSeq(int length) 
    {
        string sequence = "";
        //Start Griff
        Griff startGriff1 = (Griff)Random.Range(0, 15);
        Griffanweisung startGriffanweisung1 = Griffanweisung.s;
        Griff startGriff2 = (Griff)Random.Range(0, 15);
        Griffanweisung startGriffanweisung2 = Griffanweisung.s;
        sequence += startGriff1.ToString() + startGriffanweisung1.ToString() + startGriff2.ToString() + startGriffanweisung2.ToString();

        for (int i = 0; i < length-2; i++)
        {
            Griff middleGriff = (Griff)Random.Range(0, 15);
            Griffanweisung middleGriffanweisung = (Griffanweisung)Random.Range(1, 3);
            sequence += middleGriff.ToString() + middleGriffanweisung.ToString();
        }
        
        //End Griff
        Griff endGriff1 = (Griff)Random.Range(0, 15);
        Griffanweisung endGriffanweisung1 = Griffanweisung.f;
        Griff endGriff2 = (Griff)Random.Range(0, 15);
        Griffanweisung endGriffanweisung2 = Griffanweisung.f;
        sequence += endGriff1.ToString() + endGriffanweisung1.ToString() + endGriff2.ToString() + endGriffanweisung2.ToString();
        Debug.Log(sequence);
        return sequence;
    }
    

    void Start()
    {
        generateSeq(15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
