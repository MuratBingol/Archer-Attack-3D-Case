using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public interface IState
{
    void EnterState<T>(T control);
    void ExitState();
}
