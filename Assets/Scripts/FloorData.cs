using System.Collections.Generic;

[System.Serializable]
public class FloorData
{
    public int floorNumber;
    public List<RoomData> rooms = new List<RoomData>();
}