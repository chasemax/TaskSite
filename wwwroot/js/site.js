// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function confirm() {
    if (confirm("Are you sure you want to delete this task?") == true) {
        return ();
    }
    else {
        return (window.location.href = "~/Home/Quadrant.cshtml");
    }
}