


$(document).ready(function () {

    $('#strong').click(function (event) {
        event.preventDefault();
        let t = $('#articleContent');
        let start = t.get(0).selectionStart;
        let finish = t.get(0).selectionEnd;
        let selectedString = t.val().substring(start, finish);
        let allText = t.val();
        let resultString = allText.slice(0, start) + '<strong>' + selectedString + '</strong>' + allText.slice(finish);
        $('#articleContent').val('');
        $('#articleContent').val(resultString);
    });

    $('#strong').click(function (event) {
        event.preventDefault();
        let t = $('#articleContent');
        var position = window.getSelection().getRangeAt(0).startOffset;
        console.log(position);
        let start = t.get(0).selectionStart;
        let finish = t.get(0).selectionEnd;
        let selectedString = t.val().substring(start, finish);
        let allText = t.val();
        let resultString = allText.slice(0, start) + '<strong>' + selectedString + '</strong>' + allText.slice(finish);
        $('#articleContent').val('');
        $('#articleContent').val(resultString);
    });

    $('#italics').click(function (event) {
        event.preventDefault();
        let t = $('#articleContent');
        let start = t.get(0).selectionStart;
        let finish = t.get(0).selectionEnd;
        let selectedString = t.val().substring(start, finish);
        let allText = t.val();
        let resultString = allText.slice(0, start) + '<i>' + selectedString + '</i>' + allText.slice(finish);
        $('#articleContent').val('');
        $('#articleContent').val(resultString);
    });

    $('#h2').click(function (event) {
        event.preventDefault();
        let t = $('#articleContent');
        let start = t.get(0).selectionStart;
        let finish = t.get(0).selectionEnd;
        let selectedString = t.val().substring(start, finish);
        let allText = t.val();
        let resultString = allText.slice(0, start) + '<h2>' + selectedString + '</h2>' + allText.slice(finish);
        $('#articleContent').val('');
        $('#articleContent').val(resultString);
    });

    $('#h3').click(function (event) {
        event.preventDefault();
        let t = $('#articleContent');
        let start = t.get(0).selectionStart;
        let finish = t.get(0).selectionEnd;
        let selectedString = t.val().substring(start, finish);
        let allText = t.val();
        let resultString = allText.slice(0, start) + '<h3>' + selectedString + '</h3>' + allText.slice(finish);
        $('#articleContent').val('');
        $('#articleContent').val(resultString);
    });

    $('#h4').click(function (event) {
        event.preventDefault();
        let t = $('#articleContent');
        let start = t.get(0).selectionStart;
        let finish = t.get(0).selectionEnd;
        let selectedString = t.val().substring(start, finish);
        let allText = t.val();
        let resultString = allText.slice(0, start) + '<h4>' + selectedString + '</h4>' + allText.slice(finish);
        $('#articleContent').val('');
        $('#articleContent').val(resultString);
    });

    $('#link').click(function (event) {
        event.preventDefault();
        let link = prompt();
        let t = $('#articleContent');
        let start = t.get(0).selectionStart;
        let finish = t.get(0).selectionEnd;
        let selectedString = t.val().substring(start, finish);
        let allText = t.val();
        let resultString = allText.slice(0, start) + "<a href='" + link + "' target='_blanc'>" + selectedString + "</a>" + allText.slice(finish);
        $('#articleContent').val('');
        $('#articleContent').val(resultString);
    });

    $('#blockquote').click(function (event) {
        event.preventDefault();
        let t = $('#articleContent');
        let start = t.get(0).selectionStart;
        let finish = t.get(0).selectionEnd;
        let selectedString = t.val().substring(start, finish);
        let allText = t.val();
        let resultString = allText.slice(0, start) + '<blockquote>' + selectedString + '</blockquote>' + allText.slice(finish);
        $('#articleContent').val('');
        $('#articleContent').val(resultString);
    });

    $('#img').click(function (event) {
        event.preventDefault();
        let link = prompt('Добавьте ссылку');
        let t = $('#articleContent');
        let start = t.get(0).selectionStart;
        let finish = t.get(0).selectionEnd;
        let selectedString = t.val().substring(start, finish);
        let allText = t.val();
        let resultString = allText.slice(0, start) + "<img src='" + link + "' class='img-fluid'/>" + allText.slice(finish);
        $('#articleContent').val('');
        $('#articleContent').val(resultString);
    });
});





// Блок кода на чистом JS

// первый блок (основные цвета)
let coloredElement = document.getElementById('labelHeaderColor');
let selectColor = document.getElementById('selectHeaderColor');
let headerColor = document.getElementById('headerColor');
selectColor.addEventListener('change', function () {
    coloredElement.style.color = selectColor.value;
    headerColor.style.backgroundColor = selectColor.value;
});

