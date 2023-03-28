using UnityEngine;
using System.Collections;

public class NPC_FSM: FSM
{
    public enum FSMState {
        None, 
        WaitForHelp,
        RunInPanic,
        runForExtraction
    }

    public FSMState currentState;

    private float currentSpeed;
    private float currentRotationSpeed;

    private bool isDead;
    private int health;
}