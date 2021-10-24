using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PersonState
{
    Wandering,
    Isolating,
    Interacting
}

public class Person : Character
{
    [SerializeField] private PersonController personController;
    public bool hadFirstDose;
    public bool hadSecondDose;
    public bool isImmune;
    public bool isInfected;
    public bool isVulnerable;

    public PersonController PersonController => personController;

}
