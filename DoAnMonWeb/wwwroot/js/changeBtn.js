document.addEventListener("DOMContentLoaded", () => {
    const allbtn = document.querySelectorAll('.nut');
    const allcontent = document.querySelectorAll('.tab-content');

    allbtn.forEach(btn => {
        btn.addEventListener('click', function () {
            if (this.classList.contains("out")) {
                if (confirm("Bạn có chắc chắn muốn đăng xuất không?")) {
                    window.location.href = "/TaiKhoan/DangXuat";
                }
                return;
            }

            allbtn.forEach(b => b.classList.remove('is-chosen'));
            allcontent.forEach(c => c.classList.add('is-che')); 
            this.classList.add('is-chosen');
            let targetClass = "";
            if (this.classList.contains("inf")) targetClass = "thongtin";
            else if (this.classList.contains("donhang")) targetClass = "donhang";
            else if (this.classList.contains("yeuthich")) targetClass = "yeuthich";
            else if (this.classList.contains("diachi")) targetClass = "diachi";

            if (targetClass !== "") {
                const targetTab = document.querySelector(`.tab-content.${targetClass}`);
                if (targetTab) {
                    targetTab.classList.remove('is-che');
                }
            }

            const btnAddAddress = document.querySelector('.btn-add-diachi');
            if (targetClass === "diachi") {
                btnAddAddress?.classList.remove('is-che');
            } else {
                btnAddAddress?.classList.add('is-che');
            }
        });
    });
});

function showEditForm(id, hoten, sdt, diachi, tinhthanh, isDefault) {
    document.getElementById('edit-MaDiaChi').value = id;
    document.getElementById('edit-HoTen').value = hoten;
    document.getElementById('edit-Sdt').value = sdt;
    document.getElementById('edit-DiaChi').value = diachi;
    document.getElementById('edit-TinhThanh').value = tinhthanh;
    document.getElementById('edit-IsDefault').checked = (isDefault === "true");

    document.getElementById('addr-list-view').style.display = 'none';
    document.getElementById('addr-edit-view').style.display = 'block';
}

function hideEditForm() {
    document.getElementById('addr-list-view').style.display = 'block';
    document.getElementById('addr-edit-view').style.display = 'none';
}

function showAddForm() {
    document.getElementById('addr-list-view').style.display = 'none';
    document.getElementById('addr-add-view').style.display = 'block';
    document.getElementById('addr-edit-view').style.display = 'none';
}

function hideAddForm() {
    document.getElementById('addr-list-view').style.display = 'block';
    document.getElementById('addr-add-view').style.display = 'none';
}

function combineName() {
    var ho = document.getElementById('input-ho').value;
    var ten = document.getElementById('input-ten').value;
    document.getElementById('full-name-hidden').value = ho + " " + ten;
}