document.addEventListener("DOMContentLoaded", () => {

    const icon = document.getElementById("icon-hienform");
    const form = document.getElementById("DangNhap");

    icon.addEventListener("click", () => {
        form.style.display = form.style.display === "block" ? "none" : "block";
    });

});