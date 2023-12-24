var form = document.getElementById('form');
document.getElementById('add').addEventListener('click', function () {

    form.insertAdjacentHTML('beforeend', '<input class="form-control" name="category"/>');
});