window.initMouseTracker = (trackerId, xId, yId, dotnetObj) => {
    const tracker = document.getElementById(trackerId);

    tracker.addEventListener("mousemove", (e) => {
        const mouseX = e.clientX;
        const mouseY = e.clientY;

        dotnetObj.invokeMethodAsync("UpdateMousePosition", mouseX, mouseY);
    });
};
