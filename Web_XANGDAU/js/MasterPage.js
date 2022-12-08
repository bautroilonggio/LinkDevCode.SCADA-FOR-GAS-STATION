const allSideMenu = document.querySelectorAll('.sidebar .side_menu.top li a');

allSideMenu.forEach(item => {
    const li = item.parentElement;

    item.addEventListener('click', function () {
        allSideMenu.forEach(i => {
            i.parentElement.classList.remove('active');
        })
        li.classList.add('active');
    })
});

//Toggle SideMenu
$("#menu").click(function () {
    $(".sidebar").toggleClass(' hide');
})


