using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 AddHeight(this Vector3 position, float height)
    {
        return new Vector3(position.x, position.y + height, position.z);
    }
}