using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObviewer  {
    void addViewer(IViewer view);
    void deleteViewer(IViewer view);
    void broadCast(ViewInfo info);

}
