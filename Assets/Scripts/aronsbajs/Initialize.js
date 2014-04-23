#pragma strict

static var loaded = false;
static function Initialize() {
 
  if(!loaded) {
    loaded = true;
    var levelData = PlayerPrefs.GetString("_PAUSE_GAME_","");
    if(!String.IsNullOrEmpty(levelData))
        LevelSerializer.LoadSavedLevel(levelData);
   }
}
 
function Start() {
    Initialize();
}
 
function OnApplicationPause(paused : boolean) {
    if(paused) PlayerPrefs.SetString("_PAUSE_GAME_", LevelSerializer.SerializeLevel());
}