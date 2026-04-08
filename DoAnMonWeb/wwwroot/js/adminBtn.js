const allbtn = document.querySelectorAll('.quanly');
const allcontent = document.querySelectorAll('.quanly-content');

allbtn.forEach(btn => {
    btn.addEventListener('click', () => {
        allbtn.forEach(b => b.classList.remove('is-chosen'));

        allcontent.forEach(c => c.classList.add('is-hidden'));

        btn.classList.add('is-chosen');

        let tab = "";

        if (btn.classList.contains("dashboard-btn")) tab = "dashboard";
        else if (btn.classList.contains("sanpham-btn")) tab = "sanpham";
        else if (btn.classList.contains("loaisanpham-btn")) tab = "loaisanpham";
        else if (btn.classList.contains("kichco-btn")) tab = "kichco";
        else if (btn.classList.contains("mausac-btn")) tab = "mausac";
        else if (btn.classList.contains("donhang-btn")) tab = "donhang";
        else if (btn.classList.contains("taikhoan-btn")) tab = "taikhoan";
        else return;

        const targetContent = document.querySelector(`.quanly-content.${tab}`);
        if (targetContent) {
            targetContent.classList.remove('is-hidden');
        }    });
});

window.onload = function () {
    let tab = '@tab';

    if (tab === "kichco") {
        document.querySelector(".kichco-btn")?.click();
    }
}
