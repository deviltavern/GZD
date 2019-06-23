using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StrategyMaster {

    void endStrategy();
    void endStrategy(Strategy strategy);
    void addStrategy(Strategy _strategy);
    void deleteStrategy(Strategy _strategy);
}