let coloredElement1 = document.getElementById('labelHeaderHoverColor');
let selectColor1 = document.getElementById('selectHeaderHoverColor');
let headerHoverColor = document.getElementById('headerHoverColor');
selectColor1.addEventListener('change', function () {
    coloredElement1.style.color = selectColor1.value;
    headerHoverColor.style.backgroundColor = selectColor1.value;
});

let coloredElement2 = document.getElementById('labelContextTextColor');
let selectColor2 = document.getElementById('selectContextTextColor');
let contextTextColor = document.getElementById('contextTextColor');
selectColor2.addEventListener('change', function () {
    coloredElement2.style.color = selectColor2.value;
    contextTextColor.style.backgroundColor = selectColor2.value;
});

let coloredElement3 = document.getElementById('labelBlockquoteTextColor');
let selectColor3 = document.getElementById('selectBlockquoteTextColor');
let blockquoteTextColor = document.getElementById('blockquoteTextColor');
selectColor3.addEventListener('change', function () {
    coloredElement3.style.color = selectColor3.value;
    blockquoteTextColor.style.backgroundColor = selectColor3.value;
});

let coloredElement4 = document.getElementById('labelBlockquoteBorderColor');
let selectColor4 = document.getElementById('selectBlockquoteBorderColor');
let blockquoteBorderColor = document.getElementById('blockquoteBorderColor');
selectColor4.addEventListener('change', function () {
    coloredElement4.style.color = selectColor4.value;
    blockquoteBorderColor.style.backgroundColor = selectColor4.value;
});

let coloredElement41 = document.getElementById('labelLinkColor');
let selectColor41 = document.getElementById('selectLinkColor');
let linkColor = document.getElementById('linkColor');
selectColor41.addEventListener('change', function () {
    coloredElement41.style.color = selectColor41.value;
    linkColor.style.backgroundColor = selectColor41.value;
});

let coloredElement42 = document.getElementById('labelLinkHoverColor');
let selectColor42 = document.getElementById('selectLinkHoverColor');
let linkHoverColor = document.getElementById('linkHoverColor');
selectColor42.addEventListener('change', function () {
    coloredElement42.style.color = selectColor42.value;
    linkHoverColor.style.backgroundColor = selectColor42.value;
});




// второй блок (пагинация, меню)
let coloredElement5 = document.getElementById('labelPaginationActiveColor');
let selectColor5 = document.getElementById('selectPaginationActiveColor');
let paginationActiveColor = document.getElementById('paginationActiveColor');
selectColor5.addEventListener('change', function () {
    coloredElement5.style.color = selectColor5.value;
    paginationActiveColor.style.backgroundColor = selectColor5.value;
});

let coloredElement6 = document.getElementById('labelPaginationHoverColor');
let selectColor6 = document.getElementById('selectPaginationHoverColor');
let paginationHoverColor = document.getElementById('paginationHoverColor');
selectColor6.addEventListener('change', function () {
    coloredElement6.style.color = selectColor6.value;
    paginationHoverColor.style.backgroundColor = selectColor6.value;
});

let coloredElement7 = document.getElementById('labelPaginationDisabledColor');
let selectColor7 = document.getElementById('selectPaginationDisabledColor');
let paginationDisabledColor = document.getElementById('paginationDisabledColor');
selectColor7.addEventListener('change', function () {
    coloredElement7.style.color = selectColor7.value;
    paginationDisabledColor.style.backgroundColor = selectColor7.value;
});

let coloredElement8 = document.getElementById('labelPaginationBorderColor');
let selectColor8 = document.getElementById('selectPaginationBorderColor');
let paginationBorderColor = document.getElementById('paginationBorderColor');
selectColor8.addEventListener('change', function () {
    coloredElement8.style.color = selectColor8.value;
    paginationBorderColor.style.backgroundColor = selectColor8.value;
});

let coloredElement83 = document.getElementById('labelPaginationBorderHoverColor');
let selectColor83 = document.getElementById('selectPaginationBorderHoverColor');
let paginationBorderHoverColor = document.getElementById('paginationBorderHoverColor');
selectColor83.addEventListener('change', function () {
    coloredElement83.style.color = selectColor83.value;
    paginationBorderHoverColor.style.backgroundColor = selectColor83.value;
});

let coloredElement81 = document.getElementById('labelPaginationFontColor');
let selectColor81 = document.getElementById('selectPaginationFontColor');
let paginationFontColor = document.getElementById('paginationFontColor');
selectColor81.addEventListener('change', function () {
    coloredElement81.style.color = selectColor81.value;
    paginationFontColor.style.backgroundColor = selectColor81.value;
});

let coloredElement82 = document.getElementById('labelPaginationFontHoverColor');
let selectColor82 = document.getElementById('selectPaginationFontHoverColor');
let paginationFontHoverColor = document.getElementById('paginationFontHoverColor');
selectColor82.addEventListener('change', function () {
    coloredElement82.style.color = selectColor82.value;
    paginationFontHoverColor.style.backgroundColor = selectColor82.value;
});






