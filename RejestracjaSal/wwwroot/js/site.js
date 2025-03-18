// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    const usernameInput = document.getElementById("username");
    const passwordInput = document.getElementById("password");
    const loginButton = document.querySelector(".zaloguj");
    const navbar = document.querySelector(".navbar");


    // Efekt podświetlenia inputów
    [usernameInput, passwordInput].forEach(input => {
        input.addEventListener("focus", function () {
            this.style.borderColor = "var(--100)";
            this.style.boxShadow = "0 0 5px var(--100)";
        });
        input.addEventListener("blur", function () {
            this.style.borderColor = "var(--300)";
            this.style.boxShadow = "none";
        });
    });

    // Animacja przycisku logowania
    loginButton.addEventListener("mouseenter", function () {
        this.style.transform = "scale(1.05)";
    });
    loginButton.addEventListener("mouseleave", function () {
        this.style.transform = "scale(1)";
    });

});
