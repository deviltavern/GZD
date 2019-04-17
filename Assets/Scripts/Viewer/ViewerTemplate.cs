using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class ViewerTemplate : MonoBehaviour,IViewer {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addViewer(IViewer view)
    {
        throw new System.NotImplementedException();
    }

    public void deleteViewer(IViewer view)
    {
        throw new System.NotImplementedException();
    }

    public void broadCast(ViewInfo info)
    {
        throw new System.NotImplementedException();
    }

    public virtual void update(ViewInfo info)
    {
        
    }
}