// блок цветов меню
let coloredElement9 = document.getElementById('labelMenuBackgroundColor');
let selectColor9 = document.getElementById('selectMenuBackgroundColor');
let menuBackgroundColor = document.getElementById('menuBackgroundColor');
selectColor9.addEventListener('change', function () {
    coloredElement9.style.color = selectColor9.value;
    menuBackgroundColor.style.backgroundColor = selectColor9.value;
});

let coloredElement10 = document.getElementById('labelMenuFontColor');
let selectColor10 = document.getElementById('selectMenuFontColor');
let menuFontColor = document.getElementById('menuFontColor');
selectColor10.addEventListener('change', function () {
    coloredElement10.style.color = selectColor10.value;
    menuFontColor.style.backgroundColor = selectColor10.value;
});

let coloredElement11 = document.getElementById('labelMenuBackgroundHoverColor');
let selectColor11 = document.getElementById('selectMenuBackgroundHoverColor');
let menuBackgroundHoverColor = document.getElementById('menuBackgroundHoverColor');
selectColor11.addEventListener('change', function () {
    coloredElement11.style.color = selectColor10.value;
    menuBackgroundHoverColor.style.backgroundColor = selectColor11.value;
});

let coloredElement12 = document.getElementById('labelMenuFontHoverColor');
let selectColor12 = document.getElementById('selectMenuFontHoverColor');
let menuFontHoverColor = document.getElementById('menuFontHoverColor');
selectColor12.addEventListener('change', function () {
    coloredElement12.style.color = selectColor12.value;
    menuFontHoverColor.style.backgroundColor = selectColor12.value;
});

let coloredElement13 = document.getElementById('labelMenuBorderColor');
let selectColor13 = document.getElementById('selectMenuBorderColor');
let menuBorderColor = document.getElementById('menuBorderColor');
selectColor13.addEventListener('change', function () {
    coloredElement13.style.color = selectColor13.value;
    menuBorderColor.style.backgroundColor = selectColor13.value;
});

let coloredElement14 = document.getElementById('labelMenuBorderHoverColor');
let selectColor14 = document.getElementById('selectMenuBorderHoverColor');
let menuBorderHoverColor = document.getElementById('menuBorderHoverColor');
selectColor14.addEventListener('change', function () {
    coloredElement14.style.color = selectColor14.value;
    menuBorderHoverColor.style.backgroundColor = selectColor14.value;
});

// блок цветов фдмин панели
let coloredElement15 = document.getElementById('labelAdminFontColor');
let selectColor15 = document.getElementById('selectAdminFontColor');
let adminFontColor = document.getElementById('adminFontColor');
selectColor15.addEventListener('change', function () {
    coloredElement15.style.color = selectColor15.value;
    adminFontColor.style.backgroundColor = selectColor15.value;
});

let coloredElement16 = document.getElementById('labelAdminHeaderColor');
let selectColor16 = document.getElementById('selectAdminHeaderColor');
let adminHeaderColor = document.getElementById('adminHeaderColor');
selectColor16.addEventListener('change', function () {
    coloredElement16.style.color = selectColor16.value;
    adminHeaderColor.style.backgroundColor = selectColor16.value;
});


let coloredElement17 = document.getElementById('labelAdminBackgroundColor');
let selectColor17 = document.getElementById('selectAdminBackgroundColor');
let adminBackgroundColor = document.getElementById('adminBackgroundColor');
selectColor17.addEventListener('change', function () {
    coloredElement17.style.color = selectColor17.value;
    adminBackgroundColor.style.backgroundColor = selectColor17.value;
});

let coloredElement18 = document.getElementById('labelAdminMenuBackgroundColor');
let selectColor18 = document.getElementById('selectAdminMenuBackgroundColor');
let adminMenuBackgroundColor = document.getElementById('adminMenuBackgroundColor');
selectColor18.addEventListener('change', function () {
    coloredElement18.style.color = selectColor18.value;
    adminMenuBackgroundColor.style.backgroundColor = selectColor18.value;
});

let coloredElement19 = document.getElementById('labelAdminMenuFontColor');
let selectColor19 = document.getElementById('selectAdminMenuFontColor');
let adminMenuFontColor = document.getElementById('adminMenuFontColor');
selectColor19.addEventListener('change', function () {
    coloredElement19.style.color = selectColor19.value;
    adminMenuFontColor.style.backgroundColor = selectColor19.value;
});

let coloredElement20 = document.getElementById('labelAdminMenuFontHoverColor');
let selectColor20 = document.getElementById('selectAdminMenuFontHoverColor');
let adminMenuFontHoverColor = document.getElementById('adminMenuFontHoverColor');
selectColor20.addEventListener('change', function () {
    coloredElement20.style.color = selectColor20.value;
    adminMenuFontHoverColor.style.backgroundColor = selectColor20.value;
});
















