let currentIndex = 0;

function moveSlide(direction) {
    const btnPrev = document.querySelector('.btn__previous');
    const btnNext = document.querySelector('.btn__next');
    const slider = document.getElementById('slider');
    const totalSlide = document.querySelectorAll('.img__review').length;
    const imgVisible = 5;
    const imgWidth = 270;

    currentIndex += direction;

    if (currentIndex < 0) {
        currentIndex = 0;
    } else if (currentIndex > totalSlide - imgVisible) {
        currentIndex = totalSlide - imgVisible;
    }
    if (currentIndex === totalSlide - imgVisible) {
        btnNext.classList.add('btn-hidden');
    } else {
        btnNext.classList.remove('btn-hidden');
    }
    if (currentIndex === 0) {
        btnPrev.classList.add('btn-hidden');
    } else {
        btnPrev.classList.remove('btn-hidden');
    }
    const translateX = -currentIndex * imgWidth;
    slider.style.transform = 'translateX(' + translateX + 'px)'; 
}
window.onload = function () {
    moveSlide(0);
};