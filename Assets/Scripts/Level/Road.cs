using UnityEngine;

public class Road
{
    public GameObject Object { get; set; }
    public int Id { get; set; }

    public Road(GameObject obj, int id)
    {
        Object = obj;
        Id = id;
    }
}
