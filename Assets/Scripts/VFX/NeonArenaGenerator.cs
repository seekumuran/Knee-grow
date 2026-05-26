using UnityEngine;

public class NeonArenaGenerator : MonoBehaviour
{
    public Material neonMaterial;

    public int arenaSize = 20;

    void Start()
    {
        GenerateArena();
    }

    void GenerateArena()
    {
        for (int x = -arenaSize; x < arenaSize; x += 4)
        {
            CreateNeonStrip(
                new Vector3(x, 0.05f, arenaSize)
            );

            CreateNeonStrip(
                new Vector3(x, 0.05f, -arenaSize)
            );
        }

        for (int z = -arenaSize; z < arenaSize; z += 4)
        {
            CreateNeonStrip(
                new Vector3(arenaSize, 0.05f, z)
            );

            CreateNeonStrip(
                new Vector3(-arenaSize, 0.05f, z)
            );
        }
    }

    void CreateNeonStrip(Vector3 pos)
    {
        GameObject cube =
            GameObject.CreatePrimitive(
                PrimitiveType.Cube
            );

        cube.transform.position = pos;

        cube.transform.localScale =
            new Vector3(2f, 0.1f, 0.3f);

        cube.GetComponent<Renderer>().material =
            neonMaterial;
    }
}
