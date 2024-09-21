using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    //camel case
    //Variable
    string enemyName = "Zombie";
    int enemyHPCurrent = 4300;
    int enemyHPMax = 100;
    bool isDead = true;
    float weight = 0.5f;

    //Comment, Note, Ghi Chu
    //Method
    public void Running()
    {
        //Bien, Variable, object
        Animal animal1 = new Animal(); //Local
        Animal animal2 = new Animal();

        int a = 10;
        int b = 20;
        int c = a + b; //30

        string firstName = "Sai";
        string lastName = "Game";
        string fullName = firstName +" "+ lastName; //Sai Game


        //OOP - Lap Trinh Huong Doi Tuong Object
        //La cach code 
        //Huong Cau Truc: Method
    }

    protected void Attack()
    {
    }
}
