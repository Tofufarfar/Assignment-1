using UnityEngine;

public static class GameState

{
    public static bool HasStartedGame = false;
    public static bool onMainMenu = true;
    public static bool onSettingsMenu = false;
    public static bool inGameplay = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void Reset()
    {
        HasStartedGame = false;
        onMainMenu = true;
        onSettingsMenu = false;
        inGameplay = false;
}
}
