[System.Serializable]
public class RoomData
{
    public int roomIndex;
    public RoomType roomType;
    public bool isCleared;

    public RoomData(int index, RoomType type)
    {
        roomIndex = index;
        roomType = type;
        isCleared = false;
    }
}