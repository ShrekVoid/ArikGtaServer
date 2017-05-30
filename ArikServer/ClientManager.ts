/// <reference path="types-gtanetwork/index.d.ts" />

var mainCam = null;

API.onServerEventTrigger.connect(function (name, args) {
    switch (name) {
        case "selection_start":
            mainCam = API.createCamera(new Vector3(-83.23415, -835.2518, 326.6785), new Vector3());
            API.pointCameraAtEntity(mainCam, API.getLocalPlayer(), new Vector3());
            API.setActiveCamera(mainCam);
            break;
        default:
            break;
    }
});

API.onUpdate.connect(function () {
    API.disableAllControlsThisFrame();
})