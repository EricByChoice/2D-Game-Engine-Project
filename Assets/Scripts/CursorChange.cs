using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D[] cursorFrames;
    public float frameRate = 0.1f;
    public Vector2 hotspot = Vector2.zero;

    private int currentFrame;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;

            currentFrame++;
            if (currentFrame >= cursorFrames.Length)
                currentFrame = 0;

            Cursor.SetCursor(cursorFrames[currentFrame], hotspot, CursorMode.Auto);
        }
    }
}
