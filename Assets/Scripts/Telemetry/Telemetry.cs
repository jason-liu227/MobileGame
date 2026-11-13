using System.IO;
using System.Text;
using UnityEngine;

public static class Telemetry
{
    private static readonly string session =
        System.Guid.NewGuid().ToString("N").Substring(0, 8);

    private static readonly string path =
        Path.Combine(
            Application.persistentDataPath,
            "telemetry.log"
        );

    public static void Log(
        string ev,
        params (string k, object v)[] parameters)
    {
        var sb = new StringBuilder(128);

        sb.Append(Time.realtimeSinceStartup.ToString("F2"))
          .Append(' ')
          .Append(session)
          .Append(' ')
          .Append(ev);

        foreach (var (key, value) in parameters)
        {
            sb.Append(' ')
              .Append(key)
              .Append('=')
              .Append(value);
        }

        string line = sb.ToString();

        Debug.Log("[telemetry] " + line);
        Debug.Log("Telemetry file: " + path);

        File.AppendAllText(path, line + "\n");
    }
}

