using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {

    public static string AxleColor = "AxleColor";

    public static Dictionary<string, GameObject> prefabDic = new Dictionary<string, GameObject>();
    public static Dictionary<string, Material> materialDic = new Dictionary<string, Material>();
    public static List<Color> colorList = new List<Color>();
    public static Dictionary<string, Sprite> spDic = new Dictionary<string, Sprite>();

    public static ResourcesManager Instance;
    public static void setRGB(float r,float g,float b)
    {
        colorList.Add(new Color(r/255f,g/255f,b/255f,98/255f));
    }
    public void save2PrefabDic(string key, GameObject value)
    {
        if (prefabDic.ContainsKey(key) == true)
        {
            return;
        }
        else
        {
            prefabDic.Add(key, value);
            
        }
    }
    public void save2MaterialDic(string key, Material value)
    {
        if (materialDic.ContainsKey(key) == true)
        {
            return;
        }
        else
        {

            materialDic.Add(key, value);

        }
    }

    public void load(string key)
    {
        prefabDic.Add(key, Resources.Load<GameObject>(key));

        Debug.Log(key);

    }
    public void loadWL(string key)
    {
        materialDic.Add(key, Resources.Load<Material>(key));
    }
    public void save2SpDic(string key)
    {

        spDic.Add(key, Resources.Load<Sprite>(key));
    }
    void Awake()
    {
      
        if (ResourcesManager.Instance != null)
        {
            Debug.Log("不为空！");
            return;
        }
        else
        {
            Debug.Log("为空！");
            ResourcesManager.Instance = this;
        }

        save2PrefabDic(ResName.chest, Resources.Load<GameObject>(ResName.chest));
        save2PrefabDic(ResName.bullet, Resources.Load<GameObject>(ResName.bullet));
        save2PrefabDic(ResName.FileButton, Resources.Load<GameObject>(ResName.FileButton));
        save2PrefabDic(ResName.shapeItem, Resources.Load<GameObject>(ResName.shapeItem));
        save2PrefabDic(ResName.layerItem, Resources.Load<GameObject>(ResName.layerItem));
        //save2SpDic(ResName.hammer);

 
       
        load(ResName.shapeDataItem);
       
        load(ResName.SettingItem);
        loadWL(ResName.wl_jzx_001);
        loadWL(ResName.wl_jzx_002);
        loadWL(ResName.wl_jzx_003);
        load(ResName.ShapeItem);

        save2MaterialDic(AxleColor, Resources.Load<Material>(AxleColor));
        save2MaterialDic(ResName.AimPointMateril, Resources.Load<Material>(ResName.AimPointMateril));

        save2MaterialDic(ResName.OnGetOriginMateril, Resources.Load<Material>(ResName.OnGetOriginMateril));

        setRGB(	255,222 ,173);
        setRGB(84, 255 ,159);
        setRGB(	205 ,173, 0);
        setRGB(	238, 99, 99);
 

    
    }

}
