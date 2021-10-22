using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Character
{
    [SerializeField] private PersonController personController;

    public PersonController PersonController => personController;

}
