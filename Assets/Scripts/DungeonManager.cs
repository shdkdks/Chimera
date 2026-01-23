using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public FloorData currentFloor;

    void Start()
    {
        GenerateFloor(1);
        PrintFloor();
    }

    void GenerateFloor(int floor)
    {
        currentFloor = new FloorData();
        currentFloor.floorNumber = floor;

        currentFloor.rooms.Add(new RoomData(0, RoomType.Start));
        currentFloor.rooms.Add(new RoomData(1, RoomType.Monster));
        currentFloor.rooms.Add(new RoomData(2, RoomType.Event));
        currentFloor.rooms.Add(new RoomData(3, RoomType.Monster));
        currentFloor.rooms.Add(new RoomData(4, RoomType.MiniBoss));
        currentFloor.rooms.Add(new RoomData(5, RoomType.Rest));
        currentFloor.rooms.Add(new RoomData(6, RoomType.Boss));
    }

    void PrintFloor()
    {
        Debug.Log($"[Floor {currentFloor.floorNumber}]");

        foreach (var room in currentFloor.rooms)
        {
            Debug.Log($"Room {room.roomIndex} : {room.roomType}");
        }
    }
}
