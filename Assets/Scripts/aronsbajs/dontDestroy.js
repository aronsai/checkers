#pragma strict

    private static var instance:dontDestroy;
    public static function GetInstance() : dontDestroy {
    return instance;
    }
     
    function Awake() {
    if (instance != null && instance != this) {
    Destroy(this.gameObject);
    return;
    } else {
    instance = this;
    }
    DontDestroyOnLoad(this.gameObject);
    }