function calcAvailability(controlId, checked) {
    var control = document.getElementById(controlId);
    control.style.visibility = checked ? "hidden" : "visible";
}