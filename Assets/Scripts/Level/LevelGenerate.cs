using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerate : MonoBehaviour
{
    [SerializeField] private GameObject[] _staticRoadElementsObjects;
    [SerializeField] private GameObject _startRoadObject;
    [SerializeField] private Transform _parent;

    [SerializeField] private Vector3 _startPosition;

    private GameObject _roadPart;

    private Road _lastRoad;
    private List<Road> _staticRoadElements;
    private Road _startRoad;

    public int RoadInScene = 0;

    private void Start()
    {

        _startRoad = ConvertObjectToRoad(_startRoadObject, 902);
        _staticRoadElements = GetRoadsFromObjects(_staticRoadElementsObjects);

        RoadGenerate(_startRoad, _startPosition);
        RoadGenerate(3, _staticRoadElements);
    }

    private void Update()
    {
        if (RoadInScene < 3)
        {
            RoadGenerate(1, _staticRoadElements);
        }
    }

    private Road ConvertObjectToRoad(GameObject forwardRoadObject, int id)
    {
        return new Road(forwardRoadObject, id);
    }

    private void RoadGenerate(Road startRoad, Vector3 position)
    {
        _roadPart = Instantiate(startRoad.Object);
        _roadPart.transform.localPosition = position;
        _roadPart.transform.parent = _parent;
        _lastRoad = ConvertObjectToRoad(_roadPart, startRoad.Id);
        //_roadOffsetY = _lastRoad.Object.transform.position.y + GetSpriteOffset(GetSprite(_roadPart));
        RoadInScene++;
    }

    private Sprite GetSprite(Road _lastRoad)
    {
        return _lastRoad.Object.GetComponent<SpriteRenderer>().sprite;
    }
    
    private Sprite GetSprite(GameObject _lastRoad)
    {
        return _lastRoad.GetComponent<SpriteRenderer>().sprite;
    }

    private float GetSpriteOffset(Sprite sprite)
    {
        return sprite.rect.size.y / sprite.pixelsPerUnit;
    }
    
    private float GetSpriteOffset(GameObject obj)
    {
        Sprite sprite = obj.GetComponent<SpriteRenderer>().sprite;
        return sprite.rect.size.y / sprite.pixelsPerUnit;
    }

    private void RoadGenerate(int roadCount, List<Road> roadElements)
    {
        for (int i = 0; i < roadCount; i++)
        {
            RoadGenerate(GetRandomRoad(roadElements, _lastRoad),
                new Vector3
                (
                _startPosition.x,
                _lastRoad.Object.transform.position.y + GetSpriteOffset(GetSprite(_roadPart)),
                _startPosition.z)
                );
        }
    }

    private Road GetRandomRoad(List<Road> roadElements, Road _lastRoad)
    {
        int randomRegime = Random.Range(0, 10);

        if (randomRegime < 1)
        {
            return roadElements[Random.Range(0, roadElements.Count)];
        }
        else
        {
            return GetRandomRoadIfRoadInArray(roadElements);
        }
    }

    private Road GetRandomRoadIfRoadInArray(List<Road> roadElements)
    {
        List<Road> listRoadElements = roadElements.GetRange(0, roadElements.Count);

        if (listRoadElements.Any(element => element.Id == _lastRoad.Id))
        {
            listRoadElements.Remove(listRoadElements.First(element => element.Id == _lastRoad.Id));
        }

        return listRoadElements[Random.Range(0, listRoadElements.Count)];
    }

    private List<Road> GetRoadsFromObjects(GameObject[] roadElements)
    {
        List<Road> roads = new List<Road>();
        int id = 0;

        foreach (GameObject road in _staticRoadElementsObjects)
        {
            roads.Add(ConvertObjectToRoad(road, id));
            id++;
        }

        return roads;
    }
}
